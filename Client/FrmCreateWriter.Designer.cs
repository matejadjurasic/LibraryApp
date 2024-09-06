using System.Windows.Forms;

namespace Client
{
    partial class FrmCreateWriter
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
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtSurname = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAddWriter = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtName
            // 
            this.txtName.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.txtName.Location = new System.Drawing.Point(136, 93);
            this.txtName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(176, 29);
            this.txtName.TabIndex = 0;
            // 
            // txtSurname
            // 
            this.txtSurname.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.txtSurname.Location = new System.Drawing.Point(136, 150);
            this.txtSurname.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSurname.Name = "txtSurname";
            this.txtSurname.Size = new System.Drawing.Size(176, 29);
            this.txtSurname.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(93, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 21);
            this.label1.TabIndex = 2;
            this.label1.Text = "Ime:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(63, 154);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 21);
            this.label2.TabIndex = 3;
            this.label2.Text = "Prezime:";
            // 
            // btnAddWriter
            // 
            this.btnAddWriter.Location = new System.Drawing.Point(136, 219);
            this.btnAddWriter.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAddWriter.Name = "btnAddWriter";
            this.btnAddWriter.Size = new System.Drawing.Size(177, 34);
            this.btnAddWriter.TabIndex = 4;
            this.btnAddWriter.Text = "Dodaj";
            this.btnAddWriter.UseVisualStyleBackColor = true;
            // 
            // FrmCreateWriter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MintCream;
            this.ClientSize = new System.Drawing.Size(439, 302);
            this.Controls.Add(this.btnAddWriter);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSurname);
            this.Controls.Add(this.txtName);
            this.Font = new System.Drawing.Font("Komika Axis", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmCreateWriter";
            this.Text = "Dodaj Pisca";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtSurname;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAddWriter;

        public TextBox TxtName { get => txtName; set => txtName = value; }
        public TextBox TxtSurname { get => txtSurname; set => txtSurname = value; }
    }
}