using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class CreationCompte : Form
    {
        private MySqlConnection connection;
        public CreationCompte(MySqlConnection _connection)
        {
            InitializeComponent();
            connection = _connection;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button2retour_Click(object sender, EventArgs e)
        {
            PageBienvenue pageBienvenue = new PageBienvenue(connection);
            pageBienvenue.ShowDialog();
            this.Close();
        }

        private void buttonvalider_Click(object sender, EventArgs e)
        {
            if (Program.Existe(connection, textBoxEmail.Text, "client", "Courriel"))
            {
                MessageBox.Show("Il existe déjà un compte lié à cet email");
            }
            else if (!int.TryParse(textBoxnumero.Text, out _)|| !int.TryParse(textBoxtelephone.Text, out _)||!int.TryParse(textBoxDateexpiration.Text, out _)|| !int.TryParse(textBoxcrypto.Text, out _))
            {
                MessageBox.Show("Le numéro de téléphone, le numéro de carte bleue, la date d'expiration et le cryptogramme doivent etre des nombres entiers.");
            }
            else
            {
                Program.CreationClient(connection, textBoxEmail.Text, textBoxmdp.Text, textBoxnom.Text, textBoxprenom.Text, textBoxtelephone.Text, textBoxadresse.Text, textBoxnumero.Text, textBoxDateexpiration.Text, textBoxcrypto.Text);
                EspaceClient espaceClient = new EspaceClient(connection, textBoxEmail.Text);
                espaceClient.ShowDialog();
                this.Close();
            }
        }

        private void textBoxEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void CreationCompte_Load(object sender, EventArgs e)
        {

        }
    }
}