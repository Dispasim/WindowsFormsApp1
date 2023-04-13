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
    public partial class EspaceClient : Form
    {
        private string courriel;
        public EspaceClient(string Courriel)
        {
            InitializeComponent();
            courriel = Courriel;
        }

        private void EspaceClient_Load(object sender, EventArgs e)
        {

        }

        private void buttondeco_Click(object sender, EventArgs e)
        {
            PageBienvenue pageBienvenue = new PageBienvenue();
            pageBienvenue.ShowDialog();
            this.Close();
        }

        private void buttoncommande_Click(object sender, EventArgs e)
        {
            PageCommande pageCommande = new PageCommande(courriel);
            pageCommande.ShowDialog();
            this.Close();
        }
    }
}
