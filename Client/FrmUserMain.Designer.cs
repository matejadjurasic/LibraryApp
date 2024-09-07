using System.Windows.Forms;

namespace Client
{
    partial class FrmUserMain
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
            this.btnDetails = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstBooks
            // 
            this.lstBooks.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.lstBooks.HideSelection = false;
            this.lstBooks.Location = new System.Drawing.Point(71, 151);
            this.lstBooks.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lstBooks.Name = "lstBooks";
            this.lstBooks.Size = new System.Drawing.Size(573, 266);
            this.lstBooks.TabIndex = 1;
            this.lstBooks.UseCompatibleStateImageBehavior = false;
            // 
            // txtSearchTerm
            // 
            this.txtSearchTerm.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.txtSearchTerm.Location = new System.Drawing.Point(71, 85);
            this.txtSearchTerm.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSearchTerm.Name = "txtSearchTerm";
            this.txtSearchTerm.Size = new System.Drawing.Size(573, 29);
            this.txtSearchTerm.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(71, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 21);
            this.label1.TabIndex = 3;
            this.label1.Text = "Ulogovani Korisnik:";
            // 
            // txtLoggedIn
            // 
            this.txtLoggedIn.Location = new System.Drawing.Point(216, 17);
            this.txtLoggedIn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtLoggedIn.Name = "txtLoggedIn";
            this.txtLoggedIn.ReadOnly = true;
            this.txtLoggedIn.Size = new System.Drawing.Size(196, 29);
            this.txtLoggedIn.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(68, 126);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 21);
            this.label2.TabIndex = 5;
            this.label2.Text = "Knjige:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(71, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 21);
            this.label3.TabIndex = 6;
            this.label3.Text = "Pretrazi:";
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(493, 448);
            this.btnLogout.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(152, 33);
            this.btnLogout.TabIndex = 7;
            this.btnLogout.Text = "Izloguj se";
            this.btnLogout.UseVisualStyleBackColor = true;
            // 
            // btnDetails
            // 
            this.btnDetails.Location = new System.Drawing.Point(71, 448);
            this.btnDetails.Name = "btnDetails";
            this.btnDetails.Size = new System.Drawing.Size(151, 33);
            this.btnDetails.TabIndex = 8;
            this.btnDetails.Text = "Detalji";
            this.btnDetails.UseVisualStyleBackColor = true;
            // 
            // FrmUserMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MintCream;
            this.ClientSize = new System.Drawing.Size(731, 496);
            this.Controls.Add(this.btnDetails);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtLoggedIn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSearchTerm);
            this.Controls.Add(this.lstBooks);
            this.Font = new System.Drawing.Font("Komika Axis", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmUserMain";
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
        private Button btnDetails;

        public Label Label1 { get => label1; set => label1 = value; }
        public TextBox TxtLoggedIn { get => txtLoggedIn; set => txtLoggedIn = value; }
        public ListView LstBooks { get => lstBooks; set => lstBooks = value; }
        public TextBox TxtSearchTerm { get => txtSearchTerm; set => txtSearchTerm = value; }
    }
}