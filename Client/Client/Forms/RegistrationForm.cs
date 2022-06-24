using System;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Windows.Forms;
using PStudioLibrary;
using Message = PStudioLibrary.Message;

namespace Client.Forms
{
    public partial class RegistrationForm : Form
    {
        public RegistrationForm()
        {
            InitializeComponent();
            Network.stream = Network.client.GetStream();
        }

        private void registrationButton_Click(object sender, EventArgs e)
        {
            if (roleComboBox.SelectedItem == null)
            {
                MessageBox.Show("Введите данные!");
                return;
            }
            string password = passwordTextBox.Text,
                login = loginTextBox.Text,
                name = nameTextBox.Text,
                email = emailTextBox.Text,
                role = roleComboBox.SelectedItem.ToString();
            if (password != String.Empty
                && login != String.Empty
                && name != String.Empty
                && email != String.Empty
                && role != String.Empty)
            {
                try
                {
                    User user = new ()
                    {
                        email = email,
                        name = name,
                        login = login,
                        password = Services.GetHashString(password),
                        role = role
                    };

                    Task.Run(async () =>
                    {
                        Message userMessage = SerializeAndDeserialize.Serialize(user);
                        ComplexMessage requestMessage = new ComplexMessage()
                        {
                            Messages = new[]
                            {
                                userMessage
                            },
                            StatusCode = 201
                        };
                        await Services.SendComplexMessageAsync(Network.stream, requestMessage); 
                        await Network.stream.FlushAsync();
                        if (Network.stream.CanRead)
                        {
                            byte[] myReadBuffer = new byte[6297630];
                            do
                            {
                                Network.stream.Read(myReadBuffer, 0, myReadBuffer.Length);
                            } while (Network.stream.DataAvailable);

                            ComplexMessage responseMessage =
                                (ComplexMessage) SerializeAndDeserialize.Deserialize(myReadBuffer);
                            if (responseMessage.StatusCode == 303)
                            {
                                MessageBox.Show("Пользователь с похожими данными уже присутствует в системе!");
                            }
                            else if (responseMessage.StatusCode == 200)
                            {
                                MessageBox.Show("Регистрация прошла успешно!");
                            }
                        }
                    });
                }
                catch (Exception exception)
                {
                    MessageBox.Show($"Произошла ошибка!\n{exception.Message}");
                }
            }
            else MessageBox.Show("Пожалуйста, заполните все поля!");
        }

        private void RegistrationForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            AuthForm authForm = new AuthForm();
            authForm.Show();
        }
    }
}