using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProNaturBiomarkt_GmbH
{
    public partial class LoadingScreen : Form
    {
        private int loadingBarValue;
        public LoadingScreen()
        {
            InitializeComponent();
        }

        private void LoadingScreen_Load(object sender, EventArgs e)
        {
            //STARTPUNKT

            //Timer starten
            loadingBarTimer.Start();
        }

        private void loadingBarTimer_Tick(object sender, EventArgs e)
        {
            loadingBarValue += 10;

            lblLoadingProgress.Text = loadingBarValue.ToString() + "%";
            loadingPrograssBar.Value = loadingBarValue;

            if(loadingBarValue >= loadingPrograssBar.Maximum)
            {
                loadingBarTimer.Stop();
                //hide Loadingscreen
                this.Hide();

                //show main menu screen
                MainMenuScreen mainMenuScreen = new MainMenuScreen();
                mainMenuScreen.Show();
            }
        }
    }
}
