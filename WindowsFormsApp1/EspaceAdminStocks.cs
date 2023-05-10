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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1
{
    public partial class EspaceAdminStocks : Form
    {
        private MySqlConnection connection;
        public EspaceAdminStocks(MySqlConnection _connection)
        {
            InitializeComponent();
            connection = _connection;
        }

        private void EspaceAdminStocks_Load(object sender, EventArgs e)
        {
            List<string> fleurs = new List<string>();
            fleurs = Program.listeFleur(connection);
            foreach (string fleur in fleurs)
            {
                listBox1.Items.Add(fleur);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            EspaceAdmin espaceAdmin = new EspaceAdmin(connection);
            espaceAdmin.ShowDialog();
            this.Close();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string fleur = listBox1.SelectedItem as string;
            
            label3.Text = Program.recupDonnee(connection, "Stock", "fleur", "Nom_Fleur", fleur);
            label5.Text = Program.recupDonnee(connection, "Prix_Fleur", "fleur", "Nom_Fleur", fleur) + " €";
            label7.Text = Program.recupDonnee(connection, "Disponibilite", "fleur", "Nom_Fleur", fleur);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            if (listBox1.SelectedIndex == -1)
            {
                MessageBox.Show("selectionner une fleur");
            }
            else if (!int.TryParse(textBox1.Text, out _))
            {
                MessageBox.Show("entrer une valeur valide");
            }
            else if (int.Parse(textBox1.Text) < 0)
            {
                MessageBox.Show("entrer une valeur positive");
            }
            else
            {
                string fleur = listBox1.SelectedItem as string;
                int somme = int.Parse(Program.recupDonnee(connection, "Stock", "fleur", "Nom_Fleur", fleur)) + int.Parse(textBox1.Text);
                Program.modifStock(connection, fleur, somme);
                label3.Text = Program.recupDonnee(connection, "Stock", "fleur", "Nom_Fleur", fleur);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            if (listBox1.SelectedIndex == -1)
            {
                MessageBox.Show("selectionner une fleur");
            }
            if (!int.TryParse(textBox1.Text, out _))
            {
                MessageBox.Show("entrer une valeur valide");
            }
            else if (int.Parse(textBox1.Text) < 0)
            {
                MessageBox.Show("entrer une valeur positive");
            }
            else
            {
                string fleur = listBox1.SelectedItem as string;
                int somme = int.Parse(Program.recupDonnee(connection, "Stock", "fleur", "Nom_Fleur", fleur)) - int.Parse(textBox1.Text);
                if (somme >= 0)
                {
                    Program.modifStock(connection, fleur, somme);
                    label3.Text = Program.recupDonnee(connection, "Stock", "fleur", "Nom_Fleur", fleur);
                }
                else
                {
                    MessageBox.Show("impossible");
                }
            }
        }
    }
}
