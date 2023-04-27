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
        // méthode pour tester si la connection marche : MessageBox.Show(Program.test(connection));
        public static string test(MySqlConnection connection)
        {
            string query = "SELECT Nom_Bouquet FROM bouquet WHERE Id_Bouquet =20001;";
            MySqlCommand command = new MySqlCommand(query, connection);
            return command.ExecuteScalar().ToString();
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
        public static bool ExisteInt(MySqlConnection connection, int element, string table, string colonne)
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
        public static void CreationCommande(MySqlConnection connection, string adresse, string message, string Courriel, int id_bouquet, int id_magasin,DateTime dateLivraison)
        {

            Random random = new Random();
            int numerocommande = random.Next(1000000, 9999999);
            DateTime currentDate = DateTime.Today;
            if ((dateLivraison - currentDate).Days < 1)
            {
                throw new ArgumentException("Date invalide");
            }
            string datelivraison = dateLivraison.ToString("yyyy-MM-dd");
            string date = currentDate.ToString("yyyy-MM-dd");
            string code ;
            if ((dateLivraison - currentDate).Days < 3)
            {
                code = "VINV";
            }
            else
            {
                code = "CC";
            }
            while (ExisteInt(connection, numerocommande, "commande", "Numero_Commande"))
            {
                numerocommande = random.Next(1000000, 9999999);
            }
            string query = "INSERT INTO commande(Numero_Commande,Adresse_Livraison,Message,Date_Commande,Code_Etat,Courriel,Id_Bouquet,Id_Magasin,Date_Livraison) values(" + numerocommande.ToString() + ", '" + adresse + "','" + message + "',date('" + date + "'),'" + code + "','" + Courriel + "'," + id_bouquet + "," + id_magasin + ",date('" + datelivraison + "'));";
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
            command.Dispose();

            return rep;
        }
        //Méthode qui récupère une donnée lié à un élément  où l'élément est un int 
        public static string recupDonneeInt(MySqlConnection connection, string donnee, string table, string colonne, int element)
        {

            string rep;
            string query = "SELECT " + donnee + " FROM " + table + " WHERE " + colonne + " =" + element + ";";
            MySqlCommand command = new MySqlCommand(query, connection);
            rep = command.ExecuteScalar().ToString();

            return rep;
        }

        //Méthode pour exporter en json les clients n'ayant pas commandé depuis plus de 6 mois
        /*
        public static void exportjson(MySqlConnection connection, string outputFilePath)
        {
            // Connexion à la base de données SQL
            string query = "SELECT * FROM client WHERE Courriel NOT IN (SELECT Courriel FROM commande WHERE date_Commande >= DATE_SUB(NOW(), INTERVAL 6 MONTH));";
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
            string json = JsonConvert.SerializeObject(liste_clients, Formatting.Indented);

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

        //prend un paramètre un cloient et renvoie 0.85 s'il a plus de 5 commandes en moyenne, 0.95 s'il en a plus de 1 mais moins de 5 et 1 sinon.
        
        public static float fidelite(MySqlConnection connection, string courriel)
        {
            float rep = 1;
            string query1 = "select round(datediff(cast(NOW() as DATE), MIN(date_Commande)) / 30.5) from commande where commande.Courriel = '" + courriel + "';";
            string query2 = "SELECT COUNT(*) FROM fleurs.commande WHERE commande.courriel = '" + courriel + "';";
            string query3 = "select count(*) from commande where Courriel = '" + courriel + "';";
            MySqlCommand command1 = new MySqlCommand(query1, connection);
            MySqlCommand command2 = new MySqlCommand(query2, connection);
            MySqlCommand command3 = new MySqlCommand(query3, connection);
            if (command3.ExecuteScalar().ToString() == "0")
            {
                return 1;
            }
            object mois = command1.ExecuteScalar();
            object commande = command2.ExecuteScalar();
            float Mois = float.Parse(mois.ToString());
            float Commande = float.Parse(commande.ToString());
            float moyenne = Commande / Mois;
            if (moyenne >= 5)
            {
                rep = 0.85F;
            }
            else if (moyenne >= 1)
            {
                rep = 0.95F;
            }
            return rep;




        }

        //Renvoie la liste de l'adresse de tous les magasins 
        public static List<string> listMagasinAdresse(MySqlConnection connection)
        {
            List<string> rep = new List<string>();
            string query = "SELECT Adresse_magasin FROM magasin";
            MySqlCommand command = new MySqlCommand(query, connection);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                rep.Add(reader.GetString(0));
            }
            reader.Close();
            command.Dispose();
            return rep;
            
        }

        // crée la liaison en un commande eprso et les fleurs 
        public static void LiaisonCommandePerso(MySqlConnection connection, int numCommande, int idFleur, int Nombre)
        {
            string query = "insert into commande_perso(Numero_Commande,Id_Fleur, Nombre) values(" + numCommande + "," + idFleur + "," + Nombre + ");";
            
            MySqlCommand command = new MySqlCommand(query, connection);
            try
            {
                command.ExecuteNonQuery();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.ToString());
            }
            command.Dispose();

        }
        // crée la liaison entre une commande perso et les fleurs sans quatité
        public static void LiaisonCommandePerso(MySqlConnection connection, int numcommande, int idFleur)
        {
            string query = "insert into commande_perso(Numero_Commande,Id_Fleur) values(" + numcommande + "," + idFleur + ");";
            MySqlCommand command = new MySqlCommand(query, connection);
            try
            {
                command.ExecuteNonQuery();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.ToString());
            }
            command.Dispose();
        }
        // donne les accessoires liés à un commande perso
        public static void AccessoireCommande(MySqlConnection connection, int numCommande, bool Vase, bool Boite, bool Ruban)
        {
            string query = "insert into accessoire_commande(Vase,Boite,Ruban,Numero_Commande) values(" + Vase + "," + Boite + "," + Ruban + "," + numCommande + ");";
            MySqlCommand command = new MySqlCommand(query, connection);
            try
            {
                command.ExecuteNonQuery();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.ToString());
            }
            command.Dispose ();
        }
        // crée la commande perso
        public static void CreationCommandePerso(MySqlConnection connection, SortedList<int, string> fleurs, bool Vase, bool Boite, bool Ruban, string adresse, string message, string Courriel, int id_magasin, DateTime dateLivraison, string indication)
        {
            Random random = new Random();
            int numerocommande = random.Next(1000000, 9999999);
            DateTime currentDate = DateTime.Today;
            string indication1 = indication;
            if ((dateLivraison - currentDate).Days < 1)
            {
                throw new ArgumentException("Date invalide");
            }
            string date = currentDate.ToString("yyyy-MM-dd");
            string datelivraison = dateLivraison.ToString("yyyy-MM-dd");
            string code;
            if ((dateLivraison - currentDate).Days < 3)
            {
                code = "CPAV";
            }
            else
            {
                code = "CC";
            }

            

            while (ExisteInt(connection, numerocommande, "commande", "Numero_Commande"))
            {
                numerocommande = random.Next(1000000, 9999999);
            }
            AccessoireCommande(connection, numerocommande, Vase, Boite, Ruban);
            if (indication1 == "")
            {
                indication = "pas d'indication";
            }
            
                foreach (KeyValuePair<int, string> kvp in fleurs)
                {
                    if (kvp.Value != "0")
                    {
                        LiaisonCommandePerso(connection, numerocommande, kvp.Key, int.Parse(kvp.Value));
                    }

                }

            string query = "INSERT INTO commande(Numero_Commande,Adresse_Livraison,Message,Date_Commande,Code_Etat,Courriel,Id_Magasin,Date_Livraison,Commande_Perso,Indication) values(" + numerocommande + ", '" + adresse + "','" + message + "',date('" + date + "'),'" + code + "','" + Courriel + "'," + id_magasin + ",date('" + datelivraison + "')," + true + ",'" + indication + "');";
            
            
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
        // creation commande perso si y'a pas de quantité de fleur 
        public static void creationCommandePerso1(MySqlConnection connection, List<int> fleurs, bool Vase, bool Boite, bool Ruban, string adresse, string message, string Courriel, int id_magasin, DateTime dateLivraison, string indication)
        {
            Random random = new Random();
            int numerocommande = random.Next(1000000, 9999999);
            DateTime currentDate = DateTime.Today;
            string indication1 = indication;
            if ((dateLivraison - currentDate).Days < 1)
            {
                throw new ArgumentException("Date invalide");
            }
            string date = currentDate.ToString("yyyy-MM-dd");
            string datelivraison = dateLivraison.ToString("yyyy-MM-dd");
            string code;
            if ((dateLivraison - currentDate).Days < 3)
            {
                code = "CPAV";
            }
            else
            {
                code = "CC";
            }
            while (ExisteInt(connection, numerocommande, "commande", "Numero_Commande"))
            {
                numerocommande = random.Next(1000000, 9999999);
            }
            AccessoireCommande(connection, numerocommande, Vase, Boite, Ruban);
            if (indication1 == "")
            {
                indication = "pas d'indication";
            }
            foreach (int fleur in fleurs)
            {
                LiaisonCommandePerso1(connection, numerocommande, fleur);
            }
            string query = "INSERT INTO commande(Numero_Commande,Adresse_Livraison,Message,Date_Commande,Code_Etat,Courriel,Id_Magasin,Date_Livraison,Commande_Perso,Indication) values(" + numerocommande + ", '" + adresse + "','" + message + "',date('" + date + "'),'" + code + "','" + Courriel + "'," + id_magasin + ",date('" + datelivraison + "')," + true + ",'" + indication + "');";
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
        public static string SommeFleur(string Gerbera, string Ginger, string Glaieul, string Marguerite, string RoseR, string RoseB, string Oiseau, string Genet, string Lys, string Alstromeria, string Orchidee, string Verdure)
        {
            int rep;
            string rep1;
            int gerbera;
            int.TryParse(Gerbera, out gerbera);
            int ginger;
            int.TryParse(Ginger, out ginger);
            int glaieul;
            int.TryParse(Glaieul, out glaieul);
            int marguerite;
            int.TryParse(Marguerite, out marguerite);
            int roseR;
            int.TryParse(RoseR, out roseR);
            int roseB;
            int.TryParse(RoseB, out roseB);
            int oiseau;
            int.TryParse(Oiseau, out oiseau);
            int genet;
            int.TryParse(Genet, out genet);
            int lys;
            int.TryParse(Lys, out lys);
            int alstromeria;
            int.TryParse(Alstromeria, out alstromeria);
            int orchidee;
            int.TryParse(Orchidee, out orchidee);
            int verdure;
            int.TryParse(Verdure, out verdure);
            rep = gerbera + ginger + glaieul + marguerite + roseR + roseB + oiseau + genet + lys + alstromeria + orchidee + verdure;
            rep1 = rep.ToString();
            return rep1;

        }

        public static float SommePrixFleur(string Gerbera, string Ginger, string Glaieul, string Marguerite, string RoseR, string RoseB, string Oiseau, string Genet, string Lys, string Alstromeria, string Orchidee, string Verdure)
        {
            float rep;
            
            float gerbera;
            float.TryParse(Gerbera, out gerbera);
            float ginger;
            float.TryParse(Ginger, out ginger);
            float glaieul;
            float.TryParse(Glaieul, out glaieul);
            float marguerite;
            float.TryParse(Marguerite, out marguerite);
            float roseR;
            float.TryParse(RoseR, out roseR);
            float roseB;
            float.TryParse(RoseB, out roseB);
            float oiseau;
            float.TryParse(Oiseau, out oiseau);
            float genet;
            float.TryParse(Genet, out genet);
            float lys;
            float.TryParse(Lys, out lys);
            float alstromeria;
            float.TryParse(Alstromeria, out alstromeria);
            float orchidee;
            float.TryParse(Orchidee, out orchidee);
            float verdure;
            float.TryParse(Verdure, out verdure);
            rep = 5 * gerbera + 4 * ginger + glaieul + 2.25F * marguerite + 2.5F * roseR + 5 * roseB + 4 * oiseau + 3 * genet + 4 * lys + 5 * alstromeria + 3.5F * orchidee + verdure;
            
            return rep;

        }

        // format : select donnee from table where colonne = "element"
        public static List<string> listDonnee(MySqlConnection connection, string donnee, string table, string colonne, string element)
        {
            List<string> rep = new List<string>();
            string query = "SELECT " + donnee + " from " + table + " where " + colonne + " = '" + element + "';";
            MySqlCommand command = new MySqlCommand(query, connection);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                rep.Add(reader.GetString(0));
            }
            reader.Close();
            command.Dispose();

            return rep;
        }
        //Donne si une commande est personnalisée
        public static bool estPerso(MySqlConnection connection, string numeroCommande)
        {
            string query = "select Commande_Perso from commande where Numero_Commande = " + numeroCommande + ";";
            MySqlCommand command = new MySqlCommand(query, connection);
            bool rep = (bool)command.ExecuteScalar();
            return rep;
        }
        //donne le bouquet lié à un numéro de commande
        public static string nomBouquetCommande(MySqlConnection connection, string numeroCommande)
        {
            string rep;
            string query = "select Nom_Bouquet from bouquet,commande where commande.Id_Bouquet=bouquet.Id_Bouquet and commande.Numero_Commande = '" + numeroCommande + "';";
            MySqlCommand command = new MySqlCommand(query, connection);
            rep = (string)command.ExecuteScalar();
            return rep;
        }

        public static string adresseMagasinCommande(MySqlConnection connection, string numeroCommande)
        {
            string rep;
            string query = "select Adresse_magasin from magasin,commande where commande.Id_Magasin=magasin.Id_Magasin and commande.Numero_Commande = '" + numeroCommande + "';";
            MySqlCommand command = new MySqlCommand(query, connection);
            rep = (string)command.ExecuteScalar();
            return rep;
        }

        public static List<string> contenuStandard(MySqlConnection connection, string Id_Bouquet)
        {
            List<string> rep = new List<string>();
            string query = "select Nom_Fleur from fleur,compose where fleur.Id_Fleur=compose.Id_Fleur and compose.Id_Bouquet = " + Id_Bouquet + ";";
            
            MySqlCommand command = new MySqlCommand(query, connection);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                rep.Add(reader.GetString(0));
            }
            reader.Close();
            command.Dispose();

            return rep;
        }

        public static List<string> contenuPerso(MySqlConnection connection, string Numero_Commande)
        {
            List<string> rep = new List<string>();
            bool rep1;
            string query = "select Nom_Fleur from fleur, commande_perso where fleur.Id_fleur = commande_perso.Id_Fleur and commande_perso.Numero_Commande = " + Numero_Commande + ";";
            MySqlCommand command = new MySqlCommand(query, connection);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                rep.Add(reader.GetString(0));
            }
            reader.Close();
            command.Dispose();
            query = "select Vase from accessoire_commande where Numero_Commande =" + Numero_Commande + ";";
            MySqlCommand command1 = new MySqlCommand(query, connection);
            rep1 = (bool)command1.ExecuteScalar();

            if (rep1)
            {
                rep.Add("Vase");
            }
            command1.Dispose();

            query = "select Boite from accessoire_commande where Numero_Commande =" + Numero_Commande + ";";
            MySqlCommand command2 = new MySqlCommand(query, connection);
            rep1 = (bool)command2.ExecuteScalar();

            if (rep1)
            {
                rep.Add("Boite");
            }
            command2.Dispose();


            query = "select Ruban from accessoire_commande where Numero_Commande =" + Numero_Commande + ";";
            MySqlCommand command3 = new MySqlCommand(query, connection);
            rep1 = (bool)command3.ExecuteScalar();

            if (rep1)
            {
                rep.Add("Ruban");
            }
            command3.Dispose();
            return rep;
        }
        public static double CalculerPrixMoyenBouquet(MySqlConnection connection)
        {
            double prixMoyen = 0;
            int nombreBouquets = 0;

            string query = "SELECT Prix_Bouquet FROM bouquet";
            MySqlCommand command = new MySqlCommand(query, connection);
            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                double prix = reader.GetDouble("Prix_Bouquet");
                prixMoyen += prix;
                nombreBouquets++;
            }

            reader.Close();
            command.Dispose();

            if (nombreBouquets > 0) // surtout !=0
            {
                    prixMoyen = prixMoyen / nombreBouquets; 
            }         
            return prixMoyen;          
        }

        // à écrire dans le main
        /*
        double prixMoyen = CalculerPrixMoyenBouquet();
        if (nombreBouquets > 0)
        {
            Console.WriteLine("Le prix moyen d'un bouquet est : " + prixMoyen);
        }
        else
        {
            Console.WriteLine("Aucun bouquet trouvé dans la base de données.");
        }
        */

        public static List<string> listeCommande(MySqlConnection connection)
        {
            List<string> rep = new List<string>();
            string query = "select Numero_Commande from commande";
            MySqlCommand command = new MySqlCommand( query, connection);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                rep.Add(reader.GetString(0));
            }
            reader.Close();
            command.Dispose();
            return rep;
        }
        // lie les fleurs et les commandes perso mais sans quantité
        public static void LiaisonCommandePerso1(MySqlConnection connection, int numcommande, int idFleur)
        {
            string query = "insert into commande_perso(Numero_Commande,Id_Fleur) values(" + numcommande + "," + idFleur + ");";
            MySqlCommand command = new MySqlCommand(query, connection);
            try
            {
                command.ExecuteNonQuery();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.ToString());
            }
            command.Dispose();
        }
        // renvoie le nom lié à une commande
        public static string recupNom(MySqlConnection connection, string numcommande)
        {
            string rep;
            string query = "select Nom_Client from client,commande where client.Courriel = commande.Courriel and commande.Numero_Commande = " + numcommande + ";";
            MySqlCommand command = new MySqlCommand(query, connection);
            rep = command.ExecuteScalar().ToString();
            return rep;
        }

        // renvoie le prénom lié à une commande
        public static string recupPrenom(MySqlConnection connection, string numcommande)
        {
            string rep;
            string query = "select Prenom_Client from client,commande where client.Courriel = commande.Courriel and commande.Numero_Commande = " + numcommande + ";";
            MySqlCommand command = new MySqlCommand(query, connection);
            rep = command.ExecuteScalar().ToString();
            return rep;
        }

        //renvoie la liste de tous les Emails des client

        public static List<string> listeCourriel(MySqlConnection connection)
        {
            List<string> rep = new List<string>();
            string query = "select Courriel from client";
            MySqlCommand command = new MySqlCommand(query,connection);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                rep.Add(reader.GetString(0));
            }
            reader.Close();
            command.Dispose();
            return rep;

        }

        //renvoie la liste des commandes d'un client
        public static List<string> listeCommandeClient(MySqlConnection connection, string courriel) 
        {
            List<string> rep = new List<string>();
            string query = "select Numero_Commande from commande where Courriel = '" + courriel +"';";
            MySqlCommand command = new MySqlCommand( query, connection);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                rep.Add(reader.GetString(0));
            }
            reader.Close();
            command.Dispose();
            return rep;
        }

        //Renvoie la liste des noms des fleurs

        public static List<string> listeFleur(MySqlConnection connection)
        {
            List <string> rep = new List<string>();
            string query = "select Nom_Fleur from fleur;";
            MySqlCommand command = new MySqlCommand(query, connection);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                rep.Add(reader.GetString(0));
            }
            reader.Close();
            command.Dispose();
            return rep;
        }











    }
    


}