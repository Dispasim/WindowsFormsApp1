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
    }
}
