using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProNaturBiomarkt_GmbH
{
    public partial class Produkte : Form
    {
        //Connection-String
        private SqlConnection databaseConnection = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=E:\Dokumente II\Visual Studio 2022\SQL Server Management Studio\Pro-Natur-Biomarkt GmbH.mdf; Integrated Security=True; Connect Timeout=30");
        public Produkte()
        {
            InitializeComponent();

            //Produktliste anzeigen
            ShowProducts();
        }


        private void btnProductSave_Click(object sender, EventArgs e)
        {
            var pruductName = textBoxProductName.Text;

            //save product name in database

            //Produktliste anzeigen
            ShowProducts();

        }

        private void btnProductEdit_Click(object sender, EventArgs e)
        {

            //Produktliste anzeigen
            ShowProducts();
        }

        private void btnProductClear_Click(object sender, EventArgs e)
        {
            //Alle Feldinhalte löschen
            ClearAllFields();
        }

        private void btnProductDelete_Click(object sender, EventArgs e)
        {
            //Produktliste anzeigen
            ShowProducts();
        }

        private void ShowProducts()
        {
//          ##  Produktliste anzeigen ##

            //Datenbank öffnen
            databaseConnection.Open();

            //Abfrage definieren und übergeben
            string query = "select * from Products";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, databaseConnection);

            //Abfrage starten
            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);

            //Abgefragte Daten der Tabelle 0 in das DataGridView (DGV) eintragen
            productsDGV.DataSource = dataSet.Tables[0];

            //erste Spalte ausblenden
            productsDGV.Columns[0].Visible = false;

            //Datenbank schließen
            databaseConnection.Close();
        }


        private void ClearAllFields()
        {
            //Auswahlfelder leeren
            textBoxProductName.Text = "";
            textBoxProductBrand.Text = "";
            textBoxProductPrice.Text = "";
            comboBoxProductCategrry.Text = "";
            comboBoxProductCategrry.SelectedItem = null;
        }
    }
}
