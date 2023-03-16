using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using PStudioLibrary;
using Message = PStudioLibrary.Message;

namespace Client.Forms
{
    public partial class AuthForm : Form
    {
        private static User currentUser = new User();
        public AuthForm()
        {
            InitializeComponent();
            try
            {
                Network.stream = Network.client.GetStream();
            }
            catch (System.TypeInitializationException)
            {
                MessageBox.Show("Сервер не доступен!\nПовторите позже.");
            }
        }

        private void passwordVisibleCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            passwordTextBox.UseSystemPasswordChar = !(sender as CheckBox)!.Checked;
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            string login = loginTextBox.Text, password = passwordTextBox.Text;
            if (login != String.Empty
                && password != String.Empty)
            {
                this.Hide();
                GetUser(login, password);
                if (currentUser.email != null)
                {
                    MessageBox.Show("Вход произошел успешно!");
                    switch (currentUser.role)
                    {
                        case "Исполнитель":
                            Action showPhForm = (() =>
                            {
                                Services.SendComplexMessageAsync(Network.stream, new ComplexMessage()
                                {
                                    Messages = new[]
                                    {
                                        SerializeAndDeserialize.Serialize(currentUser)
                                    },
                                    StatusCode = 204
                                });
                                Network.stream.Flush();
                                if (Network.stream.CanRead)
                                {
                                    byte[] myReadBuffer = new byte[6297630];
                                    do
                                    {
                                        Network.stream.Read(myReadBuffer, 0, myReadBuffer.Length);
                                    } while (Network.stream.DataAvailable);

                                    var responseMessage =
                                        (ComplexMessage) SerializeAndDeserialize.Deserialize(myReadBuffer);
                                    if (responseMessage.StatusCode == 200)
                                    {
                                        PhotographerForm photographerForm = new PhotographerForm();
                                        photographerForm.currentUser = currentUser;
                                        photographerForm.currentPhotographer =
                                            (Photographer) SerializeAndDeserialize.Deserialize(responseMessage
                                                .Messages[0].Data);
                                        photographerForm.Show();
                                    }
                                    else
                                        MessageBox.Show("Произошла ошибка на стороне сервера!");
                                }
                            });
                            BeginInvoke(showPhForm);
                            break;
                        case "Клиент":
                            Action showClForm = (() =>
                            {
                                Services.SendComplexMessageAsync(Network.stream, new ComplexMessage()
                                {
                                    Messages = new[]
                                    {
                                        SerializeAndDeserialize.Serialize(currentUser)
                                    },
                                    StatusCode = 203
                                });
                                Network.stream.Flush();
                                if (Network.stream.CanRead)
                                {
                                    byte[] myReadBuffer = new byte[6297630];
                                    do
                                    {
                                        Network.stream.Read(myReadBuffer, 0, myReadBuffer.Length);
                                    } while (Network.stream.DataAvailable);

                                    var responseMessage =
                                        (ComplexMessage) SerializeAndDeserialize.Deserialize(myReadBuffer);
                                    if (responseMessage.StatusCode == 200)
                                    {
                                        ClientForm clientForm = new ClientForm();
                                        clientForm.currentUser = currentUser;
                                        clientForm.currentClient =
                                            (PStudioLibrary.Client) SerializeAndDeserialize.Deserialize(responseMessage
                                                .Messages[0].Data);
                                        clientForm.Show();
                                    }
                                    else
                                        MessageBox.Show("Произошла ошибка на стороне сервера!");
                                }
                            });
                            BeginInvoke(showClForm);
                            break;
                    }
                }
                else
                {
                    MessageBox.Show("Пользователь с введеными данными не найден!");
                    this.Show();
                }
                    
            }
            else
            {
                MessageBox.Show("Пожалуйста, введите все данные для входа!");
                this.Show();
            }
        }

        private static async Task GetUser(string login, string password)
        {
            await Services.SendComplexMessageAsync(Network.stream, new ComplexMessage()
            {
                Messages = new []
                {
                    SerializeAndDeserialize.Serialize(new User()
                    {
                        login = login,
                        password = password
                    })  
                },
                StatusCode = 202
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
                    currentUser = (User) SerializeAndDeserialize.Deserialize(responseMessage.Messages[0].Data);
                else
                    MessageBox.Show("Произошла ошибка на стороне сервера!");
            }
        }

        private void registrationButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            RegistrationForm registrationForm = new RegistrationForm();
            registrationForm.Show();
        }

        private void AuthForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void restorePassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            RecoverForm recoverForm = new RecoverForm();
            recoverForm.Show();
        }
    }
}
