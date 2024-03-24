using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProNaturBiomarkt_GmbH
{
    public partial class Customers : Form
    {
        //Variable für die zuletzt ausgewählte ID
        private int lastSelectetCustomerNumber;

        //Connection-String
        private SqlConnection databaseConnection = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=E:\Dokumente II\Visual Studio 2022\SQL Server Management Studio\Pro-Natur-Biomarkt GmbH.mdf; Integrated Security=True; Connect Timeout=30");
        public Customers()
        {
            InitializeComponent();
        }

        private void btnCustomerSave_Click(object sender, EventArgs e)
        {

        }

        private void btnCustomerEdit_Click(object sender, EventArgs e)
        {

        }

        private void btnCustomerClear_Click(object sender, EventArgs e)
        {

        }

        private void btnCustomerDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnCustomerBackToMainMenu_Click(object sender, EventArgs e)
        {
            MainMenuScreen mainMenuScreen = new MainMenuScreen();
            mainMenuScreen.Show();

            this.Hide();
        }
    }
}
