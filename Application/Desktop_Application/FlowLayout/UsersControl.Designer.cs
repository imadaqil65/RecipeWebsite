namespace Desktop_Application.FlowLayout
{
    partial class UsersControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbxSearch = new System.Windows.Forms.TextBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnModify = new System.Windows.Forms.Button();
            this.dgvUsers = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label17 = new System.Windows.Forms.Label();
            this.chbxActive = new System.Windows.Forms.CheckBox();
            this.btnModifyUser = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.chbxModifyAdmin = new System.Windows.Forms.CheckBox();
            this.tbxModifyLastName = new System.Windows.Forms.TextBox();
            this.tbxNewPassword = new System.Windows.Forms.TextBox();
            this.tbxModifyFirstName = new System.Windows.Forms.TextBox();
            this.tbxModifyMiddleName = new System.Windows.Forms.TextBox();
            this.tbxModifyEmail = new System.Windows.Forms.TextBox();
            this.tbxModifyUsername = new System.Windows.Forms.TextBox();
            this.tbxModifyUserId = new System.Windows.Forms.TextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btnCreate = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.chbxAdmin = new System.Windows.Forms.CheckBox();
            this.tbxLastname = new System.Windows.Forms.TextBox();
            this.tbxPassword = new System.Windows.Forms.TextBox();
            this.tbxFirstname = new System.Windows.Forms.TextBox();
            this.tbxMiddlename = new System.Windows.Forms.TextBox();
            this.tbxEmail = new System.Windows.Forms.TextBox();
            this.tbxUsername = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(3, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1106, 746);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnRefresh);
            this.tabPage1.Controls.Add(this.btnSearch);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.tbxSearch);
            this.tabPage1.Controls.Add(this.btnDelete);
            this.tabPage1.Controls.Add(this.btnModify);
            this.tabPage1.Controls.Add(this.dgvUsers);
            this.tabPage1.Location = new System.Drawing.Point(4, 34);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1098, 708);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "View Users";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(893, 523);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(112, 34);
            this.btnRefresh.TabIndex = 6;
            this.btnRefresh.Text = "Refresh List";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(893, 71);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(112, 34);
            this.btnSearch.TabIndex = 5;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(893, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "Search by Name";
            // 
            // tbxSearch
            // 
            this.tbxSearch.Location = new System.Drawing.Point(893, 34);
            this.tbxSearch.Name = "tbxSearch";
            this.tbxSearch.Size = new System.Drawing.Size(199, 31);
            this.tbxSearch.TabIndex = 3;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(893, 651);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(199, 51);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "Hide";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnModify
            // 
            this.btnModify.Location = new System.Drawing.Point(893, 573);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(199, 56);
            this.btnModify.TabIndex = 1;
            this.btnModify.Text = "Modify";
            this.btnModify.UseVisualStyleBackColor = true;
            this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
            // 
            // dgvUsers
            // 
            this.dgvUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsers.Location = new System.Drawing.Point(6, 6);
            this.dgvUsers.Name = "dgvUsers";
            this.dgvUsers.RowHeadersWidth = 62;
            this.dgvUsers.RowTemplate.Height = 33;
            this.dgvUsers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUsers.Size = new System.Drawing.Size(881, 696);
            this.dgvUsers.TabIndex = 0;
            this.dgvUsers.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUsers_CellContentClick);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label17);
            this.tabPage2.Controls.Add(this.chbxActive);
            this.tabPage2.Controls.Add(this.btnModifyUser);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.chbxModifyAdmin);
            this.tabPage2.Controls.Add(this.tbxModifyLastName);
            this.tabPage2.Controls.Add(this.tbxNewPassword);
            this.tabPage2.Controls.Add(this.tbxModifyFirstName);
            this.tabPage2.Controls.Add(this.tbxModifyMiddleName);
            this.tabPage2.Controls.Add(this.tbxModifyEmail);
            this.tabPage2.Controls.Add(this.tbxModifyUsername);
            this.tabPage2.Controls.Add(this.tbxModifyUserId);
            this.tabPage2.Location = new System.Drawing.Point(4, 34);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1098, 708);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Modify User";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(49, 459);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(60, 25);
            this.label17.TabIndex = 18;
            this.label17.Text = "Active";
            // 
            // chbxActive
            // 
            this.chbxActive.AutoSize = true;
            this.chbxActive.Location = new System.Drawing.Point(239, 462);
            this.chbxActive.Name = "chbxActive";
            this.chbxActive.Size = new System.Drawing.Size(22, 21);
            this.chbxActive.TabIndex = 17;
            this.chbxActive.UseVisualStyleBackColor = true;
            // 
            // btnModifyUser
            // 
            this.btnModifyUser.Location = new System.Drawing.Point(239, 506);
            this.btnModifyUser.Name = "btnModifyUser";
            this.btnModifyUser.Size = new System.Drawing.Size(130, 44);
            this.btnModifyUser.TabIndex = 16;
            this.btnModifyUser.Text = "Modify";
            this.btnModifyUser.UseVisualStyleBackColor = true;
            this.btnModifyUser.Click += new System.EventHandler(this.btnModifyUser_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(49, 417);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 25);
            this.label9.TabIndex = 15;
            this.label9.Text = "Admin";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(49, 366);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(95, 25);
            this.label8.TabIndex = 14;
            this.label8.Text = "Last Name";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(49, 309);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(119, 25);
            this.label7.TabIndex = 13;
            this.label7.Text = "Middle Name";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(49, 253);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(97, 25);
            this.label6.TabIndex = 12;
            this.label6.Text = "First Name";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(49, 199);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(127, 25);
            this.label5.TabIndex = 11;
            this.label5.Text = "New Password";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(49, 147);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 25);
            this.label4.TabIndex = 10;
            this.label4.Text = "Email";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(49, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 25);
            this.label3.TabIndex = 9;
            this.label3.Text = "Username";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(49, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 25);
            this.label2.TabIndex = 8;
            this.label2.Text = "User Id";
            // 
            // chbxModifyAdmin
            // 
            this.chbxModifyAdmin.AutoSize = true;
            this.chbxModifyAdmin.Location = new System.Drawing.Point(239, 421);
            this.chbxModifyAdmin.Name = "chbxModifyAdmin";
            this.chbxModifyAdmin.Size = new System.Drawing.Size(22, 21);
            this.chbxModifyAdmin.TabIndex = 7;
            this.chbxModifyAdmin.UseVisualStyleBackColor = true;
            // 
            // tbxModifyLastName
            // 
            this.tbxModifyLastName.Location = new System.Drawing.Point(239, 363);
            this.tbxModifyLastName.Name = "tbxModifyLastName";
            this.tbxModifyLastName.Size = new System.Drawing.Size(242, 31);
            this.tbxModifyLastName.TabIndex = 6;
            // 
            // tbxNewPassword
            // 
            this.tbxNewPassword.Location = new System.Drawing.Point(239, 196);
            this.tbxNewPassword.Name = "tbxNewPassword";
            this.tbxNewPassword.Size = new System.Drawing.Size(242, 31);
            this.tbxNewPassword.TabIndex = 5;
            // 
            // tbxModifyFirstName
            // 
            this.tbxModifyFirstName.Location = new System.Drawing.Point(239, 250);
            this.tbxModifyFirstName.Name = "tbxModifyFirstName";
            this.tbxModifyFirstName.Size = new System.Drawing.Size(242, 31);
            this.tbxModifyFirstName.TabIndex = 4;
            // 
            // tbxModifyMiddleName
            // 
            this.tbxModifyMiddleName.Location = new System.Drawing.Point(239, 306);
            this.tbxModifyMiddleName.Name = "tbxModifyMiddleName";
            this.tbxModifyMiddleName.Size = new System.Drawing.Size(242, 31);
            this.tbxModifyMiddleName.TabIndex = 3;
            // 
            // tbxModifyEmail
            // 
            this.tbxModifyEmail.Location = new System.Drawing.Point(239, 144);
            this.tbxModifyEmail.Name = "tbxModifyEmail";
            this.tbxModifyEmail.Size = new System.Drawing.Size(242, 31);
            this.tbxModifyEmail.TabIndex = 2;
            // 
            // tbxModifyUsername
            // 
            this.tbxModifyUsername.Location = new System.Drawing.Point(239, 93);
            this.tbxModifyUsername.Name = "tbxModifyUsername";
            this.tbxModifyUsername.Size = new System.Drawing.Size(242, 31);
            this.tbxModifyUsername.TabIndex = 1;
            // 
            // tbxModifyUserId
            // 
            this.tbxModifyUserId.Location = new System.Drawing.Point(239, 45);
            this.tbxModifyUserId.Name = "tbxModifyUserId";
            this.tbxModifyUserId.Size = new System.Drawing.Size(242, 31);
            this.tbxModifyUserId.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.btnCreate);
            this.tabPage3.Controls.Add(this.label10);
            this.tabPage3.Controls.Add(this.label11);
            this.tabPage3.Controls.Add(this.label12);
            this.tabPage3.Controls.Add(this.label13);
            this.tabPage3.Controls.Add(this.label14);
            this.tabPage3.Controls.Add(this.label15);
            this.tabPage3.Controls.Add(this.label16);
            this.tabPage3.Controls.Add(this.chbxAdmin);
            this.tabPage3.Controls.Add(this.tbxLastname);
            this.tabPage3.Controls.Add(this.tbxPassword);
            this.tabPage3.Controls.Add(this.tbxFirstname);
            this.tabPage3.Controls.Add(this.tbxMiddlename);
            this.tabPage3.Controls.Add(this.tbxEmail);
            this.tabPage3.Controls.Add(this.tbxUsername);
            this.tabPage3.Location = new System.Drawing.Point(4, 34);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(1098, 708);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Create User";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(235, 446);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(112, 34);
            this.btnCreate.TabIndex = 33;
            this.btnCreate.Text = "Create";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(45, 369);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 25);
            this.label10.TabIndex = 32;
            this.label10.Text = "Admin";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(45, 318);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(95, 25);
            this.label11.TabIndex = 31;
            this.label11.Text = "Last Name";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(45, 261);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(119, 25);
            this.label12.TabIndex = 30;
            this.label12.Text = "Middle Name";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(45, 205);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(97, 25);
            this.label13.TabIndex = 29;
            this.label13.Text = "First Name";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(45, 151);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(127, 25);
            this.label14.TabIndex = 28;
            this.label14.Text = "New Password";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(45, 99);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(54, 25);
            this.label15.TabIndex = 27;
            this.label15.Text = "Email";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(45, 48);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(91, 25);
            this.label16.TabIndex = 26;
            this.label16.Text = "Username";
            // 
            // chbxAdmin
            // 
            this.chbxAdmin.AutoSize = true;
            this.chbxAdmin.Location = new System.Drawing.Point(235, 373);
            this.chbxAdmin.Name = "chbxAdmin";
            this.chbxAdmin.Size = new System.Drawing.Size(22, 21);
            this.chbxAdmin.TabIndex = 24;
            this.chbxAdmin.UseVisualStyleBackColor = true;
            // 
            // tbxLastname
            // 
            this.tbxLastname.Location = new System.Drawing.Point(235, 315);
            this.tbxLastname.Name = "tbxLastname";
            this.tbxLastname.Size = new System.Drawing.Size(242, 31);
            this.tbxLastname.TabIndex = 23;
            // 
            // tbxPassword
            // 
            this.tbxPassword.Location = new System.Drawing.Point(235, 148);
            this.tbxPassword.Name = "tbxPassword";
            this.tbxPassword.Size = new System.Drawing.Size(242, 31);
            this.tbxPassword.TabIndex = 22;
            // 
            // tbxFirstname
            // 
            this.tbxFirstname.Location = new System.Drawing.Point(235, 202);
            this.tbxFirstname.Name = "tbxFirstname";
            this.tbxFirstname.Size = new System.Drawing.Size(242, 31);
            this.tbxFirstname.TabIndex = 21;
            // 
            // tbxMiddlename
            // 
            this.tbxMiddlename.Location = new System.Drawing.Point(235, 258);
            this.tbxMiddlename.Name = "tbxMiddlename";
            this.tbxMiddlename.Size = new System.Drawing.Size(242, 31);
            this.tbxMiddlename.TabIndex = 20;
            // 
            // tbxEmail
            // 
            this.tbxEmail.Location = new System.Drawing.Point(235, 96);
            this.tbxEmail.Name = "tbxEmail";
            this.tbxEmail.Size = new System.Drawing.Size(242, 31);
            this.tbxEmail.TabIndex = 19;
            // 
            // tbxUsername
            // 
            this.tbxUsername.Location = new System.Drawing.Point(235, 45);
            this.tbxUsername.Name = "tbxUsername";
            this.tbxUsername.Size = new System.Drawing.Size(242, 31);
            this.tbxUsername.TabIndex = 18;
            // 
            // UsersControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Name = "UsersControl";
            this.Size = new System.Drawing.Size(1112, 752);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private DataGridView dgvUsers;
        private TabPage tabPage3;
        private Button btnModify;
        private Button btnDelete;
        private TextBox tbxSearch;
        private Label label1;
        private Button btnSearch;
        private TextBox tbxModifyUserId;
        private TextBox tbxModifyUsername;
        private TextBox tbxModifyEmail;
        private TextBox tbxModifyMiddleName;
        private TextBox tbxModifyFirstName;
        private TextBox tbxNewPassword;
        private TextBox tbxModifyLastName;
        private CheckBox chbxModifyAdmin;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label9;
        private Button btnModifyUser;
        private Button btnCreate;
        private Label label10;
        private Label label11;
        private Label label12;
        private Label label13;
        private Label label14;
        private Label label15;
        private Label label16;
        private CheckBox chbxAdmin;
        private TextBox tbxLastname;
        private TextBox tbxPassword;
        private TextBox tbxFirstname;
        private TextBox tbxMiddlename;
        private TextBox tbxEmail;
        private TextBox tbxUsername;
        private Button btnRefresh;
        private CheckBox chbxActive;
        private Label label17;
    }
}
