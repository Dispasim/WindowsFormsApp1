using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Common;
using Newtonsoft.Json;
using Org.BouncyCastle.Ocsp;
using System.Diagnostics;
using System.Drawing.Printing;
using System.Reflection.Metadata;
using System.Xml;
using Formatting = Newtonsoft.Json.Formatting;

namespace testconsole


{
    internal class ProgramTest
    {
        static void Main(string[] args)
        {
            string connectionString = "SERVER=localhost;PORT=3306;DATABASE=fleurs;UID=root;PASSWORD=root;";
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            //SortedList<int,int> liste = new SortedList<int,int>();
            Console.WriteLine(float.Parse("90,2"));
            


            List<string> fleurs = fleurSupMoy(connection);
            afficherListe(fleurs);


            Console.WriteLine("fin des opérations");
            connection.Close();
        }

        private static void afficherListe(Func<MySqlConnection, List<string>> fleurSupMoy)
        {
            throw new NotImplementedException();
        }

        //prend un paramètre un cloient et renvoie 0.85 s'il a plus de 5 commandes en moyenne, 0.95 s'il en a plus de 1 mais moins de 5 et 1 sinon
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
            object mois  = command1.ExecuteScalar();
            object commande = command2.ExecuteScalar();
            
            float Mois = float.Parse(mois.ToString());
            float Commande = float.Parse(commande.ToString());
            float moyenne = Commande / Mois;
            Console.WriteLine(moyenne);
            if (moyenne >= 5) {
                rep = 0.85F;
            }
            else if(moyenne>= 1) {
                rep = 0.95F;
            }
            return rep; 




        }

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
                Console.WriteLine(e.ToString());
            }

        }

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
                Console.WriteLine(e.ToString());
            }

        }
        public static string recupDonneeInt(MySqlConnection connection, string donnee, string table, string colonne, int element)
        {

            string rep;
            string query = "SELECT " + donnee + " FROM " + table + " WHERE " + colonne + " =" + element + ";";
            MySqlCommand command = new MySqlCommand(query, connection);
            rep = command.ExecuteScalar().ToString();

            return rep;
        }

        public static string test(MySqlConnection connection)
        {
            string query = "SELECT Nom_Bouquet FROM bouquet WHERE Id_Bouquet =20001;";
            MySqlCommand command = new MySqlCommand(query, connection);
            return command.ExecuteScalar().ToString();
        }

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

        public static void LiaisonCommandePerso(MySqlConnection connection, int numCommande, int idFleur, int Nombre)
        {
            string query = "insert into commande_perso(Numero_Commande,Id_Fleur, Nombre) values(" + numCommande + "," + idFleur + "," + Nombre+");";
            MySqlCommand command = new MySqlCommand( query, connection);
            try
            {
                command.ExecuteNonQuery();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.ToString());
            }

        }

        

        public static void AccessoireCommande(MySqlConnection connection, int numCommande, bool Vase, bool Boite, bool Ruban)
        {
            string query = "insert into accessoire_commande(Vase,Boite,Ruban,Numero_Commande) values(" + Vase + "," + Boite + "," + Ruban +"," + numCommande+");";
            MySqlCommand command = new MySqlCommand(query, connection);
            try
            {
                command.ExecuteNonQuery();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public static void CreationCommandePerso(MySqlConnection connection, SortedList<int, string> fleurs, bool Vase, bool Boite, bool Ruban, string adresse, string message, string Courriel, int id_magasin)
        {
            Random random = new Random();
            int numerocommande = random.Next(1000000, 9999999);
            DateTime currentDate = DateTime.Today;
            string date = currentDate.ToString("yyyy-MM-dd");
            string code = "CPAV";
            while (ExisteInt(connection, numerocommande, "commande", "Numero_Commande"))
            {
                numerocommande = random.Next(1000000, 9999999);
            }
            string query = "INSERT INTO commande(Numero_Commande,Adresse_Livraison,Message,Date_Commande,Code_Etat,Courriel,Id_Magasin,Commande_Perso) values(" + numerocommande + ", '" + adresse + "','" + message + "',date('" + date + "'),'" + code + "','" + Courriel  + "," + id_magasin +","+ true + ");";
            foreach (KeyValuePair<int, string> kvp in fleurs)
            {
                if (kvp.Value != "0")
                {
                    LiaisonCommandePerso(connection, numerocommande, kvp.Key, int.Parse(kvp.Value));
                }

            }
            AccessoireCommande(connection, numerocommande, Vase, Boite, Ruban);

            

        }

        public static int SommeFleur(string Gerbera, string Ginger, string Glaieul, string Marguerite, string RoseR, string RoseB, string Oiseau, string Genet, string Lys, string Alstromeria, string Orchidee, string Verdure)
        {
            int rep;
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
            int.TryParse (Genet, out genet);
            int lys;
            int.TryParse(Lys, out lys);
            int alstromeria;
            int.TryParse(Alstromeria, out alstromeria);
            int orchidee;
            int.TryParse(Orchidee, out  orchidee);
            int verdure;
            int.TryParse(Verdure, out verdure);
            rep = gerbera + ginger + glaieul + marguerite + roseR + roseB + oiseau + genet + lys + alstromeria + orchidee + verdure;
            return rep;

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
            rep = 5*gerbera + 4*ginger + glaieul + 2.25F*marguerite + 2.5F * roseR + 5*roseB + 4*oiseau + 3*genet + 4*lys + 5*alstromeria + 3.5F*orchidee + verdure;
            return rep;

        }
        // format : select donnee from table where colonne = "element"
        public static List<string> listDonnee(MySqlConnection connection, string donnee, string table, string colonne,string element)
        {
            List<string> rep = new List<string>();
            string query = "SELECT " + donnee + "from " + table + " where" + colonne + " = '" + element + "';";
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
        
        public static bool estPerso(MySqlConnection connection, string numeroCommande)
        {
            string query = "select Commande_Perso from commande where Numero_Commande = " + numeroCommande + ";";
            MySqlCommand command = new MySqlCommand( query, connection);
            bool rep = (bool)command.ExecuteScalar();
            return rep;
        }

        public static string nomBouquetCommande(MySqlConnection connection, string numeroCommande)
        {
            string rep;
            string query = "select Nom_Bouquet from bouquet,commande where commande.Id_Bouquet=bouquet.Id_Bouquet and commande.Numero_Commande = '" + numeroCommande + "';";
            Console.WriteLine(query);
            MySqlCommand command = new MySqlCommand( query, connection);
            rep = (string)command.ExecuteScalar();
            return rep;
        }

        public static List<string> contenuStandard(MySqlConnection connection,string Id_Bouquet)
        {
            List<string> rep = new List<string>();
            string query = "select Nom_Fleur from fleur,compose where fleur.Id_Fleur=compose.Id_fleur and compose.Id_Bouquet = " + Id_Bouquet + ";";
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


        public static void exportjson(MySqlConnection connection)
        {
            
            string query = "SELECT * FROM client WHERE Courriel NOT IN (SELECT Courriel FROM commande WHERE date_Commande >= DATE_SUB(NOW(), INTERVAL 6 MONTH));";
            MySqlCommand command = new MySqlCommand(query, connection);

            MySqlDataReader clients = command.ExecuteReader();
            List<Client> liste_clients = new List<Client>();
            while (clients.Read())
            {
                Client client = new Client();
                client.Courriel = Convert.ToString(clients["Courriel"]);
                liste_clients.Add(client);
            }
            string json = JsonConvert.SerializeObject(liste_clients, Formatting.Indented);

            string outputFilePath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Downloads\\myJsonFile.json";

            System.IO.File.WriteAllText(outputFilePath, json);
            
        }


    
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
            document.Save(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Downloads\\clients.xml");



        }
        /*
        public static string meilleurClientMois(MySqlConnection connection)
        {
            string rep;
            string query = "select Courriel from commande WHERE month(date_Commande) = month(CURDATE()) group by courriel order by count(*) desc limit 1;";
            MySqlCommand command = new MySqlCommand(query, connection);
            rep = command.ExecuteScalar().ToString();
            return rep;
        }
        */
        public static string meilleurClientAnnee(MySqlConnection connection)
        {
            string rep;
            string query = "select Courriel from commande WHERE year(date_Commande) = year(CURDATE()) group by courriel order by count(*) desc limit 1;";
            MySqlCommand command = new MySqlCommand(query, connection);
            rep = command.ExecuteScalar().ToString();
            return rep;
        }

        public static string meilleurBouquet(MySqlConnection connection)
        {
            string rep;
            string query = "select Id_Bouquet from commande where Id_Bouquet is not null group by Id_Bouquet order by count(*) desc limit 1;";
            MySqlCommand command = new MySqlCommand(query, connection);
            rep = command.ExecuteScalar().ToString();
            return rep;
        }
        public static int nombreCommandeTotal(MySqlConnection connection) //UNION
        {
            int nbC;
            string query = "SELECT COUNT(*) FROM commande UNION SELECT COUNT(*) FROM commande_perso GROUP BY Numero_Commande;";

            MySqlCommand command = new MySqlCommand(query, connection);
            nbC = int.Parse(command.ExecuteScalar().ToString());


            return nbC;
        }

        public static int chiffredaffaire(MySqlConnection connection) //Syncronisée
        {
            int CA;
            string query = "SELECT SUM(Prix_Commande) FROM commande WHERE Prix_Commande IS NOT NULL";

            MySqlCommand command = new MySqlCommand(query, connection);
            CA = Convert.ToInt32(command.ExecuteScalar());

            return CA;
        }
       
        public static List<string> fleurSupMoy(MySqlConnection connection)
        {
            List<string> fleurs = new List<string>();
            string query = "SELECT nom_Fleur FROM fleur WHERE prix_Fleur > (SELECT AVG(prix_Fleur) FROM fleur)"; // requête syncronisée

            MySqlCommand command = new MySqlCommand(query, connection);

            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                fleurs.Add(reader.GetString(0));
            }
            reader.Close();
            command.Dispose();
            return fleurs;
        }
        
        public static void afficherListe(List<string> liste)
        {
            foreach (string element in liste)
            {
                Console.WriteLine(element);
            }
        }
        









    }
}