using System.Windows.Forms;

namespace Server
{
    partial class FrmConfirmation
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
            this.lstItems = new System.Windows.Forms.ListView();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.txtDate = new System.Windows.Forms.TextBox();
            this.cboxStatus = new System.Windows.Forms.CheckBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtLibrarian = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lstItems
            // 
            this.lstItems.HideSelection = false;
            this.lstItems.Location = new System.Drawing.Point(381, 34);
            this.lstItems.Name = "lstItems";
            this.lstItems.Size = new System.Drawing.Size(305, 235);
            this.lstItems.TabIndex = 0;
            this.lstItems.UseCompatibleStateImageBehavior = false;
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(119, 97);
            this.txtUser.Name = "txtUser";
            this.txtUser.ReadOnly = true;
            this.txtUser.Size = new System.Drawing.Size(179, 22);
            this.txtUser.TabIndex = 2;
            // 
            // txtDate
            // 
            this.txtDate.Location = new System.Drawing.Point(119, 167);
            this.txtDate.Name = "txtDate";
            this.txtDate.ReadOnly = true;
            this.txtDate.Size = new System.Drawing.Size(179, 22);
            this.txtDate.TabIndex = 3;
            // 
            // cboxStatus
            // 
            this.cboxStatus.AutoSize = true;
            this.cboxStatus.Location = new System.Drawing.Point(119, 231);
            this.cboxStatus.Name = "cboxStatus";
            this.cboxStatus.Size = new System.Drawing.Size(80, 20);
            this.cboxStatus.TabIndex = 4;
            this.cboxStatus.Text = "Vraceno";
            this.cboxStatus.UseVisualStyleBackColor = true;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(119, 285);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(179, 28);
            this.btnUpdate.TabIndex = 6;
            this.btnUpdate.Text = "Azuriraj";
            this.btnUpdate.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "Bibliotekar:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(56, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "Korisnik:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 170);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 16);
            this.label3.TabIndex = 9;
            this.label3.Text = "Datum Izdavanja:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(378, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 16);
            this.label4.TabIndex = 10;
            this.label4.Text = "Stavke:";
            // 
            // txtLibrarian
            // 
            this.txtLibrarian.Location = new System.Drawing.Point(119, 31);
            this.txtLibrarian.Name = "txtLibrarian";
            this.txtLibrarian.ReadOnly = true;
            this.txtLibrarian.Size = new System.Drawing.Size(179, 22);
            this.txtLibrarian.TabIndex = 11;
            // 
            // FrmConfirmation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(739, 359);
            this.Controls.Add(this.txtLibrarian);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.cboxStatus);
            this.Controls.Add(this.txtDate);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.lstItems);
            this.Name = "FrmConfirmation";
            this.Text = "Izmeni Potvrdu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lstItems;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.TextBox txtDate;
        private System.Windows.Forms.CheckBox cboxStatus;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtLibrarian;

        public ListView LstItems { get => lstItems; set => lstItems = value; }
        public TextBox TxtUser { get => txtUser; set => txtUser = value; }
        public TextBox TxtDate { get => txtDate; set => txtDate = value; }
        public CheckBox CboxStatus { get => cboxStatus; set => cboxStatus = value; }
        public TextBox TxtLibrarian { get => txtLibrarian; set => txtLibrarian = value; }
        public Button BtnUpdate { get => btnUpdate; set => btnUpdate = value; }
    }
}