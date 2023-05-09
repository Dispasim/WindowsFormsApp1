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
    }
}
