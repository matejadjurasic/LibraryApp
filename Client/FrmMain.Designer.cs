using System.Windows.Forms;

namespace Client
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
            this.lstBooks = new System.Windows.Forms.ListView();
            this.txtSearchTerm = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtLoggedIn = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnLogout = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstBooks
            // 
            this.lstBooks.HideSelection = false;
            this.lstBooks.Location = new System.Drawing.Point(63, 115);
            this.lstBooks.Name = "lstBooks";
            this.lstBooks.Size = new System.Drawing.Size(510, 204);
            this.lstBooks.TabIndex = 1;
            this.lstBooks.UseCompatibleStateImageBehavior = false;
            // 
            // txtSearchTerm
            // 
            this.txtSearchTerm.Location = new System.Drawing.Point(63, 65);
            this.txtSearchTerm.Name = "txtSearchTerm";
            this.txtSearchTerm.Size = new System.Drawing.Size(510, 22);
            this.txtSearchTerm.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(63, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Ulogovani Korisnik:";
            // 
            // txtLoggedIn
            // 
            this.txtLoggedIn.Location = new System.Drawing.Point(192, 13);
            this.txtLoggedIn.Name = "txtLoggedIn";
            this.txtLoggedIn.ReadOnly = true;
            this.txtLoggedIn.Size = new System.Drawing.Size(175, 22);
            this.txtLoggedIn.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(60, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Knjige:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(63, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Pretrazi:";
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(438, 341);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(135, 25);
            this.btnLogout.TabIndex = 7;
            this.btnLogout.Text = "Izloguj se";
            this.btnLogout.UseVisualStyleBackColor = true;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(650, 378);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtLoggedIn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSearchTerm);
            this.Controls.Add(this.lstBooks);
            this.Name = "FrmMain";
            this.Text = "Biblioteka";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ListView lstBooks;
        private TextBox txtSearchTerm;
        private Label label1;
        private TextBox txtLoggedIn;
        private Label label2;
        private Label label3;
        private Button btnLogout;

        public Label Label1 { get => label1; set => label1 = value; }
        public TextBox TxtLoggedIn { get => txtLoggedIn; set => txtLoggedIn = value; }
        public ListView LstBooks { get => lstBooks; set => lstBooks = value; }
        public TextBox TxtSearchTerm { get => txtSearchTerm; set => txtSearchTerm = value; }
    }
}