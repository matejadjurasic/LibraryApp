using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.GuiControllers
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
        private FrmMain frmMain;
        private Bibliotekar bibliotekar;

        internal void ShowFrmMain(Bibliotekar bibliotekar)
        {
            frmMain = new FrmMain();
            this.bibliotekar = bibliotekar;
            frmMain.AutoSize = true;
            frmMain.Label1.Text = bibliotekar.Ime;
            frmMain.ShowDialog();
        }
    }
}
