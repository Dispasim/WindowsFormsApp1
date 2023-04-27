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
    public partial class ConnectionAdmin : Form
    {
        private MySqlConnection connection;
        public ConnectionAdmin(MySqlConnection _connection)
        {
            InitializeComponent();
            connection = _connection;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PageBienvenue pageBienvenue = new PageBienvenue(connection);
            pageBienvenue.ShowDialog();
            this.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "root" && textBox2.Text == "root")
            {
                EspaceAdmin espaceAdmin = new EspaceAdmin(connection);
                espaceAdmin.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Mauvais identifiant ou mot de passe");
            }
        }

        private void ConnectionAdmin_Load(object sender, EventArgs e)
        {

        }
    }
}
