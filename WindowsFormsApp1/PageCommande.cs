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
    public partial class PageCommande : Form
    {
        private string courriel;
        private MySqlConnection connection;
        public PageCommande(MySqlConnection _connection,string Courriel)
        {
            InitializeComponent();
            courriel = Courriel;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //ConfirmationCommande confirmationCommande = new ConfirmationCommande(Courriel);
        }

        private void PageCommande_Load(object sender, EventArgs e)
        {

        }
    }
}
