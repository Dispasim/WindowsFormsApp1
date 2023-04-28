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
    public partial class EspaceAdminStats : Form
    {
        private MySqlConnection connection;
        public EspaceAdminStats(MySqlConnection _connection)
        {
            InitializeComponent();
            connection = _connection;
        }

        private void EspaceAdminStats_Load(object sender, EventArgs e)
        {
            
           
            
            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EspaceAdmin espaceAdmin = new EspaceAdmin(connection);
            espaceAdmin.ShowDialog();
            this.Close();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void Valider_Click(object sender, EventArgs e)
        {
            string element = listBox1.SelectedItem.ToString();
            
            if (element == "Exporter les clients aillant commandé plusieurs fois le mois précédent.")
            {
                Program.exportxml(connection);

            }
            else if (element == "Exporter les clients n'aillant pas commandé depuis plus de 6 mois.")
            {
                Program.exportjson(connection);

            }
            else if (element == "Bouquet standard le plus acheté.")
            {
                MessageBox.Show(Program.meilleurBouquet(connection));

            }
            else if (element == "Meilleur client du mois.")
            {
                MessageBox.Show(Program.meilleurClientMois(connection));

            }
            else if (element == "Meilleur client de l'année.")
            {
                MessageBox.Show(Program.meilleurClientAnnee(connection));

            }
            else if(element == "Prix moyen d'un bouquet acheté.")
            {
                MessageBox.Show(Program.CalculerPrixMoyenBouquetAchete(connection).ToString() + "€");
            }
            else if (element == "Prix moyen d'un bouquet.")
            {
                MessageBox.Show(Program.CalculerPrixMoyenBouquet(connection).ToString()+ "€");
            }
        }
    }
}
