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
    public partial class EspaceAdminClients : Form
    {
        private MySqlConnection connection;
        public EspaceAdminClients(MySqlConnection _connection)
        {
            InitializeComponent();
            connection = _connection;
        }

        private void EspaceAdminClients_Load(object sender, EventArgs e)
        {

        }
    }
}
