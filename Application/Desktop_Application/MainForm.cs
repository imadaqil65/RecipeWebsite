using Desktop_Application.FlowLayout;
using MyApplication.Domain.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desktop_Application
{
    public partial class MainForm : Form
    {
        private readonly User user;
        private readonly Login loginform;
        public MainForm(User user, Login loginform)
        {
            InitializeComponent();
            this.user = user;
            this.loginform = loginform;
            flowLayoutPanel1.Controls.Add(new UsersControl(user));
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            try
            {
                flowLayoutPanel1.Controls.Clear();
                flowLayoutPanel1.Controls.Add(new UsersControl(user));
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnRecipes_Click(object sender, EventArgs e)
        {
            try { 
            flowLayoutPanel1.Controls.Clear();
            flowLayoutPanel1.Controls.Add(new RecipesControl(user));
        }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
}

        private void btnLogout_Click(object sender, EventArgs e)
        {
            try
            {
                switch (MessageBox.Show(this, "Want To Logout?", "Logging Out", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    case DialogResult.Yes:
                        this.Close();
                        break;
                    case DialogResult.No:
                        break;
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                loginform.Show();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
