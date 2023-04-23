using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
//using Newtonsoft.Json;
//using static System.Net.Mime.MediaTypeNames;
//using Formatting = Newtonsoft.Json.Formatting;

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
            //CreationClient("test3", "test3", "test3", "test3", "test3", "test3", "test3", "test3", "test3");
            //CreationCommande("somewhere", "t nul", "test3", 20001, 30001);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new PageBienvenue(connection));
            //recupDonnee("prix_Bouquet", "bouquet", "Id_Bouquet", "20002");
            MessageBox.Show("fin des opérations");


        }

        //Méthode qui vérifie si un element existe dans une table

        public static bool Existe(MySqlConnection connection, string element, string table, string colonne)
        {

            bool rep = true;
            string query = "SELECT COUNT(*) FROM " + table + " WHERE " + colonne + " = '" + element + "'";
            MySqlCommand command = new MySqlCommand(query, connection);
            int count = Convert.ToInt32(command.ExecuteScalar());
            if (count == 0)
            {
                rep = false;
            }

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
        public static void CreationClient(MySqlConnection connection, string Courriel, string Mdp, string Nom, string Prenom, string Telephone, string Adresse, string Numero, string dateexpiration, string cryptogramme)
        {

            string query = "INSERT INTO client(Courriel,Nom_Client,Prenom_Client,Telephone,mdp,Adresse_Facturation,Numero_carte,Date_Expiration,Cryptogramme) values('" + Courriel + "','" + Nom + "','" + Prenom + "','" + Telephone + "','" + Mdp + "','" + Adresse + "','" + Numero + "','" + dateexpiration + "','" + cryptogramme + "');";
            MySqlCommand command = new MySqlCommand(query, connection);
            try
            {
                command.ExecuteNonQuery();
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.Message);
            }

        }

        //vérification de si le mot de passe est le bon
        public static bool VerificationMotdepasse(MySqlConnection connection, string mdp, string Email)
        {

            bool rep = false;
            string query = "SELECT mdp FROM client WHERE Courriel = '" + Email + "'";
            MySqlCommand command = new MySqlCommand(query, connection);

            if ((string)command.ExecuteScalar() == mdp)
            {
                rep = true;
            }

            return rep;
        }

        //Méthode qui crée une commande
        public static void CreationCommande(MySqlConnection connection, string adresse, string message, string Courriel, int id_bouquet, int id_magasin)
        {

            Random random = new Random();
            int numerocommande = random.Next(1000000, 9999999);
            DateTime currentDate = DateTime.Today;
            string date = currentDate.ToString("yyyy-MM-dd");
            string code = "VINV";
            while (ExisteInt(connection, numerocommande, "commande", "Numero_Commande"))
            {
                numerocommande = random.Next(1000000, 9999999);
            }
            string query = "INSERT INTO commande(Numero_Commande,Adresse_Livraison,Message,Date_Commande,Code_Etat,Courriel,Id_Bouquet,Id_Magasin) values(" + numerocommande.ToString() + ", '" + adresse + "','" + message + "',date('" + date + "'),'" + code + "','" + Courriel + "'," + id_bouquet + "," + id_magasin + ");";
            MySqlCommand command = new MySqlCommand(query, connection);

            try
            {
                command.ExecuteNonQuery();
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.Message);
            }

        }

        //Méthode pour expoter les clients qui ont commandé plusieurs fois ce mois-ci 
        public static void exportxml(MySqlConnection connection)
        {

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



        }
        //Méthode qui récupère une donnée lié à un élément 
        public static string recupDonnee(MySqlConnection connection, string donnee, string table, string colonne, string element)
        {

            string rep;
            string query = "SELECT " + donnee + " FROM " + table + " WHERE " + colonne + " ='" + element + "';";
            MySqlCommand command = new MySqlCommand(query, connection);
            rep = command.ExecuteScalar().ToString();

            return rep;
        }

        //Méthode pour exporter en json les clients n'ayant pas commandé depuis plus de 6 mois
        /*
        public static void exportjson(MySqlConnection connection,string outputFilePath, string email)
        {
            // Connexion à la base de données SQL
            
            string query = "SELECT * FROM client WHERE Courriel NOT IN (SELECT Courriel FROM commande WHERE date_Commande > DATE_SUB(NOW(), INTERVAL 6 MONTH)) UNION SELECT * FROM client LEFT JOIN commande ON client.Courriel = commande.Courriel WHERE commande.Numero_Commande IS NULL ";
            MySqlCommand command = new MySqlCommand(query, connection);

            MySqlDataReader clients = command.ExecuteReader();

            // Création d'une liste pour stocker les clients
            List<Client> liste_clients = new List<Client>();

            // Parcours des résultats de la requête SQL
            while (clients.Read())
            {
                Client client = new Client();
                client.Courriel = Convert.ToString(clients["Courriel"]);
                liste_clients.Add(client);
            }

            // Sérialisation de la liste de clients en JSON
            string json = JsonConvert.SerializeObject(clients, Formatting.Indented);

            // Écriture du JSON dans le fichier de sortie
            System.IO.File.WriteAllText(outputFilePath, json);

        }
        */

        public class Client //classe Client pour représenter les informations relatives aux clients qu'on va exporter en JSON
        {
            public string Courriel { get; set; }
            public Client() //constructeur par défaut
            {
            }
            public Client(string courriel)
            {
                Courriel = courriel;
            }
        }



    }


}