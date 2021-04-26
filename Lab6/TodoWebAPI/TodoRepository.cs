using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Data;

namespace TodoWebAPI
{
    public class TodoRepository
    {
        private static string _connectionString = @"Server=Todo;Database=DESKTOP-OD7BNPM\SQLEXPRESS;Trusted_Connection=True;";
        private static List<Todo> Database = new List<Todo>();

        private class Todo
        {
            public int ID { get; }
            public string Name { get; set; }
            public bool Done { get; set; }
            public DateTime CreateionDate { get; }

            public Todo(int id, string name, bool done)
            {
                ID = id;
                Name = name;
                Done = done;
                CreateionDate = DateTime.Now;
            }
        }
        private int GetID() 
        {
            if (Database.Count > 0)
            {
                return Database.Max(x => x.ID) + 1;
            }
            else
            {
                return 1;
            }
        }

        public List<TodoDTO> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText =
                        @"SELECT
                            [IDTodo],
                            [Name],
                            [Done]
                        FROM [dbo].[TodoList]";

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int ID = Convert.ToInt32(reader["IDTodo"]);
                            string Name = Convert.ToString(reader["Name"]);
                            bool Done = Convert.ToBoolean(reader["Done"]);

                            Todo todo = new Todo(ID, Name, Done);

                            Database.Add(todo);
                        }
                    }
                }
            }

            return Database.ConvertAll(x => new TodoDTO {
                ID = x.ID,
                Name = x.Name,
                Done = x.Done
            });
        }

        public int Create(TodoDTO todoDTO)
        {
            int id = GetID();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = @"
                    INSERT INTO [dbo].[TodoList]
                       ([IDTodo], [Name], [Done])
                    VALUES 
                       (@id, @name, 0)
                    SELECT SCOPE_IDENTITY()";

                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                    cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = todoDTO.Name;
                }
            }

            Todo todo = new Todo(id, todoDTO.Name, false);
            Database.Add(todo);
            
            return id;
        }

        public void Update(int id, TodoDTO todoDTO)
        {
            Todo finded = Database.FirstOrDefault(x => x.ID == id);
            if (finded == null) return;

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = @"
                        UPDATE [dbo].[TodoList]
                        SET [Name] = @name, [Done] = @state
                        WHERE IDTodo = @id";

                    command.Parameters.Add("@id", SqlDbType.BigInt).Value = finded.ID;
                    command.Parameters.Add("@name", SqlDbType.NVarChar).Value = todoDTO.Name;
                    command.Parameters.Add("@state", SqlDbType.Bit).Value = todoDTO.Done;

                    command.ExecuteNonQuery();
                }
            }

            finded.Done = todoDTO.Done;
            finded.Name = todoDTO.Name;
        }
    }
}
