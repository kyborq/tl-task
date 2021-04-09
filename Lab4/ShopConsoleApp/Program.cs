using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ShopConsoleApp
{
    class Program
    {
        private static string _connectionString = @"Server=DESKTOP-OD7BNPM\SQLEXPRESS;Database=Shop;Trusted_Connection=True;";

        static void Main(string[] args)
        {
            string command = args[0];

            if (command == "read")
            {
                List<Customer> customers = ReadCustomers();
                foreach (Customer customer in customers)
                {
                    Console.WriteLine(customer.Name + " " + customer.City);
                }
            }

            if (command == "insert")
            {
                int createdCustomerId = InsertCustomer("Иванов Иван Иванович", "Москва");
                Console.WriteLine("Created customer: " + createdCustomerId);
            }

            if (command == "update")
            {
                UpdateCustomer(4, "Иванов Иван Иванович", "Йошкар-Ола");
            }
        }

        private static List<Customer> ReadCustomers()
        {
            List<Customer> customers = new List<Customer>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText =
                        @"SELECT
                            [CustomerId],
                            [Name],
                            [City]
                        FROM Customer";

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var customer = new Customer
                            {
                                CustomerId = Convert.ToInt32(reader["CustomerId"]),
                                Name = Convert.ToString(reader["Name"]),
                                City = Convert.ToString(reader["City"])
                            };
                            customers.Add(customer);
                        }
                    }
                }
            }
            return customers;
        }

        private static int InsertCustomer(string name, string city)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = @"
                    INSERT INTO [Customer]
                       ([Name], [City])
                    VALUES 
                       (@name, @city)
                    SELECT SCOPE_IDENTITY()";

                    cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = name;
                    cmd.Parameters.Add("@city", SqlDbType.NVarChar).Value = city;

                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        private static void UpdateCustomer(int customerId, string name, string city)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = @"
                        UPDATE [Customer]
                        SET [Name] = @name, [City] = @city
                        WHERE CustomerId = @customerId";

                    command.Parameters.Add("@customerId", SqlDbType.BigInt).Value = customerId;
                    command.Parameters.Add("@name", SqlDbType.NVarChar).Value = name;
                    command.Parameters.Add("@city", SqlDbType.NVarChar).Value = city;

                    command.ExecuteNonQuery();
                }
            }
        }

        private static void ShowStat()
        {

        }
    }
}
