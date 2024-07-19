using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.GuiController
{
    public class MainGuiController
    {
        private static MainGuiController instance;
        public static MainGuiController Instance 
        { 
            get 
            {
                if (instance == null) instance = new MainGuiController();
                return instance; 
            } 
        }
        public MainGuiController()
        {

        }

        private FrmMain frmMain;
        private Korisnik korisnik;

        internal void ShowFrmMain(Korisnik k)
        {
            frmMain = new FrmMain();
            korisnik = k;
            frmMain.AutoSize = true;
            frmMain.Label1.Text = k.Ime;
            frmMain.ShowDialog();
        }
    }
}
