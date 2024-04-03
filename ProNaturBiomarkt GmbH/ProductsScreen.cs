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

using System.Data.SQLite;
using Dapper;
using System.Configuration;


namespace ProNaturBiomarkt_GmbH
{
    public partial class Produkte : Form
    {
        //Variable für die zuletzt ausgewählte ID
        private int lastSelectetKey;                   //ID des aktuell ausgewählten Datensatzes
        private string nameTable = "Products";         //Name der Tabelle in der Datenbank

        //Connection-String
//        private SqlConnection databaseConnection = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=E:\Dokumente II\Visual Studio 2022\SQL Server\Pro-Natur-Biomarkt GmbH.mdf; Integrated Security=True; Connect Timeout=30");
        private SqlConnection databaseConnection = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=.\Pro-Natur-Biomarkt GmbH.db; Integrated Security=True; Connect Timeout=30");
        public Produkte()
        {
            InitializeComponent();

            //Produktliste anzeigen
            ShowTable();
        }

        //########################################################################################################################
        //BUTTONS
        private void btnProductSave_Click(object sender, EventArgs e)
        {

            //Überprüfen, ob alle Eingaben vollständig sind
            if(textBoxProductName.Text == "" 
                || textBoxProductBrand.Text == "" 
                || comboBoxProductCategrry.Text == "" 
                || textBoxProductPrice.Text == "")
            {
                MessageBox.Show("Bitte fülle alle Felder aus.",
                    "Hinweis", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //überprüfen, ob der eingegebene Preis in einen Float konvertiert werden kann
            //XXXXXXXXXXXXXXX

            //save product name in database
            string productName = textBoxProductName.Text;
            string productBrand = textBoxProductBrand.Text;
            string productCategorie = comboBoxProductCategrry.Text;
            string productPrice = textBoxProductPrice.Text;

            //In die Datenbank speichern
            string querry = string.Format("insert into {0} values('{1}','{2}','{3}','{4}')", 
                nameTable, productName, productBrand, productCategorie, productPrice);
            ExecuteQuerry(querry);
  
            //Produktliste anzeigen
            ShowTable();
            ClearAllFields();
        }

        private void btnProductEdit_Click(object sender, EventArgs e)
        {
            //Überprüfen, ob ein Produkt ausgewählt wurde
            if (lastSelectetKey == 0)
            {
                MessageBox.Show("Bitte wähle zuerst ein Produkt aus!",
                    "Hinweis", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //überprüfen, ob der eingegebene Preis in einen Float konvertiert werden kann
            //XXXXXXXXXXXXXXX

            string querry = string.Format("update {0} set Name='{1}', Brand='{2}', Category='{3}', Price='{4}' where Id={5}",
                nameTable ,textBoxProductName.Text, textBoxProductBrand.Text, comboBoxProductCategrry.Text, textBoxProductPrice.Text, lastSelectetKey);
            ExecuteQuerry(querry);

            //Produktliste anzeigen
            ShowTable();
        }

        private void btnProductClear_Click(object sender, EventArgs e)
        {
            //Alle Feldinhalte löschen
            ClearAllFields();
        }

        private void btnProductDelete_Click(object sender, EventArgs e)
        {
            //Überprüfen, ob ein Produkt ausgewählt wurde
            if (lastSelectetKey == 0)
            {
                MessageBox.Show("Bitte wähle zuerst ein Produkt aus!",
                    "Hinweis", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            else
            {
            //In die Datenbank "Products" speichern
            string querry = string.Format("delete from {0} where Id={1};", nameTable, lastSelectetKey);
            ExecuteQuerry(querry);
            }

            //Auswahl leeren
            ClearAllFields();

            //Produktliste aktualisieren und anzeigen
            ShowTable();
        }
        private void btnProductBackToMainMenu_Click(object sender, EventArgs e)
        {
            MainMenuScreen mainMenuScreen = new MainMenuScreen();
            mainMenuScreen.Show();

            this.Hide();
        }
        //BUTTONS
        //########################################################################################################################

        //########################################################################################################################
        //DATENBANKHANDLING
        private void ShowTable()
        {
            //##  Datenbanktabelle anzeigen ##

            //Datenbank öffnen
            databaseConnection.Open();

            //Abfrage definieren und übergeben
            string query = string.Format("select * from {0}", nameTable);
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
        //DATENBANKHANDLING
        //########################################################################################################################


        //########################################################################################################################
        //WINDOWHANDLING
        private void productsDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Auswahl einlesen
            lastSelectetKey = (int)productsDGV.SelectedRows[0].Cells[0].Value;
            textBoxProductName.Text = productsDGV.SelectedRows[0].Cells[1].Value.ToString();
            textBoxProductBrand.Text = productsDGV.SelectedRows[0].Cells[2].Value.ToString();
            comboBoxProductCategrry.Text = productsDGV.SelectedRows[0].Cells[3].Value.ToString();
            textBoxProductPrice.Text = productsDGV.SelectedRows[0].Cells[4].Value.ToString();

            lblId.Text = productsDGV.SelectedRows[0].Cells[0].Value.ToString();
        }

        private void ClearAllFields()
        {
            //Auswahlfelder leeren
            textBoxProductName.Text = "";
            textBoxProductBrand.Text = "";
            textBoxProductPrice.Text = "";
            comboBoxProductCategrry.Text = "";
            comboBoxProductCategrry.SelectedItem = null;

            lblId.Text = "";
        }
        //WINDOWHANDLING
        //########################################################################################################################
    }
}
