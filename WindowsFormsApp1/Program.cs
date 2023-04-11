using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace WindowsFormsApp1
{
    internal static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            string connectionString = "SERVER=localhost;PORT=3306;DATABASE=fleurs;UID=root;PASSWORD=root;";
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            ///Application.EnableVisualStyles();
            ///Application.SetCompatibleTextRenderingDefault(false);
            ///Application.Run(new PageBienvenue());
            recupDonnee("prix_Bouquet", "bouquet", "Id_Bouquet", "20002");
            MessageBox.Show("fin des opérations");
            
            Console.ReadLine();
        }

        //Méthode qui vérifie si un element existe dans une table
        
        public static bool Existe(string element, string table, string colonne)
        {
            string connectionString = "SERVER=localhost;PORT=3306;DATABASE=fleurs;UID=root;PASSWORD=root;";
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            bool rep = true;
            string query = "SELECT COUNT(*) FROM " + table + " WHERE " + colonne + " = '" + element + "'";
            MySqlCommand command = new MySqlCommand(query, connection);
            int count = Convert.ToInt32(command.ExecuteScalar());
            if (count == 0)
            {
                rep = false;
            }
            connection.Close();
            return rep;

        }
        //pareil que Existe mais vérifie un int
        static bool ExisteInt(MySqlConnection connection, int element, string table, string colonne)
        {
            bool rep = true;
            string query = "SELECT COUNT(*) FROM " + table + " WHERE " + colonne + " = " + element;
            MySqlCommand command = new MySqlCommand(query, connection);
            int count = Convert.ToInt32(command.ExecuteScalar());
            if (count == 0)
            {
                rep = false;
            }
            return rep;
        }

        //méthode qui crée un client dans my sql
        public static void CreationClient(string Courriel, string Mdp, string Nom, string Prenom, string Telephone, string Adresse, string Numero, string dateexpiration, string cryptogramme)
        {
            string connectionString = "SERVER=localhost;PORT=3306;DATABASE=fleurs;UID=root;PASSWORD=root;";
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            string query = "INSERT INTO client(Courriel,Nom_Client,Prenom_Client,Telephone,mdp,Adresse_Livraison,Numero) values('" + Courriel + "','" + Nom + "','" + Prenom + "','" + Telephone + "','" + Mdp + "','" + Adresse + "','" + Numero + "'); INSERT INTO carte_bancaire(Numero,Date_Expiration,Cryptogramme) values('" + Numero + "','" + dateexpiration + "','" + cryptogramme + ");";
            MySqlCommand command = new MySqlCommand(query, connection);
            try
            {
                command.ExecuteNonQuery();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message);
            }
            connection.Close();
        }

        //vérification de si le mot de passe est le bon
        public static bool VerificationMotdepasse(string mdp, string Email)
        {
            string connectionString = "SERVER=localhost;PORT=3306;DATABASE=fleurs;UID=root;PASSWORD=root;";
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            bool rep = false;
            string query = "SELECT mdp FROM client WHERE Courriel = '" + Email + "'";
            MySqlCommand command = new MySqlCommand(query, connection);

            if ((string)command.ExecuteScalar() == mdp)
            {
                rep = true;
            }
            connection.Close();
            return rep;
        }

        //Méthode qui crée une commande
        public static void CreationCommande(string adresse, string message, string Courriel, string id_bouquet)
        {
            string connectionString = "SERVER=localhost;PORT=3306;DATABASE=fleurs;UID=root;PASSWORD=root;";
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            Random random = new Random();
            int numerocommande = random.Next(1000000, 9999999);
            DateTime currentDate = DateTime.Today;
            string date = currentDate.ToString("yyyy-MM-dd");
            string code = "VINV";
            while (ExisteInt(connection, numerocommande, "commande", "Numero_Commande"))
            {
                numerocommande = random.Next(1000000, 9999999);
            }
            string query = "INSERT INTO commande(Numero_Commande,Adresse_Livraison,Message,Date_Commande,Code_Etat,Courriel,Id_Bouquet) values(" + numerocommande.ToString() + ", '" + adresse + "','" + message + "',date('" + date + "'),'" + code + "','" + Courriel + "','" + id_bouquet + "');";
            MySqlCommand command = new MySqlCommand(query, connection);
            
            try
            {
                command.ExecuteNonQuery();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message);
            }
            connection.Close();
        }

        //Méthode pour expoter les clients qui ont commandé plusieurs fois ce mois-ci 
        public static void exportxml()
        {
            string connectionString = "SERVER=localhost;PORT=3306;DATABASE=fleurs;UID=root;PASSWORD=root;";
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            string query = "SELECT client.Courriel FROM fleurs.commande inner join fleurs.client on commande.Courriel = client.Courriel where commande.Date_Commande >= DATE_SUB(NOW(), INTERVAL 1 MONTH) group by commande.Courriel having count(*) > 1;";
            MySqlCommand command = new MySqlCommand(query, connection);

            MySqlDataReader clients = command.ExecuteReader();

            XmlDocument document = new XmlDocument();
            XmlElement rootelement = document.CreateElement("clients");
            document.AppendChild(rootelement);

            while (clients.Read())
            {
                for (int i = 0; i < clients.FieldCount; i++)
                {
                    XmlElement clientElement = document.CreateElement("client");
                    clientElement.SetAttribute("Courriel", clients.GetValue(i).ToString());
                    rootelement.AppendChild(clientElement);

                }
                
            }
            document.Save("C:\\Users\\Eliot\\Downloads\\clients.xml");
            connection.Close();


        }
        //Méthode qui récupère une donnée lié à un élément 
        public static string recupDonnee(string donnee, string table, string colonne, string element)
        {
            string connectionString = "SERVER=localhost;PORT=3306;DATABASE=fleurs;UID=root;PASSWORD=root;";
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            string rep;
            string query = "SELECT " + donnee + " FROM " + table + " WHERE " + colonne + " ='" + element + "';";
            MySqlCommand command = new MySqlCommand(query, connection);
            
            rep = command.ExecuteScalar().ToString();
            




            connection.Close();
            return rep;
        }

    }


}

