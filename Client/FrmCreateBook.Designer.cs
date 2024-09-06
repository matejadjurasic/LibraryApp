using System.Windows.Forms;

namespace Client
{
    partial class FrmCreateBook
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
            this.numCopies = new System.Windows.Forms.NumericUpDown();
            this.numAvailableCopies = new System.Windows.Forms.NumericUpDown();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lstWriters = new System.Windows.Forms.ListBox();
            this.btnAddBook = new System.Windows.Forms.Button();
            this.cboxWriters = new System.Windows.Forms.ComboBox();
            this.btnAddWriter = new System.Windows.Forms.Button();
            this.btnDeleteWriter = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numCopies)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAvailableCopies)).BeginInit();
            this.SuspendLayout();
            // 
            // numCopies
            // 
            this.numCopies.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.numCopies.Location = new System.Drawing.Point(190, 136);
            this.numCopies.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.numCopies.Name = "numCopies";
            this.numCopies.Size = new System.Drawing.Size(182, 29);
            this.numCopies.TabIndex = 0;
            // 
            // numAvailableCopies
            // 
            this.numAvailableCopies.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.numAvailableCopies.Location = new System.Drawing.Point(190, 230);
            this.numAvailableCopies.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.numAvailableCopies.Name = "numAvailableCopies";
            this.numAvailableCopies.Size = new System.Drawing.Size(182, 29);
            this.numAvailableCopies.TabIndex = 1;
            // 
            // txtName
            // 
            this.txtName.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.txtName.Location = new System.Drawing.Point(190, 43);
            this.txtName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(182, 29);
            this.txtName.TabIndex = 2;
            // 
            // lstWriters
            // 
            this.lstWriters.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.lstWriters.FormattingEnabled = true;
            this.lstWriters.ItemHeight = 21;
            this.lstWriters.Location = new System.Drawing.Point(422, 43);
            this.lstWriters.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lstWriters.Name = "lstWriters";
            this.lstWriters.Size = new System.Drawing.Size(192, 214);
            this.lstWriters.TabIndex = 3;
            // 
            // btnAddBook
            // 
            this.btnAddBook.Location = new System.Drawing.Point(35, 345);
            this.btnAddBook.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAddBook.Name = "btnAddBook";
            this.btnAddBook.Size = new System.Drawing.Size(338, 32);
            this.btnAddBook.TabIndex = 5;
            this.btnAddBook.Text = "Dodaj Knjigu";
            this.btnAddBook.UseVisualStyleBackColor = true;
            // 
            // cboxWriters
            // 
            this.cboxWriters.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.cboxWriters.FormattingEnabled = true;
            this.cboxWriters.Location = new System.Drawing.Point(422, 266);
            this.cboxWriters.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboxWriters.Name = "cboxWriters";
            this.cboxWriters.Size = new System.Drawing.Size(192, 29);
            this.cboxWriters.TabIndex = 6;
            // 
            // btnAddWriter
            // 
            this.btnAddWriter.Location = new System.Drawing.Point(422, 306);
            this.btnAddWriter.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAddWriter.Name = "btnAddWriter";
            this.btnAddWriter.Size = new System.Drawing.Size(192, 32);
            this.btnAddWriter.TabIndex = 7;
            this.btnAddWriter.Text = "Dodaj Pisca";
            this.btnAddWriter.UseVisualStyleBackColor = true;
            // 
            // btnDeleteWriter
            // 
            this.btnDeleteWriter.Location = new System.Drawing.Point(422, 345);
            this.btnDeleteWriter.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnDeleteWriter.Name = "btnDeleteWriter";
            this.btnDeleteWriter.Size = new System.Drawing.Size(192, 32);
            this.btnDeleteWriter.TabIndex = 8;
            this.btnDeleteWriter.Text = "Izbrisi Pisca";
            this.btnDeleteWriter.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(147, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 21);
            this.label1.TabIndex = 9;
            this.label1.Text = "Ime:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(99, 139);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 21);
            this.label2.TabIndex = 10;
            this.label2.Text = "Broj Kopija:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 232);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(179, 21);
            this.label3.TabIndex = 11;
            this.label3.Text = "Broj Dostupnih Kopija";
            // 
            // FrmCreateBook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MintCream;
            this.ClientSize = new System.Drawing.Size(649, 406);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDeleteWriter);
            this.Controls.Add(this.btnAddWriter);
            this.Controls.Add(this.cboxWriters);
            this.Controls.Add(this.btnAddBook);
            this.Controls.Add(this.lstWriters);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.numAvailableCopies);
            this.Controls.Add(this.numCopies);
            this.Font = new System.Drawing.Font("Komika Title - Axis", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmCreateBook";
            this.Text = "Dodaj Knjigu";
            ((System.ComponentModel.ISupportInitialize)(this.numCopies)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAvailableCopies)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numCopies;
        private System.Windows.Forms.NumericUpDown numAvailableCopies;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.ListBox lstWriters;
        private System.Windows.Forms.Button btnAddBook;
        private System.Windows.Forms.ComboBox cboxWriters;
        private System.Windows.Forms.Button btnAddWriter;
        private System.Windows.Forms.Button btnDeleteWriter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;

        public ComboBox CboxWriters { get => cboxWriters; set => cboxWriters = value; }
        public NumericUpDown NumCopies { get => numCopies; set => numCopies = value; }
        public NumericUpDown NumAvailableCopies { get => numAvailableCopies; set => numAvailableCopies = value; }
        public TextBox TxtName { get => txtName; set => txtName = value; }
        public ListBox LstWriters { get => lstWriters; set => lstWriters = value; }
    }
}