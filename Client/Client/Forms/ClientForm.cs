using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using PStudioLibrary;

namespace Client.Forms
{
    public partial class ClientForm : Form
    {
        public User currentUser;
        public PStudioLibrary.Client currentClient;

        private static Order _order;
        
        private static Dictionary<int, string> photDictionary = new();
        private static Dictionary<int, string> queriesDictionary = new();
    
        public ClientForm()
        {
            InitializeComponent();
            Network.stream = Network.client.GetStream();
        }

        private void ClientForm_Load(object sender, EventArgs e)
        {
            if (currentClient != null && currentUser != null)
            {
                ExecuteButton.Text = "Оформить заказ";
                _order = null;
                userLabel.Text = currentUser.name;
                
                ordersCountLabel.Text = $@"{currentClient.completed_orders ?? 0}";
                
                Services.SendComplexMessageAsync(Network.stream, new ComplexMessage()
                {
                    StatusCode = 208
                });
                Network.stream.Flush();
                if (Network.stream.CanRead)
                {
                    byte[] myReadBuffer = new byte[6297630];
                    do
                    {
                        Network.stream.Read(myReadBuffer, 0, myReadBuffer.Length);
                    } while (Network.stream.DataAvailable);
                    
                    var responseMessage = (ComplexMessage) SerializeAndDeserialize.Deserialize(myReadBuffer);
                    if (responseMessage.StatusCode == 200)
                       photDictionary = SerializeAndDeserialize.DeserializeDictionary(responseMessage.Messages[0].Data);
                }
                photListBox.Items.AddRange(photDictionary.Select(pd => pd.Value).Cast<object>().ToArray());
                Network.stream.Flush();
                Services.SendComplexMessageAsync(Network.stream, new ComplexMessage()
                {
                    Messages = new []
                    {
                        SerializeAndDeserialize.Serialize(currentUser)  
                    },
                    StatusCode = 205
                });
                Network.stream.Flush();
                if (Network.stream.CanRead)
                {
                    byte[] myReadBuffer = new byte[6297630];
                    do
                    {
                        Network.stream.Read(myReadBuffer, 0, myReadBuffer.Length);
                    } while (Network.stream.DataAvailable);
                    Network.stream.Flush();
                    var responseMessage = (ComplexMessage) SerializeAndDeserialize.Deserialize(myReadBuffer);
                    if (responseMessage.StatusCode == 200)
                        queriesDictionary = SerializeAndDeserialize.DeserializeDictionary(responseMessage.Messages[0].Data);
                }

                queriesListBox.Items.AddRange(queriesDictionary.Select(qd => qd.Value).Cast<object>().ToArray());
            }
        }

        private void ExecuteButton_Click(object sender, EventArgs e)
        {
            if (_order is {isCompleted: true} && scoreLabel.Text == "Поставьте оценку исполнителю")
            {
                MessageBox.Show("Поставьте оценку исполнителю!");
                return;
            }
            if (_order is {isCompleted: true})
            {
                currentClient.completed_orders++;
                Services.SendComplexMessageAsync(Network.stream, new ComplexMessage()
                {
                    Messages = new []
                    {
                        SerializeAndDeserialize.Serialize(_order),
                        SerializeAndDeserialize.Serialize(currentClient),
                        SerializeAndDeserialize.Serialize(new Photographer()
                        {
                            rating = (short?)scoreTrackBar.Value
                        })
                    },
                    StatusCode = 210
                });
                Network.stream.Flush();
                if (Network.stream.CanRead)
                {
                    byte[] myReadBuffer = new byte[6297630];
                    do
                    {
                        Network.stream.Read(myReadBuffer, 0, myReadBuffer.Length);
                    } while (Network.stream.DataAvailable);
                    Network.stream.Flush();
                    var responseMessage = (ComplexMessage) SerializeAndDeserialize.Deserialize(myReadBuffer);
                    if (responseMessage.StatusCode == 200)
                        MessageBox.Show("Отзыв отправлен!");
                }
                    
                ExecuteButton.Text = "Оформить заказ";

                return;
            }
            if (messageTextBox.Text == null)
            {
                MessageBox.Show("Введите, пожалуйста, сообщение исполнителю!");
                return;
            }

            if (photListBox.SelectedItem == null)
            {
                MessageBox.Show("Выберите, пожалуйста, исполнителя!");
                return;
            }
            Services.SendComplexMessageAsync(Network.stream, new ComplexMessage()
            {
                Messages = new []
                {
                    SerializeAndDeserialize.Serialize(new Order()
                    {
                        message = messageTextBox.Text,
                        c_id = currentClient.id,
                        p_id = photDictionary.First(pd => pd.Value == (string) photListBox.SelectedItem).Key,
                        isCompleted = false
                    })
                },
                StatusCode = 209
            });
            Network.stream.Flush();
            if (Network.stream.CanRead)
            {
                byte[] myReadBuffer = new byte[6297630];
                do
                {
                    Network.stream.Read(myReadBuffer, 0, myReadBuffer.Length);
                } while (Network.stream.DataAvailable);
                Network.stream.Flush();
                var responseMessage = (ComplexMessage) SerializeAndDeserialize.Deserialize(myReadBuffer);
                if (responseMessage.StatusCode == 200)
                    MessageBox.Show("Заказ успешно отправлен исполнителю!");
            }
        }

        private void queriesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                for (int i = 1; i < imagesPanel.Controls.Count; i++) imagesPanel.Controls.RemoveAt(i);
                    var photos = new List<Photo>();
                    var o_id = queriesDictionary.First(qd => qd.Value == (string) (sender as ListBox).SelectedItem).Key;

                    Services.SendComplexMessageAsync(Network.stream, new ComplexMessage()
                    {
                        Messages = new[]
                        {
                            SerializeAndDeserialize.Serialize(new Order()
                            {
                                id = o_id
                            })
                        },
                        StatusCode = 206
                    });
                    Network.stream.Flush();
                    if (Network.stream.CanRead)
                    {
                        byte[] myReadBuffer = new byte[6297630];
                        do
                        {
                            Network.stream.Read(myReadBuffer, 0, myReadBuffer.Length);
                        } while (Network.stream.DataAvailable);

                        var responseMessage = (ComplexMessage) SerializeAndDeserialize.Deserialize(myReadBuffer);
                        if (responseMessage.StatusCode == 200)
                            _order = (Order) SerializeAndDeserialize.Deserialize(responseMessage.Messages[0].Data);
                        else
                            MessageBox.Show("Произошла ошибка на стороне сервера!");
                    }

                    Network.stream.Flush();
                    Services.SendComplexMessageAsync(Network.stream, new ComplexMessage()
                    {
                        Messages = new[]
                        {
                            SerializeAndDeserialize.Serialize(_order)
                        },
                        StatusCode = 211
                    });
                    Network.stream.Flush();
                    if (Network.stream.CanRead)
                    {
                        byte[] myReadBuffer = new byte[6297630];
                        do
                        {
                            Network.stream.Read(myReadBuffer, 0, myReadBuffer.Length);
                        } while (Network.stream.DataAvailable);

                        Network.stream.Flush();
                        var responseMessage = (ComplexMessage) SerializeAndDeserialize.Deserialize(myReadBuffer);
                        if (responseMessage.StatusCode == 200)
                        {
                            photos = (List<Photo>) SerializeAndDeserialize.Deserialize(responseMessage.Messages[0]
                                .Data);
                            foreach (var photo in photos)
                            {
                                PictureBox pictureBox = new PictureBox();
                                pictureBox.Image = Services.ByteArrayToImage(photo.data);
                                pictureBox.BorderStyle = BorderStyle.FixedSingle;
                                pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                                pictureBox.Size = new Size(330, 230);
                                imagesPanel.Controls.Add(pictureBox);
                            }

                            if (_order.isCompleted)
                            {
                                messagePanel.Visible = false;
                                imagesPanel.Visible = true;
                                scoreLabel.Text = "Поставьте оценку исполнителю";
                                ExecuteButton.Text = "Оставить отзыв";
                                return;
                            }

                            messagePanel.Visible = false;
                            imagesPanel.Visible = true;
                        }
                        else
                            MessageBox.Show("Произошла ошибка на стороне сервера!");
                    }

                    Network.stream.Flush();
            }
            catch (Exception exception)
            {
                MessageBox.Show($"Произошла ошибка:\n{exception.Message}");
            }
        }

        private void NewOrderButton_Click(object sender, EventArgs e)
        {
            ExecuteButton.Text = "Оформить заказ";
            if (_order == null)
            {
                MessageBox.Show("Напишите сообщение исполнителю!");
                return;
            }

            _order = null;
            for (int i = 1; i < imagesPanel.Controls.Count; i++) imagesPanel.Controls.RemoveAt(i);
            messagePanel.Visible = true;
            imagesPanel.Visible = false;
        }

        private void scoreTrackBar_Scroll(object sender, EventArgs e)
        {
            if (scoreTrackBar != null)
            {
                scoreLabel.Text = $"Оценка: {(sender as TrackBar).Value}";
            }
        }

        private void ClientForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Network.client.Close();
            Application.Exit();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            AuthForm authForm = new AuthForm();
            authForm.Show();
        }
    }
}