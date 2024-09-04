using System.Windows.Forms;

namespace Server
{
    partial class FrmAddConfirmation
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
            this.cboxUser = new System.Windows.Forms.ComboBox();
            this.cboxBook = new System.Windows.Forms.ComboBox();
            this.lstItems = new System.Windows.Forms.ListView();
            this.btnAddItem = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAddConfirmation = new System.Windows.Forms.Button();
            this.numAmount = new System.Windows.Forms.NumericUpDown();
            this.btnRemoveItem = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numAmount)).BeginInit();
            this.SuspendLayout();
            // 
            // cboxUser
            // 
            this.cboxUser.FormattingEnabled = true;
            this.cboxUser.Location = new System.Drawing.Point(117, 43);
            this.cboxUser.Name = "cboxUser";
            this.cboxUser.Size = new System.Drawing.Size(196, 24);
            this.cboxUser.TabIndex = 0;
            // 
            // cboxBook
            // 
            this.cboxBook.FormattingEnabled = true;
            this.cboxBook.Location = new System.Drawing.Point(117, 96);
            this.cboxBook.Name = "cboxBook";
            this.cboxBook.Size = new System.Drawing.Size(196, 24);
            this.cboxBook.TabIndex = 1;
            // 
            // lstItems
            // 
            this.lstItems.HideSelection = false;
            this.lstItems.Location = new System.Drawing.Point(350, 38);
            this.lstItems.Name = "lstItems";
            this.lstItems.Size = new System.Drawing.Size(263, 198);
            this.lstItems.TabIndex = 2;
            this.lstItems.UseCompatibleStateImageBehavior = false;
            // 
            // btnAddItem
            // 
            this.btnAddItem.Location = new System.Drawing.Point(117, 242);
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Size = new System.Drawing.Size(196, 24);
            this.btnAddItem.TabIndex = 4;
            this.btnAddItem.Text = "Dodaj Stavku";
            this.btnAddItem.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(54, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "Korisnik:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(64, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Knjiga:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(54, 148);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "Kolicina:";
            // 
            // btnAddConfirmation
            // 
            this.btnAddConfirmation.Location = new System.Drawing.Point(117, 297);
            this.btnAddConfirmation.Name = "btnAddConfirmation";
            this.btnAddConfirmation.Size = new System.Drawing.Size(496, 24);
            this.btnAddConfirmation.TabIndex = 8;
            this.btnAddConfirmation.Text = "Sacuvaj potvrdu";
            this.btnAddConfirmation.UseVisualStyleBackColor = true;
            // 
            // numAmount
            // 
            this.numAmount.Location = new System.Drawing.Point(117, 146);
            this.numAmount.Name = "numAmount";
            this.numAmount.Size = new System.Drawing.Size(196, 22);
            this.numAmount.TabIndex = 9;
            // 
            // btnRemoveItem
            // 
            this.btnRemoveItem.Location = new System.Drawing.Point(350, 242);
            this.btnRemoveItem.Name = "btnRemoveItem";
            this.btnRemoveItem.Size = new System.Drawing.Size(263, 24);
            this.btnRemoveItem.TabIndex = 10;
            this.btnRemoveItem.Text = "Izbrisi Stavku";
            this.btnRemoveItem.UseVisualStyleBackColor = true;
            // 
            // FrmAddConfirmation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(671, 343);
            this.Controls.Add(this.btnRemoveItem);
            this.Controls.Add(this.numAmount);
            this.Controls.Add(this.btnAddConfirmation);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAddItem);
            this.Controls.Add(this.lstItems);
            this.Controls.Add(this.cboxBook);
            this.Controls.Add(this.cboxUser);
            this.Name = "FrmAddConfirmation";
            this.Text = "Dodaj Potvrdu";
            ((System.ComponentModel.ISupportInitialize)(this.numAmount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboxUser;
        private System.Windows.Forms.ComboBox cboxBook;
        private System.Windows.Forms.ListView lstItems;
        private System.Windows.Forms.Button btnAddItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAddConfirmation;
        private System.Windows.Forms.NumericUpDown numAmount;
        private System.Windows.Forms.Button btnRemoveItem;

        public ComboBox CboxUser { get => cboxUser; set => cboxUser = value; }
        public ComboBox CboxBook { get => cboxBook; set => cboxBook = value; }
        public ListView LstItems { get => lstItems; set => lstItems = value; }
        public NumericUpDown NumAmount { get => numAmount; set => numAmount = value; }
    }
}