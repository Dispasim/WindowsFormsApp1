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
    public partial class CreationCompte : Form
    {
        public CreationCompte()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button2retour_Click(object sender, EventArgs e)
        {
            PageBienvenue pageBienvenue = new PageBienvenue();
            pageBienvenue.ShowDialog();
            this.Close();
        }

        private void buttonvalider_Click(object sender, EventArgs e)
        {
            if (Program.Existe(textBoxEmail.Text, "client", "Courriel"))
            {
                MessageBox.Show("Il existe déjà un compte lié à cte email");
            }
            else
            {
                Program.CreationClient(textBoxEmail.Text,textBoxmdp.Text,textBoxnom.Text,textBoxprenom.Text,textBoxnumero.Text,textBoxadresse.Text,textBoxnumero.Text,textBoxDateexpiration.Text,textBoxcrypto.Text);
                EspaceClient espaceClient = new EspaceClient(textBoxEmail.Text);
                espaceClient.ShowDialog();
                this.Close();
            }
        }

        private void textBoxEmail_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
