using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Common;

namespace testconsole


{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "SERVER=localhost;PORT=3306;DATABASE=fleurs;UID=root;PASSWORD=root;";
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            Console.WriteLine(fidelite(connection, "test2"));
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
    }
}