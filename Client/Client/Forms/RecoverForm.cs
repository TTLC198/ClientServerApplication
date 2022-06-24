using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Windows.Forms;
using PStudioLibrary;

namespace Client.Forms
{
    public partial class RecoverForm : Form
    {
        public RecoverForm()
        {
            InitializeComponent();
        }

        private void RecoverForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            AuthForm authForm = new AuthForm();
            authForm.Show();
        }

        private void recoverButton_Click(object sender, EventArgs e)
        {
            try
            {
                User tempUser = new User() { email = mailTextBox.Text };
                Services.SendComplexMessageAsync(Network.stream, new ComplexMessage()
                {
                    Messages = new []
                    {
                        SerializeAndDeserialize.Serialize(tempUser),
                    },
                    StatusCode = 212
                });
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
                        MessageBox.Show($"Сообщение с паролем успешно отправлено на почту {mailTextBox.Text}");
                    else if (responseMessage.StatusCode == 404)
                        MessageBox.Show($"Пользователь с почтой: {mailTextBox.Text} не найден");
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show($"Something went wrong:\n{exception.Message}");
            }
        }
    }
}