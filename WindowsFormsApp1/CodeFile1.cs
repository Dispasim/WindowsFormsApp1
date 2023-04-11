using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.Crmf;
using System;
//using System.ComponentModel.DataAnnotations;

namespace methodes
{
    internal class program
    {
        static bool Existe(MySqlConnection connection, string element, string table, string colonne)
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
    }
}