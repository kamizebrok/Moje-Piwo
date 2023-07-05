using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moje_Piwo.Model
{
    static class DataAccess
    {
        static SqliteConnection conn = new SqliteConnection(@"Data Source=C:\Users\Dell\source\repos\Moje-Piwo\Moje Piwo\Moje Piwo\Moje Piwo");

        private static void ReadData(SqliteConnection conn)
        {
            SqliteDataReader reader;
            SqliteCommand command;

            command = conn.CreateCommand();
            command.CommandText = "SELECT * FROM beer";
            reader = command.ExecuteReader();

            while (reader.Read())
            {
                long id = (long)reader["id_beer"];
                string name = (string)reader["Name"];
                string type = (string)reader["Type"];
                string voltage = (string)reader["Voltage"];
                string extract = (string)reader["Extract"];
                string description = (string)reader["Description"];
                string price = (string)reader["Price"];
                string brewery = (string)reader["Brewery"];
                string country = (string)reader["Country"];
                string concern = (string)reader["Concern"];
                string favorite = (string)reader["Favorite"];
                string CsID = (string)reader["CsID"];
                string rating = (string)reader["Rating"];
                Console.WriteLine($"{id} {name} {type}");
            }
        }

        public static void ReadData()
        {
            try
            {
                conn.Open();
                ReadData(conn);
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
