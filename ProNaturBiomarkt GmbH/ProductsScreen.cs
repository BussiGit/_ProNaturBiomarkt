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
        //Variable für die zuletzt ausgewählte ID
        private int lastSelectetProductKey;

        //Connection-String
        private SqlConnection databaseConnection = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=E:\Dokumente II\Visual Studio 2022\SQL Server\Pro-Natur-Biomarkt GmbH.mdf; Integrated Security=True; Connect Timeout=30");
        public Produkte()
        {
            InitializeComponent();

            //Produktliste anzeigen
            ShowProducts();
        }


        private void btnProductSave_Click(object sender, EventArgs e)
        {
            var pruductName = textBoxProductName.Text;

            if(textBoxProductName.Text == "" 
                || textBoxProductBrand.Text == "" 
                || comboBoxProductCategrry.Text == "" 
                || textBoxProductPrice.Text == "")
            {
                MessageBox.Show("Bitte fülle alle Werte aus.");
                return;
            }

            //save product name in database
            string productName = textBoxProductName.Text;
            string productBrand = textBoxProductBrand.Text;
            string productCategorie = comboBoxProductCategrry.Text;
            string productPrice = textBoxProductPrice.Text;

            //In die Datenbank speichern
            string querry = string.Format("insert into Products values('{0}','{1}','{2}','{3}')", productName, productBrand, productCategorie, productPrice);
            ExecuteQuerry(querry);
  
            //Produktliste anzeigen
            ShowProducts();
            ClearAllFields();

        }

        private void btnProductEdit_Click(object sender, EventArgs e)
        {
            if (lastSelectetProductKey == 0)
            {
                MessageBox.Show("Bitte wähle zuerst ein Produkt aus!");
                return;
            }

            string querry = string.Format("update Products set Name='{0}', Brand='{1}', Category='{2}', Price='{3}' where Id={4}"
                ,textBoxProductName.Text, textBoxProductBrand.Text, comboBoxProductCategrry.Text, textBoxProductPrice.Text, lastSelectetProductKey);
            ExecuteQuerry(querry);

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
            if (lastSelectetProductKey == 0)
            {
                MessageBox.Show("Bitte wähle zuerst ein Produkt aus!");
                return;
            }

            else
            {
            //In die Datenbank speichern
            string querry = string.Format("delete from Products where Id={0};", lastSelectetProductKey);
            ExecuteQuerry(querry);
            }

            //Auswahl leeren
            ClearAllFields();

            //Produktliste aktualisieren und anzeigen
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

        private void ExecuteQuerry(string querry)
        {
            //In die Datenbank speichern
            databaseConnection.Open();
            SqlCommand sqlCommand = new SqlCommand(querry, databaseConnection);
            sqlCommand.ExecuteNonQuery();
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

        private void productsDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Auswahl einlesen
            lastSelectetProductKey = (int)productsDGV.SelectedRows[0].Cells[0].Value;
            textBoxProductName.Text = productsDGV.SelectedRows[0].Cells[1].Value.ToString();
            textBoxProductBrand.Text = productsDGV.SelectedRows[0].Cells[2].Value.ToString();
            comboBoxProductCategrry.Text = productsDGV.SelectedRows[0].Cells[3].Value.ToString();
            textBoxProductPrice.Text = productsDGV.SelectedRows[0].Cells[4].Value.ToString();
        }

        private void btnProductBackToMainMenu_Click(object sender, EventArgs e)
        {
            MainMenuScreen mainMenuScreen = new MainMenuScreen();
            mainMenuScreen.Show();

            this.Hide();
        }
    }
}
