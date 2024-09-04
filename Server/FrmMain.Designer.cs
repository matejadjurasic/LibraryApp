using System.Windows.Forms;

namespace Server
{
    partial class FrmMain
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
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnViewUser = new System.Windows.Forms.Button();
            this.btnDeleteUser = new System.Windows.Forms.Button();
            this.btnAddNewUser = new System.Windows.Forms.Button();
            this.btnAddWriter = new System.Windows.Forms.Button();
            this.btnAddConfirmation = new System.Windows.Forms.Button();
            this.txtSearchTerm = new System.Windows.Forms.TextBox();
            this.lstUsers = new System.Windows.Forms.ListBox();
            this.lstBooks = new System.Windows.Forms.ListBox();
            this.btnViewBook = new System.Windows.Forms.Button();
            this.btnAddBook = new System.Windows.Forms.Button();
            this.txtSearchUsers = new System.Windows.Forms.TextBox();
            this.btnLogout = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtLoggedIn = new System.Windows.Forms.TextBox();
            this.lstConfirmations = new System.Windows.Forms.ListView();
            this.label5 = new System.Windows.Forms.Label();
            this.btnViewConfirmation = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(18, 455);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(194, 27);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Pokreni";
            this.btnStart.UseVisualStyleBackColor = true;
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(18, 488);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(194, 27);
            this.btnStop.TabIndex = 1;
            this.btnStop.Text = "Zaustavi";
            this.btnStop.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 436);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Serverske Opcije:";
            // 
            // btnViewUser
            // 
            this.btnViewUser.Location = new System.Drawing.Point(491, 280);
            this.btnViewUser.Name = "btnViewUser";
            this.btnViewUser.Size = new System.Drawing.Size(194, 27);
            this.btnViewUser.TabIndex = 4;
            this.btnViewUser.Text = "Izmeni";
            this.btnViewUser.UseVisualStyleBackColor = true;
            // 
            // btnDeleteUser
            // 
            this.btnDeleteUser.Location = new System.Drawing.Point(491, 313);
            this.btnDeleteUser.Name = "btnDeleteUser";
            this.btnDeleteUser.Size = new System.Drawing.Size(194, 27);
            this.btnDeleteUser.TabIndex = 5;
            this.btnDeleteUser.Text = "Izbrisi";
            this.btnDeleteUser.UseVisualStyleBackColor = true;
            // 
            // btnAddNewUser
            // 
            this.btnAddNewUser.Location = new System.Drawing.Point(491, 346);
            this.btnAddNewUser.Name = "btnAddNewUser";
            this.btnAddNewUser.Size = new System.Drawing.Size(194, 27);
            this.btnAddNewUser.TabIndex = 6;
            this.btnAddNewUser.Text = "Dodaj Korisnika";
            this.btnAddNewUser.UseVisualStyleBackColor = true;
            // 
            // btnAddWriter
            // 
            this.btnAddWriter.Location = new System.Drawing.Point(719, 346);
            this.btnAddWriter.Name = "btnAddWriter";
            this.btnAddWriter.Size = new System.Drawing.Size(194, 27);
            this.btnAddWriter.TabIndex = 7;
            this.btnAddWriter.Text = "Dodaj Pisca";
            this.btnAddWriter.UseVisualStyleBackColor = true;
            // 
            // btnAddConfirmation
            // 
            this.btnAddConfirmation.Location = new System.Drawing.Point(234, 346);
            this.btnAddConfirmation.Name = "btnAddConfirmation";
            this.btnAddConfirmation.Size = new System.Drawing.Size(171, 27);
            this.btnAddConfirmation.TabIndex = 8;
            this.btnAddConfirmation.Text = "Napravi Potvrdu";
            this.btnAddConfirmation.UseVisualStyleBackColor = true;
            // 
            // txtSearchTerm
            // 
            this.txtSearchTerm.Location = new System.Drawing.Point(719, 41);
            this.txtSearchTerm.Name = "txtSearchTerm";
            this.txtSearchTerm.Size = new System.Drawing.Size(194, 22);
            this.txtSearchTerm.TabIndex = 10;
            // 
            // lstUsers
            // 
            this.lstUsers.FormattingEnabled = true;
            this.lstUsers.ItemHeight = 16;
            this.lstUsers.Location = new System.Drawing.Point(491, 110);
            this.lstUsers.Name = "lstUsers";
            this.lstUsers.Size = new System.Drawing.Size(194, 164);
            this.lstUsers.TabIndex = 12;
            // 
            // lstBooks
            // 
            this.lstBooks.FormattingEnabled = true;
            this.lstBooks.ItemHeight = 16;
            this.lstBooks.Location = new System.Drawing.Point(719, 110);
            this.lstBooks.Name = "lstBooks";
            this.lstBooks.Size = new System.Drawing.Size(194, 164);
            this.lstBooks.TabIndex = 13;
            // 
            // btnViewBook
            // 
            this.btnViewBook.Location = new System.Drawing.Point(719, 280);
            this.btnViewBook.Name = "btnViewBook";
            this.btnViewBook.Size = new System.Drawing.Size(194, 27);
            this.btnViewBook.TabIndex = 14;
            this.btnViewBook.Text = "Izmeni";
            this.btnViewBook.UseVisualStyleBackColor = true;
            // 
            // btnAddBook
            // 
            this.btnAddBook.Location = new System.Drawing.Point(719, 313);
            this.btnAddBook.Name = "btnAddBook";
            this.btnAddBook.Size = new System.Drawing.Size(194, 27);
            this.btnAddBook.TabIndex = 15;
            this.btnAddBook.Text = "Dodaj Knjigu";
            this.btnAddBook.UseVisualStyleBackColor = true;
            // 
            // txtSearchUsers
            // 
            this.txtSearchUsers.Location = new System.Drawing.Point(491, 41);
            this.txtSearchUsers.Name = "txtSearchUsers";
            this.txtSearchUsers.Size = new System.Drawing.Size(194, 22);
            this.txtSearchUsers.TabIndex = 16;
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(719, 488);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(194, 27);
            this.btnLogout.TabIndex = 17;
            this.btnLogout.Text = "Izloguj se";
            this.btnLogout.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(491, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 16);
            this.label2.TabIndex = 18;
            this.label2.Text = "Korisnici:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(719, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 16);
            this.label3.TabIndex = 19;
            this.label3.Text = "Knjige:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(139, 16);
            this.label4.TabIndex = 20;
            this.label4.Text = "Ulogovani Bibliotekar:";
            // 
            // txtLoggedIn
            // 
            this.txtLoggedIn.Location = new System.Drawing.Point(160, 40);
            this.txtLoggedIn.Name = "txtLoggedIn";
            this.txtLoggedIn.ReadOnly = true;
            this.txtLoggedIn.Size = new System.Drawing.Size(194, 22);
            this.txtLoggedIn.TabIndex = 21;
            // 
            // lstConfirmations
            // 
            this.lstConfirmations.HideSelection = false;
            this.lstConfirmations.Location = new System.Drawing.Point(18, 110);
            this.lstConfirmations.Name = "lstConfirmations";
            this.lstConfirmations.Size = new System.Drawing.Size(387, 230);
            this.lstConfirmations.TabIndex = 22;
            this.lstConfirmations.UseCompatibleStateImageBehavior = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 88);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 16);
            this.label5.TabIndex = 23;
            this.label5.Text = "Potvrde:";
            // 
            // btnViewConfirmation
            // 
            this.btnViewConfirmation.Location = new System.Drawing.Point(18, 346);
            this.btnViewConfirmation.Name = "btnViewConfirmation";
            this.btnViewConfirmation.Size = new System.Drawing.Size(171, 27);
            this.btnViewConfirmation.TabIndex = 24;
            this.btnViewConfirmation.Text = "Izmeni";
            this.btnViewConfirmation.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(488, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 16);
            this.label6.TabIndex = 25;
            this.label6.Text = "Pretrazi:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(716, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 16);
            this.label7.TabIndex = 26;
            this.label7.Text = "Pretrazi:";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(983, 543);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnViewConfirmation);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lstConfirmations);
            this.Controls.Add(this.txtLoggedIn);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.txtSearchUsers);
            this.Controls.Add(this.btnAddBook);
            this.Controls.Add(this.btnViewBook);
            this.Controls.Add(this.lstBooks);
            this.Controls.Add(this.lstUsers);
            this.Controls.Add(this.txtSearchTerm);
            this.Controls.Add(this.btnAddConfirmation);
            this.Controls.Add(this.btnAddWriter);
            this.Controls.Add(this.btnAddNewUser);
            this.Controls.Add(this.btnDeleteUser);
            this.Controls.Add(this.btnViewUser);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.Name = "FrmMain";
            this.Text = "Biblioteka";
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion

        private Button btnStart;
        private Button btnStop;
        private Label label1;
        private Button btnViewUser;
        private Button btnDeleteUser;
        private Button btnAddNewUser;
        private Button btnAddWriter;
        private Button btnAddConfirmation;
        private TextBox txtSearchTerm;
        private ListBox lstUsers;
        private ListBox lstBooks;
        private Button btnViewBook;
        private Button btnAddBook;
        private TextBox txtSearchUsers;
        private Button btnLogout;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox txtLoggedIn;
        private ListView lstConfirmations;
        private Label label5;
        private Button btnViewConfirmation;
        private Label label6;
        private Label label7;

        public ListBox LstUsers { get => lstUsers; set => lstUsers = value; }
        public ListBox LstBooks { get => lstBooks; set => lstBooks = value; }
        public TextBox TxtSearchTerm { get => txtSearchTerm; set => txtSearchTerm = value; }
        public TextBox TxtSearchUsers { get => txtSearchUsers; set => txtSearchUsers = value; }
        public TextBox TxtLoggedIn { get => txtLoggedIn; set => txtLoggedIn = value; }
        public ListView LstConfirmations { get => lstConfirmations; set => lstConfirmations = value; }
        public Button BtnStart { get => btnStart; set => btnStart = value; }
        public Button BtnStop { get => btnStop; set => btnStop = value; }
    }
}