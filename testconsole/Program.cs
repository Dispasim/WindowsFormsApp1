using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Common;
using System.Diagnostics;

namespace testconsole


{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "SERVER=localhost;PORT=3306;DATABASE=fleurs;UID=root;PASSWORD=root;";
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            SortedList<int,int> liste = new SortedList<int,int>();
            
            




            Console.WriteLine("fin des opérations");
            connection.Close();
        }
        //prend un paramètre un cloient et renvoie 0.85 s'il a plus de 5 commandes en moyenne, 0.95 s'il en a plus de 1 mais moins de 5 et 1 sinon
        public static float fidelite(MySqlConnection connection, string courriel)
        {
            float rep = 1;
            string query1 = "select round(datediff(cast(NOW() as DATE), MIN(date_Commande)) / 30.5) from commande where commande.Courriel = '" + courriel + "';";
            string query2 = "SELECT COUNT(*) FROM fleurs.commande WHERE commande.courriel = '" + courriel + "';";
            MySqlCommand command1 = new MySqlCommand(query1, connection);
            MySqlCommand command2 = new MySqlCommand(query2, connection);

            object mois  = command1.ExecuteScalar();
            object commande = command2.ExecuteScalar();
            float Mois = float.Parse(mois.ToString())+1;
            float Commande = float.Parse(commande.ToString());
            float moyenne = Commande / Mois;
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

        //public static void CreationCommandePerso(MySqlConnection connection, int[] nombrefleur, )
    }
}