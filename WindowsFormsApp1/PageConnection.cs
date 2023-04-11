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
    public partial class PageConnection : Form
    {
        public PageConnection()
        {
            InitializeComponent();
        }

        private void textBox_Email_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void TextBox_Mdp_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            
        }

        private void Boutton_Retour_Click(object sender, EventArgs e)
        {
            PageBienvenue pageBienvenue = new PageBienvenue();
            pageBienvenue.ShowDialog();
            this.Close();
        }

        

        private void button_Valider_Click(object sender, EventArgs e)
        {
            string Mdp = TextBox_Mdp.Text;
            string Email = textBox_Email.Text;
            if (Program.Existe(Email, "client", "Courriel"))
            {
                if(Program.VerificationMotdepasse(Mdp, Email))
                {
                    EspaceClient espaceClient= new EspaceClient(Email);
                    espaceClient.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Email ou mot de passe invalide");
                }
            }
            else
            {
                MessageBox.Show("Email ou mot de passe invalide");
            }

        }
    }
}
