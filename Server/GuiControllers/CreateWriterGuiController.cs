using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server.GuiControllers
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

            if (Controller.Instance.SaveWriter(writer))
            {
                MessageBox.Show("Pisac uspesno dodat");
                frmCreateWriter?.Dispose();
            }
            else
            {
                MessageBox.Show("Neuspeh");
            }
        }
    }
}
