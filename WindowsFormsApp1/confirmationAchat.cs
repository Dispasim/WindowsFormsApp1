﻿using methodes;
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
using System.Xml.Linq;

namespace WindowsFormsApp1
{
    public partial class confirmationAchat : Form
    {
        private MySqlConnection connection;
        private string email;
        private int id;
        private int magasin;
        private DateTime datelivraison;
        
        
        public confirmationAchat(MySqlConnection _connection, string Email, int idBouquet)
        {
            InitializeComponent();
            email = Email;
            id = idBouquet;
            connection = _connection;


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            List<string> fleurs = new List<string>();
            fleurs = Program.contenuStandard(connection, id.ToString());
            foreach (string fleur in fleurs)
            {
                listBox1.Items.Add(fleur);
            }
            labelnom.Text = Program.recupDonneeInt(connection, "Nom_Bouquet", "bouquet", "Id_Bouquet", id);
            labelprix.Text = (float.Parse(Program.recupDonneeInt(connection, "Prix_Bouquet", "bouquet", "Id_Bouquet", id)) * Program.fidelite(connection, email)).ToString() + '€';
            labeloccasion.Text = Program.recupDonneeInt(connection, "Categorie", "bouquet", "Id_Bouquet", id);
            checkedListBox1.Items.Clear();
            List<string> liste = new List<string>();
            liste = Program.listMagasinAdresse(connection);
            foreach (string s in liste)
            {
                checkedListBox1.Items.Add(s, false);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {


        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        

        private void checkedListBox1_ItemCheck_1(object sender, ItemCheckEventArgs e)
        {
            // Désactiver toutes les cases à cocher sauf celle sélectionnée
            for (int ix = 0; ix < checkedListBox1.Items.Count; ++ix)
                if (ix != e.Index) checkedListBox1.SetItemChecked(ix, false);
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            PageCommande pageCommande = new PageCommande(connection, email);
            pageCommande.ShowDialog();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DateTime dateLivraison = dateTimePicker1.Value;
            if ((dateLivraison - DateTime.Today).Days < 1)
            {
                MessageBox.Show("Merci de séléectionner une date valide");
            }
            else
            {
                string texteElement = "";
                foreach (object itemChecked in checkedListBox1.CheckedItems)
                {
                    texteElement = itemChecked.ToString();


                }
                if (texteElement == "")
                {
                    MessageBox.Show("Merci de sélectionner un magasin");
                }
                else
                {
                    magasin = int.Parse(Program.recupDonnee(connection, "Id_Magasin", "magasin", "Adresse_magasin", texteElement));
                    string prix = (float.Parse(Program.recupDonneeInt(connection, "Prix_Bouquet", "bouquet", "Id_Bouquet", id)) * Program.fidelite(connection, email)).ToString();

                    Program.CreationCommande(connection, textBox1.Text, richTextBox1.Text, email, id, magasin,dateLivraison,prix);
                    this.Hide();
                    EspaceClient espaceClient = new EspaceClient(connection, email);
                    espaceClient.ShowDialog();
                    this.Close();
                }
            }


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}