using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using PStudioLibrary;

namespace Client.Forms
{
    public partial class PhotographerForm : Form
    {
        public User currentUser;
        public Photographer currentPhotographer;
        private static Order _order;
        private static Dictionary<int, string> queriesDictionary = new();
        private static List<Photo> _photos = new ();
        public PhotographerForm()
        {
            InitializeComponent();
            Network.stream = Network.client.GetStream();
        }

        private void PhotographerForm_Load(object sender, EventArgs e)
        {
            if (currentPhotographer != null && currentUser != null)
            {
                userLabel.Text = currentUser.name;
                ordersCountLabel.Text = $@"{currentPhotographer.completed_orders ?? 0}";

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
                    else 
                        MessageBox.Show("Произошла ошибка на стороне сервера!");
                }
                    
                queriesList.Items.AddRange(queriesDictionary.Select(qd => qd.Value).Cast<object>().ToArray());
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            AuthForm authForm = new AuthForm();
            authForm.Show();
        }

        private void queriesList_SelectedIndexChanged(object sender, EventArgs e)
        {
            _photos = new List<Photo>();
            var o_id = queriesDictionary.First(qd => qd.Value == (string) (sender as ListBox).SelectedItem).Key;
            Services.SendComplexMessageAsync(Network.stream, new ComplexMessage()
            {
                Messages = new []
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
                Network.stream.Flush();
                var responseMessage = (ComplexMessage) SerializeAndDeserialize.Deserialize(myReadBuffer);
                if (responseMessage.StatusCode == 200)
                    _order = (Order) SerializeAndDeserialize.Deserialize(responseMessage.Messages[0].Data); 
                else 
                    MessageBox.Show("Произошла ошибка на стороне сервера!");
            }
            messageBox.Text = _order.message;
        }

        private void ExecuteButton_Click(object sender, EventArgs e)
        {
            if (queriesList.SelectedItem == null)
            {
                MessageBox.Show("Выберите, пожалуйста, заказ!");
                return;
            }
            try
            {
                _order.isCompleted = true;
                var orderMessage = SerializeAndDeserialize.Serialize(_order);
                var photosMessage = SerializeAndDeserialize.Serialize(_photos);
            
                Services.SendComplexMessageAsync(Network.stream, new ComplexMessage()
                {
                    Messages = new []
                    {
                        orderMessage, photosMessage
                    },
                    StatusCode = 207
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
                        MessageBox.Show("Заказ успешно отправлен заказчику!");
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show($"Произошла ошибка:\n{exception.Message}");
            }
        }

        private void openFileDialogButton_Click(object sender, EventArgs e)
        {
            if (_order == null)
            {
                MessageBox.Show("Выберите заказ!");
                return;
            }
            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                    return;
                PictureBox pictureBox = new PictureBox();
                var img = Image.FromFile(openFileDialog1.FileName);
                pictureBox.Image = img;
                _photos.Add(new Photo()
                {
                    data = Services.ImageToByteArray(img),
                    or_id = _order.id
                });
                pictureBox.BorderStyle = BorderStyle.FixedSingle;
                pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox.Size = new Size(330, 230);
                imagesPanel.Controls.Add(pictureBox);
            }
            catch (Exception exception)
            {
                MessageBox.Show($"Произошла ошибка:\n{exception.Message}");
            }
        }

        private void PhotographerForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Network.client.Close();
            Application.Exit();
        }
    }
}
