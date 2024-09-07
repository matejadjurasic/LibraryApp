using System.Windows.Forms;

namespace Client
{
    partial class FrmUserBook
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
            this.label2 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtNumAvailableCopies = new System.Windows.Forms.TextBox();
            this.lstWriters = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(133, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Knjiga";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 139);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(179, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "Broj dostupnih kopija";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(197, 66);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(162, 29);
            this.txtName.TabIndex = 2;
            // 
            // txtNumAvailableCopies
            // 
            this.txtNumAvailableCopies.Location = new System.Drawing.Point(197, 136);
            this.txtNumAvailableCopies.Name = "txtNumAvailableCopies";
            this.txtNumAvailableCopies.Size = new System.Drawing.Size(162, 29);
            this.txtNumAvailableCopies.TabIndex = 3;
            // 
            // lstWriters
            // 
            this.lstWriters.FormattingEnabled = true;
            this.lstWriters.ItemHeight = 21;
            this.lstWriters.Location = new System.Drawing.Point(402, 66);
            this.lstWriters.Name = "lstWriters";
            this.lstWriters.Size = new System.Drawing.Size(179, 172);
            this.lstWriters.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(398, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 21);
            this.label3.TabIndex = 5;
            this.label3.Text = "Pisci";
            // 
            // FrmUserBook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MintCream;
            this.ClientSize = new System.Drawing.Size(625, 291);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lstWriters);
            this.Controls.Add(this.txtNumAvailableCopies);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Komika Axis", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmUserBook";
            this.Text = "Knjiga";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtNumAvailableCopies;
        private System.Windows.Forms.ListBox lstWriters;
        private System.Windows.Forms.Label label3;

        public TextBox TxtName { get => txtName; set => txtName = value; }
        public TextBox TxtNumAvailableCopies { get => txtNumAvailableCopies; set => txtNumAvailableCopies = value; }
        public ListBox LstWriters { get => lstWriters; set => lstWriters = value; }
    }
}