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
    public partial class CommandePerso : Form
    {
        private MySqlConnection connection;
        private string courriel;
        public CommandePerso(MySqlConnection _connection, string _courriel)
        {
            InitializeComponent();
            connection = _connection;
            courriel = _courriel;
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void CommandePerso_Load(object sender, EventArgs e)
        {

        }
    }
}
