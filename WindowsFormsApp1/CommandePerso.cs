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
            fleurs.Add(10001, Gerbera10001.Text);
            fleurs.Add(10002, Ginger10002.Text);
            fleurs.Add(10003, Glaïeul10003.Text);
            fleurs.Add(10004, Marguerite10004.Text);
            fleurs.Add(10005, RoseRouge10005.Text);
            fleurs.Add(10006, RoseBlanche10006.Text);
            fleurs.Add(10007, Oiseau10007.Text);
            fleurs.Add(10008, Genet10008.Text);
            fleurs.Add(10009, Lys10009.Text);
            fleurs.Add(100010, Alstro100010.Text);
            fleurs.Add(100011, Orchi100011.Text);
            fleurs.Add(100012, verdure100012.Text);
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
