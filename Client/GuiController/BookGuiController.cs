﻿using Common.Communication;
using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.GuiController
{
    public class BookGuiController
    {
        private static BookGuiController instance;
        public static BookGuiController Instance
        {
            get
            {
                if (instance == null) instance = new BookGuiController();
                return instance;
            }
        }
        private FrmBook frmBook;
        private Knjiga book;

        internal void ShowFrmBook(Knjiga book)
        {
            Response r = Communication.Instance.GetBook(book);
            if (r.Exception == null && r.Result != null)
            {
                this.book = (Knjiga)r.Result;
            }
            frmBook = new FrmBook();
            frmBook.AutoSize = true;
            frmBook.TxtName.Text = book.Ime;
            frmBook.NumAvailableCopies.Value = book.BrojDostupnihKopija;
            frmBook.NumCopies.Value = book.BrojKopija;
            Response r2 = Communication.Instance.GetAllAuthors();
            if (r2.Exception == null && r2.Result != null)
            {
                frmBook.CboxWriters.DataSource = (List<Pisac>)r2.Result;
                RefreshWriters();
            }
            MessageBox.Show("Sistem je ucitao podatke o izabranoј knjizi", "Uspeh", MessageBoxButtons.OK, MessageBoxIcon.Information);
            frmBook.ShowDialog();
        }


        internal void AddWriter(object sender, EventArgs e)
        {
            if(frmBook.CboxWriters.SelectedIndex != -1)
            {
                Pisac selectedWriter = frmBook.CboxWriters.SelectedItem as Pisac;
                if (!book.Pisci.Contains(selectedWriter))
                {
                    book.Pisci.Add(selectedWriter);
                    RefreshWriters();
                }
                else
                {
                    MessageBox.Show("Vec ste dodali ovog pisca.", "Duplikat", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        internal void DeleteWriter(object sender, EventArgs e)
        {
            if (frmBook.LstWriters.SelectedIndex != -1)
            {
                Pisac selectedWriter = frmBook.LstWriters.SelectedItem as Pisac;
                book.Pisci.Remove(selectedWriter);
                RefreshWriters();
            }
        }

        public void RefreshWriters()
        {
            frmBook.LstWriters.DataSource = null;
            frmBook.LstWriters.DataSource = book.Pisci;
        }

        internal void UpdateBook(object sender, EventArgs e)
        {
            if (frmBook.TxtName.Text.Length < 1)
            {
                MessageBox.Show("Ime mora imati barem jedno slovo", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if ((int)frmBook.NumAvailableCopies.Value > (int)frmBook.NumCopies.Value)
            {
                MessageBox.Show("Broj dostupnih kopija mora biti manji ili jednak od ukupnih kopija", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            book.Ime = frmBook.TxtName.Text;
            book.BrojKopija = (int)frmBook.NumCopies.Value;
            book.BrojDostupnihKopija = (int)frmBook.NumAvailableCopies.Value;

            Response r = Communication.Instance.UpdateBook(book);
            if (r.Exception == null && (bool)r.Result == true)
            {
                MessageBox.Show("Sistem je zapamtio nove podatke o knjizi", "Uspeh", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MainGuiController.Instance.RefreshBookTable();
                book.Pisci.Clear();
                frmBook.Dispose();
            }
            else
            {
                MessageBox.Show("Sistem ne moze da zapamti knjigu", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
