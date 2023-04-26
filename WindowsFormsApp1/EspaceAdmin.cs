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
            EspaceAdminCommande adminCommande = new EspaceAdminCommande(connection);
            adminCommande.ShowDialog();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            EspaceAdminClients adminClients = new EspaceAdminClients(connection);
            adminClients.ShowDialog();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            EspaceAdminStocks adminStocks = new EspaceAdminStocks(connection);
            adminStocks.ShowDialog();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            EspaceAdminStats adminStocks = new EspaceAdminStats(connection);
            adminStocks.ShowDialog();
            this.Close();
        }
    }
}
