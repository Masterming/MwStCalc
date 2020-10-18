using System;
using System.IO;
using Microsoft.Data.Sqlite;

namespace SQLConnection
{
    public class SQL
    {
        private readonly SqliteConnection db;

        public SQL(string source, string destination)
        {
            source = $"..\\..\\{source}";
            destination = $"..\\..\\{destination}";

            bool tmp = false;
            if (!File.Exists(destination))
                tmp = true;

            db = new SqliteConnection("Data Source=" + destination);
            db.Open();

            if(tmp)
                InitializeDatabase(source);
        }

        public void InitializeDatabase(string source)
        {
            System.Diagnostics.Trace.WriteLine("Creating Database");
            SqliteCommand command = db.CreateCommand();
            string strCommand = File.ReadAllText(source);
            command.CommandText = strCommand;
            command.ExecuteNonQuery();
        }

        public double GetData(int id)
        {
            SqliteCommand command = db.CreateCommand();
            command.CommandText =
            @"
            SELECT percent
            FROM werte
            WHERE id = $id
            ";
            command.Parameters.AddWithValue("$id", id);
            SqliteDataReader reader = command.ExecuteReader();
            double val = 0.0;
            while (reader.Read())
            {
                val = reader.GetDouble(0);
                System.Diagnostics.Trace.WriteLine($"Reading from db: {val}");
            }
            return val;
        }
    }
}
