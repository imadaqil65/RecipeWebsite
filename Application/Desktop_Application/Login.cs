using Microsoft.VisualBasic.ApplicationServices;
using MyApplication.Domain.Services;
using MyApplication.Domain.Users;
using MyApplication.Infrastructure.Databases;
using User = MyApplication.Domain.Users.User;

namespace Desktop_Application
{
    public partial class Login : Form
    {
        private readonly UserServices userServices;
        public Login()
        {
            InitializeComponent();
            userServices = new UserServices(new UserRepository());
            tbxPassword.UseSystemPasswordChar = true;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string[] texts = new string[] { tbxUsername.Text, tbxPassword.Text };
                if (ValidationServices.TextBoxValidation(texts))
                {
                    bool matchUser = userServices.CheckUsername(tbxUsername.Text);
                    bool matchPass = userServices.VerifyPassword(tbxUsername.Text, tbxPassword.Text);
                    
                    if (matchUser && matchPass)
                    {
                        User user = userServices.GetUserByName(tbxUsername.Text);
                        if (user.isAdmin && user.shown)
                        {
                            MainForm mainForm = new MainForm(user, this);
                            this.Hide(); mainForm.Show();
                        }
                        else
                        {
                            MessageBox.Show("Access Denied");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Credentials Invalid");
                    }
                }
                else
                {
                    MessageBox.Show("Some or All fields are empty");
                }

            }
            catch(Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void chbxShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (chbxShowPassword.Checked)
            {
                tbxPassword.UseSystemPasswordChar = false;
            }
            else
            {
                tbxPassword.UseSystemPasswordChar = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm(userServices.GetUserByName("Admin1"), this);
            this.Hide(); mainForm.Show();
        }
    }
}
