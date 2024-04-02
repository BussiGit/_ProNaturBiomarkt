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
        private int lastSelectetKey;                    //ID des aktuell ausgewählten Datensatzes
        private string nameTable = "Customers";         //Name der Tabelle in der Datenbank

        //Connection-String
        private SqlConnection databaseConnection = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=E:\Dokumente II\Visual Studio 2022\SQL Server\Pro-Natur-Biomarkt GmbH.mdf; Integrated Security=True; Connect Timeout=30");
        //private SqlConnection databaseConnection = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=.\Pro-Natur-Biomarkt GmbH.mdf; Integrated Security=True; Connect Timeout=30");

        public Customers()
        {
            InitializeComponent();

            //Kundenliste anzeigen
            ShowTable();
        }

        //########################################################################################################################
        //BUTTONS
        private void btnCustomerSave_Click(object sender, EventArgs e)
        {
            if (textBoxCustomerLastName.Text == ""
                || textBoxCustomerPreName.Text == ""
                || textBoxCustomerStreet.Text == ""
                || textBoxCustomerHouseNumber.Text == ""
                || textBoxCustomerPLZ.Text == ""
                || textBoxCustomerCity.Text == "")
            {
                MessageBox.Show("Bitte fülle alle Felder aus.",
                    "Hinweis", MessageBoxButtons.OK, MessageBoxIcon.Information); 
                return;
            }

            //save product name in database
            string customerLastName = textBoxCustomerLastName.Text;
            string customerPreName = textBoxCustomerPreName.Text;
            string customerSteet = textBoxCustomerStreet.Text;
            string customerHouseNumber = textBoxCustomerHouseNumber.Text;
            string customerPLZ = textBoxCustomerPLZ.Text;
            string customerCity = textBoxCustomerCity.Text;

            //In die Datenbank speichern
            string querry = string.Format("insert into {0} values('{1}','{2}','{3}','{4}','{5}','{6}')", 
                nameTable, customerLastName, customerPreName, customerSteet, customerHouseNumber, customerPLZ, customerCity);
            ExecuteQuerry(querry);

            //Kundenliste anzeigen
            ShowTable();
            ClearAllFields();
        }

        private void btnCustomerEdit_Click(object sender, EventArgs e)
        {
            if (lastSelectetKey == 0)
            {
                MessageBox.Show("Bitte wähle zuerst einen Kunden aus!",
                    "Hinweis", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string querry = string.Format("update {0} set LastName='{1}', PreName='{2}', Street='{3}', HouseNumber='{4}', PLZ='{5}', City='{6}' where CustomerNumber={7}",
                nameTable, textBoxCustomerLastName.Text, textBoxCustomerPreName.Text, textBoxCustomerStreet.Text,
                textBoxCustomerHouseNumber.Text, textBoxCustomerPLZ.Text, textBoxCustomerCity.Text, lastSelectetKey);
            ExecuteQuerry(querry);

            //Kundenliste anzeigen
            ShowTable();
        }

        private void btnCustomerClear_Click(object sender, EventArgs e)
        {
            //Alle Feldinhalte löschen
            ClearAllFields();
        }

        private void btnCustomerDelete_Click(object sender, EventArgs e)
        {
            if (lastSelectetKey == 0)
            {
                MessageBox.Show("Bitte wähle zuerst ein Kunden aus!",
                    "Hinweis", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            else
            {
                //In die Datenbank speichern
                string querry = string.Format("delete from {0} where CustomerNumber={1};", nameTable, lastSelectetKey);
                ExecuteQuerry(querry);
            }

            //Auswahl leeren
            ClearAllFields();

            //Kundenliste aktualisieren und anzeigen
            ShowTable();
        }

        private void btnCustomerBackToMainMenu_Click(object sender, EventArgs e)
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
            customerDGV.DataSource = dataSet.Tables[0];

            //erste Spalte ausblenden
            customerDGV.Columns[0].Visible = false;

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
        private void customerDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Auswahl einlesen
            lastSelectetKey = (int)customerDGV.SelectedRows[0].Cells[0].Value;
            textBoxCustomerPreName.Text = customerDGV.SelectedRows[0].Cells[1].Value.ToString();
            textBoxCustomerLastName.Text = customerDGV.SelectedRows[0].Cells[2].Value.ToString();
            textBoxCustomerStreet.Text = customerDGV.SelectedRows[0].Cells[3].Value.ToString();
            textBoxCustomerHouseNumber.Text = customerDGV.SelectedRows[0].Cells[4].Value.ToString();
            textBoxCustomerPLZ.Text = customerDGV.SelectedRows[0].Cells[5].Value.ToString();
            textBoxCustomerCity.Text = customerDGV.SelectedRows[0].Cells[6].Value.ToString();

            lblCustomerNumber.Text = customerDGV.SelectedRows[0].Cells[0].Value.ToString();
        }

        private void ClearAllFields()
        {
            //Auswahlfelder leeren
            textBoxCustomerLastName.Text = "";
            textBoxCustomerPreName.Text = "";
            textBoxCustomerStreet.Text = "";
            textBoxCustomerHouseNumber.Text = "";
            textBoxCustomerPLZ.Text = "";
            textBoxCustomerCity.Text = "";
            lblCustomerNumber.Text = "";
        }
        //WINDOWHANDLING
        //########################################################################################################################
    }
}
