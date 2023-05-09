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
    public partial class EspaceClient : Form
    {
        private MySqlConnection connection;
        private string courriel;
        public EspaceClient(MySqlConnection _connection, string Courriel)
        {
            InitializeComponent();
            connection = _connection;
            courriel = Courriel;
        }

        private void EspaceClient_Load(object sender, EventArgs e)
        {
            
        }

        private void buttondeco_Click(object sender, EventArgs e)
        {
            this.Hide();
            PageBienvenue pageBienvenue = new PageBienvenue(connection);
            pageBienvenue.ShowDialog();
            this.Close();
        }

        private void buttoncommande_Click(object sender, EventArgs e)
        {
            this.Hide();
            PageCommande pageCommande = new PageCommande(connection, courriel);
            pageCommande.ShowDialog();
            this.Close();
        }

        private void buttonsuivi_Click(object sender, EventArgs e)
        {
            this.Hide();
            SuiviCommande suiviCommande = new SuiviCommande(connection, courriel);
            suiviCommande.ShowDialog();
            this.Close();
        }
    }
}