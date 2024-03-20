using MyApplication.Domain.Services;
using MyApplication.Domain.Users;
using MyApplication.Infrastructure.Databases;

namespace Desktop_Application.FlowLayout
{
    public partial class UsersControl : UserControl
    {
        private readonly User user;
        private readonly UserServices userServices;
        public UsersControl(User user)
        {
            InitializeComponent();
            try
            {
                userServices = new UserServices(new UserRepository());
                this.user = user;
                FillDataGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FillModifyUser(User selectedUser)
        {
            tbxModifyUserId.Text = selectedUser.userId.ToString();
            tbxModifyUserId.ReadOnly = true;
            tbxModifyUsername.Text = selectedUser.username;
            tbxModifyEmail.Text = selectedUser.email;
            tbxModifyFirstName.Text = selectedUser.firstname;
            tbxModifyMiddleName.Text = selectedUser.middlename;
            tbxModifyLastName.Text = selectedUser.lastname;
            chbxModifyAdmin.Checked = selectedUser.isAdmin;
            chbxActive.Checked = selectedUser.shown;
        }

        private void FillDataGrid()
        {
            List<User> users = new List<User>(userServices.ReadAllUsers());
            users.RemoveAll(x => x.userId == user.userId);
            dgvUsers.DataSource = users;
            dgvUsers.Columns["password"].Visible = false;
            //dgvUsers.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.Fill);
        }

        private void FillDataGrid(List<User> users)
        {
            users.RemoveAll(x => x.userId == user.userId);
            dgvUsers.DataSource = users;
            dgvUsers.Columns["password"].Visible = false;
        }

        private void ClearTextboxes()
        {
            tbxEmail.Clear();
            tbxFirstname.Clear();
            tbxLastname.Clear();
            tbxMiddlename.Clear();
            tbxModifyEmail.Clear();
            tbxModifyFirstName.Clear();
            tbxModifyLastName.Clear();
            tbxModifyMiddleName.Clear();
            tbxModifyUserId.Clear();
            tbxModifyUsername.Clear();
            tbxNewPassword.Clear();
            tbxPassword.Clear();
            tbxUsername.Clear();
            chbxAdmin.Checked = false;
            chbxModifyAdmin.Checked = false;
        }

        private void dgvUsers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var SelectedUser = dgvUsers.SelectedRows[0].DataBoundItem as User;
                FillModifyUser(SelectedUser);
                tabControl1.SelectedTab = tabPage2;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            try
            {
                var SelectedUser = dgvUsers.SelectedRows[0].DataBoundItem as User;
                FillModifyUser(SelectedUser);
                tabControl1.SelectedTab = tabPage2;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnModifyUser_Click(object sender, EventArgs e)
        {
            try
            {
                switch (MessageBox.Show(this, "Are you sure you want to modify this user?", "Modify User", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    case DialogResult.Yes:
                        User selecteduser = userServices.GetUserById(int.Parse(tbxModifyUserId.Text));
                        selecteduser.setUsername(tbxModifyUsername.Text);
                        selecteduser.setEmail(tbxModifyEmail.Text);
                        if (!string.IsNullOrEmpty(tbxNewPassword.Text))
                        {
                            selecteduser.SetPassword(tbxNewPassword.Text);
                        }
                        selecteduser.isAdmin = chbxModifyAdmin.Checked;
                        selecteduser.shown = chbxActive.Checked;
                        string[] Alltbx = new string[] { tbxModifyUsername.Text, tbxModifyEmail.Text };
                        bool notEmpty = ValidationServices.TextBoxValidation(Alltbx);
                        bool ValidEmail = ValidationServices.ValidEmail(tbxModifyEmail.Text);
                        if (notEmpty && ValidEmail)
                        {
                            selecteduser.setName(tbxModifyFirstName.Text, tbxModifyMiddleName.Text, tbxModifyLastName.Text);
                            userServices.UpdateUser(selecteduser);
                            MessageBox.Show("User updated");
                            FillDataGrid();
                            ClearTextboxes();
                            tabControl1.SelectedTab = tabPage1;
                        }
                        else if (!notEmpty)
                        {
                            MessageBox.Show("Some or all fields are empty");
                        }
                        else if (!ValidEmail)
                        {
                            MessageBox.Show("Invalid Email");
                        }
                        else
                        {
                            MessageBox.Show("An error occured");
                        }
                        break;
                    case DialogResult.No:
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                string username = tbxUsername.Text;
                string email = tbxEmail.Text;
                string password = userServices.HashPassword(tbxPassword.Text);
                string? firstname = tbxFirstname.Text;
                string? middlename = tbxMiddlename.Text;
                string? lastname = tbxLastname.Text;
                bool isAdmin = chbxAdmin.Checked;

                string[] Alltbx = new string[] { username, email, password };
                bool notEmpty = ValidationServices.TextBoxValidation(Alltbx);
                bool ValidEmail = ValidationServices.ValidEmail(email);


                if (notEmpty && ValidEmail)
                {
                    User newUser = new User(0, username, password, firstname, middlename, lastname, email, isAdmin, true);
                    userServices.CreateUser(newUser);
                    MessageBox.Show("User added");
                    FillDataGrid();
                    ClearTextboxes();
                    tabControl1.SelectedTab = tabPage1;
                }
                else if (!notEmpty)
                {
                    MessageBox.Show("Some or all fields are empty");
                }
                else if (!ValidEmail)
                {
                    MessageBox.Show("Invalid Email");
                }
                else
                {
                    MessageBox.Show("An error occured");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            tbxSearch.Clear();
            FillDataGrid();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int SelectedUser = (int)dgvUsers.SelectedRows[0].Cells["userId"].Value;
                switch (MessageBox.Show(this, "Are you sure you want to hide this User?", "Hide User", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    case DialogResult.Yes:
                        userServices.DeleteUser(SelectedUser);
                        MessageBox.Show("User is hidden");
                        FillDataGrid();
                        break;
                    case DialogResult.No:
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string NameSearch = tbxSearch.Text;
                List<User> filteredUsers = new List<User>();
                foreach (var u in userServices.ReadActiveUsers())
                {
                    if (string.IsNullOrEmpty(NameSearch) || u.username.Contains(NameSearch, (StringComparison)5))
                    {
                        filteredUsers.Add(u);
                    }
                }
                FillDataGrid(filteredUsers);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
