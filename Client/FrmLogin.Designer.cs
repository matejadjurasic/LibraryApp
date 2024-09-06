using System.Windows.Forms;

namespace Client
{
    partial class FrmLogin
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.checkAdmin = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(223, 265);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Korisnicko Ime:";
            // 
            // txtUsername
            // 
            this.txtUsername.BackColor = System.Drawing.Color.SteelBlue;
            this.txtUsername.Location = new System.Drawing.Point(339, 261);
            this.txtUsername.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(175, 29);
            this.txtUsername.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(290, 324);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 21);
            this.label2.TabIndex = 2;
            this.label2.Text = "Sifra:";
            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.Color.SteelBlue;
            this.txtPassword.Location = new System.Drawing.Point(339, 320);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(175, 29);
            this.txtPassword.TabIndex = 3;
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(339, 402);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(176, 32);
            this.btnLogin.TabIndex = 4;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            // 
            // checkAdmin
            // 
            this.checkAdmin.AutoSize = true;
            this.checkAdmin.BackColor = System.Drawing.Color.Transparent;
            this.checkAdmin.Location = new System.Drawing.Point(339, 356);
            this.checkAdmin.Name = "checkAdmin";
            this.checkAdmin.Size = new System.Drawing.Size(76, 25);
            this.checkAdmin.TabIndex = 5;
            this.checkAdmin.Text = "Admin";
            this.checkAdmin.UseVisualStyleBackColor = false;
            // 
            // FrmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Client.Properties.Resources.Default_library_login_page_background_0;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(900, 591);
            this.Controls.Add(this.checkAdmin);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Komika Axis", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmLogin";
            this.Text = "Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnLogin;
        private CheckBox checkAdmin;

        public Label Label1 { get => label1; set => label1 = value; }
        public TextBox TxtUsername { get => txtUsername; set => txtUsername = value; }
        public Label Label2 { get => label2; set => label2 = value; }
        public TextBox TxtPassword { get => txtPassword; set => txtPassword = value; }
        public Button BtnLogin { get => btnLogin; set => btnLogin = value; }
        public CheckBox CheckAdmin { get => checkAdmin; set => checkAdmin = value; }
    }
}