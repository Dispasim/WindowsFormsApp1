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
    public partial class EspaceAdminClients : Form
    {
        private MySqlConnection connection;
        public EspaceAdminClients(MySqlConnection _connection)
        {
            InitializeComponent();
            connection = _connection;
        }

        private void EspaceAdminClients_Load(object sender, EventArgs e)
        {
            List<string> liste = new List<string>();
            liste = Program.listeCourriel(connection);
            foreach (string s in liste)
            {
                listBox1.Items.Add(s);
            }
        }

        private void Retour_Click(object sender, EventArgs e)
        {
            EspaceAdmin espaceAdmin = new EspaceAdmin(connection);
            espaceAdmin.ShowDialog();
            this.Close();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            List<string> commandes = new List<string>();
            string courriel = listBox1.SelectedItem.ToString();
            label8.Text = Program.recupDonnee(connection, "Nom_Client", "client", "Courriel", courriel);
            label9.Text = Program.recupDonnee(connection, "Prenom_Client", "client", "Courriel", courriel);
            label10.Text = Program.recupDonnee(connection, "Telephone", "client", "Courriel", courriel);
            label11.Text = Program.recupDonnee(connection, "Adresse_Facturation", "client", "Courriel", courriel);
            if (Program.fidelite(connection,courriel) == 1)
            {
                label12.Text = "rien";
            }
            else if (Program.fidelite(connection, courriel) == 0.95F)
            {
                label12.Text = "Bronze";
            }
            else
            {
                label12.Text = "or";
            }
            commandes = Program.listeCommandeClient(connection, courriel);
            foreach (string commande in commandes)
            {
                listBox2.Items.Add(commande);
            }


        }
    }
}
