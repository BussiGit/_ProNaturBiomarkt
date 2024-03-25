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
        private SqlConnection databaseConnection = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=E:\Dokumente II\Visual Studio 2022\SQL Server\Pro-Natur-Biomarkt GmbH.mdf; Integrated Security=True; Connect Timeout=30");
        public Customers()
        {
            InitializeComponent();

            //Produktliste anzeigen
            ShowCustomers();
        }

        private void btnCustomerSave_Click(object sender, EventArgs e)
        {
            if (textBoxCustomerLastName.Text == ""
                || textBoxCustomerPreName.Text == ""
                || textBoxCustomerStreet.Text == ""
                || textBoxCustomerHouseNumber.Text == ""
                || textBoxCustomerPLZ.Text == ""
                || textBoxCustomerCity.Text == "")
            {
                MessageBox.Show("Bitte fülle alle Werte aus.");
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
            string querry = string.Format("insert into Customers values('{0}','{1}','{2}','{3}','{4}','{5}')", 
                customerLastName, customerPreName, customerSteet, customerHouseNumber, customerPLZ, customerCity);
            ExecuteQuerry(querry);

            //Produktliste anzeigen
            ShowCustomers();
            ClearAllFields();
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
            textBoxCustomerLastName.Text = "";
            textBoxCustomerPreName.Text = "";
            textBoxCustomerStreet.Text = "";
            textBoxCustomerHouseNumber.Text = "";
            textBoxCustomerPLZ.Text = "";
            textBoxCustomerCity.Text = "";
        }

        private void btnCustomerEdit_Click(object sender, EventArgs e)
        {
            if (lastSelectetCustomerNumber == 0)
            {
                MessageBox.Show("Bitte wähle zuerst ein Produkt aus!");
                return;
            }

            string querry = string.Format("update Customers set LastName='{0}', PreName='{1}', Street='{2}', HouseNumber='{3}', PLZ='{4}', City='{5}' where CustomerNumber={4}"
                , textBoxCustomerLastName.Text, textBoxCustomerPreName.Text, textBoxCustomerStreet.Text, 
                textBoxCustomerHouseNumber.Text, textBoxCustomerPLZ.Text, textBoxCustomerCity.Text, lastSelectetCustomerNumber);
            ExecuteQuerry(querry);

            //Produktliste anzeigen
            ShowCustomers();
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

        private void ShowCustomers()
        {
//          ##  Produktliste anzeigen ##

            //Datenbank öffnen
            databaseConnection.Open();

            //Abfrage definieren und übergeben
            string query = "select * from Customers";
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

        private void customerDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Auswahl einlesen
            lastSelectetCustomerNumber = (int)customerDGV.SelectedRows[0].Cells[0].Value;
            textBoxCustomerPreName.Text = customerDGV.SelectedRows[0].Cells[1].Value.ToString();
            textBoxCustomerLastName.Text = customerDGV.SelectedRows[0].Cells[2].Value.ToString();
            textBoxCustomerStreet.Text = customerDGV.SelectedRows[0].Cells[3].Value.ToString();
            textBoxCustomerHouseNumber.Text = customerDGV.SelectedRows[0].Cells[4].Value.ToString();
            textBoxCustomerPLZ.Text = customerDGV.SelectedRows[0].Cells[5].Value.ToString();
            textBoxCustomerCity.Text = customerDGV.SelectedRows[0].Cells[6].Value.ToString();

            lblCustomerNumber.Text = customerDGV.SelectedRows[0].Cells[0].Value.ToString();
        }
    }
}
