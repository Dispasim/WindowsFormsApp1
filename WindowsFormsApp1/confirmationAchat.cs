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
    public partial class confirmationAchat : Form
    {
        private MySqlConnection connection;
        private string email;
        private int id;
        public confirmationAchat(MySqlConnection _connection, string Email, int idBouquet)
        {
            InitializeComponent();
            email = Email;
            id = idBouquet;
            connection = _connection;

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}