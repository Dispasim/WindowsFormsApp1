using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class EspaceAdminCommande : Form
    {
        private MySqlConnection connection;
        public EspaceAdminCommande(MySqlConnection _connection)
        {
            InitializeComponent();
            connection = _connection;
        }

        private void EspaceAdmin_Load(object sender, EventArgs e)
        {
            List<string> commandes = new List<string>();
            commandes = Program.listeCommande(connection);
            foreach (string commande in commandes)
            {
                listBox1.Items.Add(commande);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            PageBienvenue pageBienvenue = new PageBienvenue(connection);
            pageBienvenue.ShowDialog();
            this.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            string numerocommande = listBox1.SelectedItem.ToString();
            List<string> contenu = new List<string>();
            List<string> fleurs = new List<string>();

            if (Program.estPerso(connection, numerocommande))
            {
                label6.Text = "Commande Personnalisée";
            }
            else
            {
                label6.Text = Program.nomBouquetCommande(connection, numerocommande);
            }

            label9.Text = Program.recupPrenom(connection, numerocommande) + " " + Program.recupNom(connection, numerocommande);
            label7.Text = Program.recupDonnee(connection, "Adresse_Livraison", "commande", "Numero_Commande", numerocommande);
            label11.Text = Program.recupDonnee(connection, "date_Commande", "commande", "Numero_Commande", numerocommande);
            label16.Text = Program.recupDonnee(connection, "Date_Livraison", "commande", "Numero_Commande", numerocommande);
            label12.Text = Program.adresseMagasinCommande(connection, numerocommande);
            label18.Text = Program.recupDonnee(connection, "Prix_Commande", "commande", "Numero_Commande", numerocommande) + "€";
            string etat = Program.recupDonnee(connection, "Code_Etat", "commande", "Numero_Commande", numerocommande);
            if (etat == "VINV"|| etat == "CPAV")
            {
                label14.Text = "Vérification de l'inventaire";
            }
            else if (etat == "CC")
            {
                label14.Text = "Commande en stock";
            }
            else if (etat == "CAL")
            {
                label14.Text = "en cours de livraison";
            }
            else
            {
                label14.Text = "Commande livrée";
            }
            if (Program.estPerso(connection, numerocommande))
            {
                contenu = Program.contenuPerso(connection, numerocommande);
                foreach (string element in contenu)
                {
                    if (element != "Vase" && element != "Ruban" && element != "Boite")
                    {
                        listBox2.Items.Add(Program.recupDonnee(connection, "Nombre", "commande_perso", "Id_Fleur", Program.recupDonnee(connection, "Id_Fleur", "fleur", "Nom_Fleur", element)) + " " + element);
                    }
                    else
                    {
                        listBox2.Items.Add(element);
                    }
                }

            }
            else
            {
                fleurs = Program.contenuStandard(connection, Program.recupDonnee(connection, "Id_Bouquet", "commande", "Numero_Commande", numerocommande));
                foreach (string fleur in fleurs)
                {
                    listBox2.Items.Add(fleur);
                }
            }


        }
    }
}
