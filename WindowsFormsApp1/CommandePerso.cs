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
        private SortedList<int, string> fleurs = new SortedList<int, string>();
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

        private void button1_Click(object sender, EventArgs e)
        {
            PageCommande Pagecommande = new PageCommande(connection, courriel);
            Pagecommande.ShowDialog();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)

        {
            fleurs.Add(10001, textBox1.Text);
            fleurs.Add(10002, textBox2.Text);
            fleurs.Add(10003, textBox3.Text);
            fleurs.Add(10004, textBox4.Text);
            fleurs.Add(10005, textBox5.Text);
            fleurs.Add(10006, textBox6.Text);
            fleurs.Add(10007, textBox7.Text);
            fleurs.Add(10008, textBox8.Text);
            fleurs.Add(10009, textBox9.Text);
            fleurs.Add(100010, textBox10.Text);
            fleurs.Add(100011, textBox11.Text);
            fleurs.Add(100012, textBox12.Text);
            bool Vase = checkBox1.Checked;
            bool Boite = boite.Checked;
            bool Ruban = checkBox2.Checked;
            Program.CreationCommandePerso(connection, fleurs, Vase, Boite, Ruban, textBox13.Text, richTextBox1.Text, courriel, 30001);
            EspaceClient Espaceclient = new EspaceClient(connection, courriel);
            Espaceclient.ShowDialog();
            this.Close();
            
        }

        private void label19_Click(object sender, EventArgs e)
        {

        }
    }
}
