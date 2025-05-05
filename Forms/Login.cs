using AxiaFutures.Model;
using AxiaFutures.Services.Auth;
using Microsoft.Extensions.DependencyInjection;

namespace AxiaFutures.Forms
{
    public partial class Login : Form
    {
        private IAuthService _authService;
        public Login()
        {
            InitializeComponent();
            this._authService = new AuthService();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string userName = txtUser.Text;
            string password = txtPassword.Text;

            try
            {
                Auth user = new Auth() { UserName = userName, Password = password };
                await this._authService.Auth(user);
                var feed = Program.ServiceProvider.GetRequiredService<Feed>();
                feed.FormClosed += (s, args) => this.Close();
                this.Hide();
                feed.Show();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                MessageBox.Show(exception.Message, "Desculpa", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            CentralizarGroupBox();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            CentralizarGroupBox();
        }

        private void CentralizarGroupBox()
        {
            groupBox1.Location = new Point(
                (this.ClientSize.Width - groupBox1.Width) / 2,
                (this.ClientSize.Height - groupBox1.Height) / 2
            );
        }
    }
}
