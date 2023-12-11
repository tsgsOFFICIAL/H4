using Npgsql;
using SoftwareSecurityConsole.Models;

namespace SoftwareSecurityConsole.DAL
{
    /// <summary>
    /// Class for managing the Database.
    /// </summary>
    internal class DBMan
    {
        private NpgsqlConnection _connection;
        private readonly string _connectionString = "Server=surus.db.elephantsql.com;Port=5432;User Id=naknwnpq;Password=PcbBIPOGtavGqC6gWKan7TowLrdD6KpU;Database=naknwnpq";
        internal DBMan()
        {
            _connection = new NpgsqlConnection(_connectionString);
        }
        private void Open()
        {
            _connection.Open();
        }
        private void Close()
        {
            _connection.Close();
        }
        #region Users
        internal async Task AddUser(User user)
        {
            string commandText = $"INSERT INTO USERS (username, password) VALUES (@username, @password)";

            Open();

            await using (NpgsqlCommand cmd = new NpgsqlCommand(commandText, _connection))
            {
                cmd.Parameters.AddWithValue("username", user.Username!);
                cmd.Parameters.AddWithValue("password", user.Password!);

                await cmd.ExecuteNonQueryAsync();
            }

            Close();
        }
        internal async Task<User> GetUser(string username)
        {
            string commandText = $"SELECT * FROM USERS WHERE username = @username";

            await using (NpgsqlCommand cmd = new NpgsqlCommand(commandText, _connection))
            {
                cmd.Parameters.AddWithValue("username", username);

                await using (NpgsqlDataReader reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        User user = ReadUserValues(reader);
                        return user;
                    }
                }
            }

            return null!;
        }
        /// <summary>
        /// Read user values
        /// </summary>
        /// <param name="reader">PostgreSQL DataReader</param>
        /// <returns>This method returns a user object</returns>
        private static User ReadUserValues(NpgsqlDataReader reader)
        {
            int? id = reader["id"] as int?;
            string? username = reader["username"] as string;
            string? password = reader["password"] as string;
            DateTime CreationTime = (DateTime)reader["CreationTime"];
            DateTime LastLoginTime = (DateTime)reader["LastLoginTime"];
            bool Banned = (bool)reader["Banned"];

            User user = new User
            {
                Id = id!.Value,
                Username = username,
                Password = password,
                CreationTime = CreationTime,
                LastLoginTime = LastLoginTime,
                Banned = Banned
            };

            return user;
        }
        internal async Task<bool> DoesUserExist(string username)
        {
            Open();

            string sql = $"SELECT * FROM users WHERE username = @username";

            await using (NpgsqlCommand cmd = new NpgsqlCommand(sql, _connection))
            {
                cmd.Parameters.AddWithValue("username", username);

                using (NpgsqlDataReader reader = await cmd.ExecuteReaderAsync())
                {
                    bool HasRows = reader.HasRows;

                    Close();
                    return HasRows;
                }
            }
        }
        #endregion
    }
}