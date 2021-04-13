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
                    Console.WriteLine($"ID: {customer.CustomerId, -3} {customer.Name, -30} {customer.City}");
                }
            }

            if (command == "insert")
            {
                int createdCustomerId = InsertCustomer("Иванов Иван Иванович", "Чебоксары");
                Console.WriteLine("Created customer: " + createdCustomerId);
            }

            if (command == "update")
            {
                UpdateCustomer(3, "Абвгд Еёжз Иклмн", "Чебоксары");
            }

            if (command == "stats")
            {
                ShowStats();
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
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = @"
                        UPDATE Customer
                        SET [Name] = @name, [City] = @city
                        WHERE CustomerId = @customerId";

                    command.Parameters.Add("@customerId", SqlDbType.BigInt).Value = customerId;
                    command.Parameters.Add("@name", SqlDbType.NVarChar).Value = name;
                    command.Parameters.Add("@city", SqlDbType.NVarChar).Value = city;

                    command.ExecuteNonQuery();
                }
            }
        }

        private static void ShowStats()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText =
                        @"SELECT [Customer].[Name], COUNT([Order].[ProductName]) AS 'Amount', COALESCE(SUM([Order].[Price]), 0) AS 'Sum'
                            FROM[Order]
                            INNER JOIN[Customer] ON [Order].[CustomerId] = [Customer].[CustomerId]
                            GROUP BY [Customer].[Name]";

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        Console.WriteLine($"{"Name",-35} {"Amount",-6} {"Sum",-5}");
                        while (reader.Read())
                        {
                            string name = Convert.ToString(reader["Name"]);
                            int amount = Convert.ToInt32(reader["Amount"]);
                            int sum = Convert.ToInt32(reader["Sum"]);
                            Console.WriteLine($"{name, -35} {amount, -6} {sum, -5}");
                        } 
                    }
                }
            }
        }
    }
}
