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
            connection = _connection;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            confirmationAchat confirmationachat = new confirmationAchat(connection,courriel, 20001);
            confirmationachat.ShowDialog();
            this.Close();
        }

        private void PageCommande_Load(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            confirmationAchat confirmationachat = new confirmationAchat(connection, courriel, 20004);
            confirmationachat.ShowDialog();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            confirmationAchat confirmationachat = new confirmationAchat(connection, courriel, 20005);
            confirmationachat.ShowDialog();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            confirmationAchat confirmationachat = new confirmationAchat(connection, courriel, 20002);
            confirmationachat.ShowDialog();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            confirmationAchat confirmationachat = new confirmationAchat(connection, courriel, 20003);
            confirmationachat.ShowDialog();
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            CommandePerso commandePerso = new CommandePerso(connection, courriel);
            commandePerso.ShowDialog();
            this.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            EspaceClient Espaceclient = new EspaceClient(connection, courriel);
            Espaceclient.ShowDialog();
            this.Close();
        }
    }
}
