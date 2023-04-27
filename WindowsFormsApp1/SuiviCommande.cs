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
    public partial class SuiviCommande : Form
    {
        private MySqlConnection connection;
        private string courriel;
        public SuiviCommande(MySqlConnection _connection, string _courriel)
        {
            InitializeComponent();
            connection = _connection;
            courriel = _courriel;
        }

        private void SuiviCommande_Load(object sender, EventArgs e)
        {
            List<string> liste = new List<string>();
            liste = Program.listDonnee(connection, "Numero_Commande","commande","Courriel", courriel);
            foreach (string s in liste)
            {
                listBox1.Items.Add(s);
            }
            

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            List<string> contenu = new List<string>();
            List<string> fleurs = new List<string>();
            string numerocommande = listBox1.SelectedItem.ToString();
            
            
            if (Program.estPerso(connection, numerocommande))
            {
                label14.Text = "Commande Personnalisée";
            }
            else
            {
                label14.Text = Program.nomBouquetCommande(connection, numerocommande);
            }
            label5.Text = Program.recupDonnee(connection, "Adresse_Livraison", "commande", "Numero_Commande", numerocommande);
            label7.Text = Program.recupDonnee(connection, "Message", "commande", "Numero_Commande", numerocommande);
            label9.Text = Program.recupDonnee(connection, "Date_Commande", "commande", "Numero_Commande", numerocommande);
            label11.Text = Program.adresseMagasinCommande(connection, numerocommande);
            label16.Text = Program.recupDonnee(connection, "Date_Livraison", "commande", "Numero_Commande", numerocommande);
            string etat = Program.recupDonnee(connection,"Code_Etat", "commande", "Numero_Commande", numerocommande);
            if (etat == "VINV")
            {
                label13.Text = "Vérification de l'inventaire";
            }
            else if(etat == "cc")
            {
                label13.Text = "Commande en stock";
            }
            else if (etat == "CPAV")
            {
                label13.Text = "Vérification de l'inventaire";
            }
            else if (etat == "CAL")
            {
                label13.Text = "en cours de livraison";
            }
            else
            {
                label13.Text = "Commande livrée";
            }
            if (Program.estPerso(connection, numerocommande))
            {
                contenu = Program.contenuPerso(connection, numerocommande);
                foreach (string element in contenu)
                {
                    if (element != "Vase" && element != "Ruban" && element != "Boite")
                    {
                        listBox2.Items.Add(Program.recupDonnee(connection,"Nombre","commande_perso","Id_Fleur",Program.recupDonnee(connection,"Id_Fleur","fleur","Nom_Fleur",element)) + " " + element);
                    }
                    else
                    {
                        listBox2.Items.Add(element);
                    }
                }

            }
            else
            {
                fleurs = Program.contenuStandard(connection, Program.recupDonnee(connection,"Id_Bouquet","commande","Numero_Commande", numerocommande)) ;
                foreach(string fleur in fleurs)
                {
                    listBox2.Items.Add(fleur);
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            EspaceClient espaceClient = new EspaceClient(connection, courriel);
            espaceClient.ShowDialog();
            this.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }
    }
}
