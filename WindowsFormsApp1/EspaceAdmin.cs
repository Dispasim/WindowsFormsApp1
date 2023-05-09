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
    public partial class EspaceAdmin : Form
    {
        private MySqlConnection connection;
        public EspaceAdmin(MySqlConnection _connection)
        {
            InitializeComponent();
            connection = _connection;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            EspaceAdminCommande adminCommande = new EspaceAdminCommande(connection);
            adminCommande.ShowDialog();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            EspaceAdminClients adminClients = new EspaceAdminClients(connection);
            adminClients.ShowDialog();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            EspaceAdminStocks adminStocks = new EspaceAdminStocks(connection);
            adminStocks.ShowDialog();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            EspaceAdminStats adminStocks = new EspaceAdminStats(connection);
            adminStocks.ShowDialog();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            PageBienvenue pageBienvenue = new PageBienvenue(connection);
            pageBienvenue.ShowDialog();
            this.Close();
        }

        private void EspaceAdmin_Load(object sender, EventArgs e)
        {

        }
    }
}
