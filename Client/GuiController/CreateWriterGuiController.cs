using Common.Communication;
using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.GuiController
{
    public class CreateWriterGuiController
    {
        private static CreateWriterGuiController instance;
        public static CreateWriterGuiController Instance
        {
            get
            {
                if (instance == null) instance = new CreateWriterGuiController();
                return instance;
            }
        }
        private FrmCreateWriter frmCreateWriter;

        internal void ShowFrmCreateWriter()
        {
            frmCreateWriter = new FrmCreateWriter();
            frmCreateWriter.AutoSize = true;
            frmCreateWriter.ShowDialog();
        }

        internal void AddWriter(object sender, EventArgs e)
        {
            Pisac writer = new Pisac
            {
                Ime = frmCreateWriter.TxtName.Text,
                Prezime = frmCreateWriter.TxtSurname.Text
            };

            Response r = Communication.Instance.SaveWriter(writer);
            if (r.Exception == null && (bool)r.Result == true)
            {
                MessageBox.Show("Pisac uspesno dodat", "Uspeh", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MainGuiController.Instance.RefreshUserTable();
                frmCreateWriter.Dispose();
            }
            else
            {
                MessageBox.Show("Greska pri dodavanju", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
