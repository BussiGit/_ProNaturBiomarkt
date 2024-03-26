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
    public partial class MainMenuScreen : Form
    {
        public MainMenuScreen()
        {
            InitializeComponent();
        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            //Produkteverwaltung anzeigen

            Produkte productsScreen = new Produkte();
            productsScreen.Show();

            this.Hide();
        }

        private void btnCustomerManagement_Click(object sender, EventArgs e)
        {
            //Kundenverwaltung anzeigen

            Customers customersScreen = new Customers();
            customersScreen.Show();

            this.Hide();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            //Probramm beenden

            this.Close();
            Application.Exit();
        }
    }
}
