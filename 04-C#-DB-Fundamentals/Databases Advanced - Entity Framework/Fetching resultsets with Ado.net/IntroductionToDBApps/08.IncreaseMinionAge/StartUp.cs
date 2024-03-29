﻿using _01.InitialSetup;
using System;
using System.Data.SqlClient;
using System.Linq;

namespace _08.IncreaseMinionAge
{
    public class StartUp
    {
        public static void Main()
        {
            SqlConnection connection = new SqlConnection(Configuration.ConnectionString);
            connection.Open();

            int[] ids = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            using (connection)
            {
                foreach (int id in ids)
                {
                    SqlCommand command = new SqlCommand("UPDATE Minions SET Age += 1 WHERE Id = @id", connection);
                    command.Parameters.AddWithValue("@id", id);
                    command.ExecuteNonQuery();
                }

                SqlCommand selectCommand = new SqlCommand("SELECT * FROM Minions", connection);
                SqlDataReader reader = selectCommand.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine($"{reader["Name"]} - {reader["Age"]}");
                }
            }
        }
    }
}
