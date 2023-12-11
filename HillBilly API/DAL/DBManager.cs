using HillBilly_API.Models;
using Npgsql;
using System;
using System.Reflection;

namespace HillBilly_API.DAL
{
    /// <summary>
    /// Class for managing the DataBase.
    /// </summary>
    public class DBManager
    {
        private NpgsqlConnection _connection;
        private readonly string _connectionString = "Server=surus.db.elephantsql.com;Port=5432;User Id=yqvmhvof;Password=YsQJe4HI-yVR8rh_Pwqj_bsOoMo4mRfT;Database=yqvmhvof";
        public DBManager()
        {
            _connection = new NpgsqlConnection(_connectionString);
        }
        public void Open()
        {
            _connection.Open();
        }
        public void Close()
        {
            _connection.Close();
        }
        /// <summary>
        /// Get Log History
        /// </summary>
        /// <returns>This method returns a list of data from the DB</returns>
        public List<LogHistory> GetHistory()
        {
            Open();

            List<LogHistory> LogHistory = new List<LogHistory>();
            string sql = "SELECT * FROM logHistory";

            using (NpgsqlCommand cmd = new NpgsqlCommand(sql, _connection)) // "Using" automatically disposes of objects after use.
            {
                using (NpgsqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        LogHistory logEntry = new LogHistory();
                        int i = 0;

                        // This loop gets all the properties from the DataBase and sets them to the object.
                        foreach (PropertyInfo property in logEntry.GetType().GetProperties().Where(PropInfo => !PropInfo.GetGetMethod()!.GetParameters().Any()))
                        {
                            property.SetValue(logEntry, reader.GetValue(i++));
                            //Console.WriteLine($"{p.Name}: \"{p.GetValue(logEntry, null)}\"");
                        }

                        LogHistory.Add(logEntry);
                    }
                }
            }

            Close();
            return LogHistory;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="outsideTemperature"></param>
        /// <param name="uvIndex"></param>
        /// <param name="waterLevelPercentage"></param>
        /// <returns></returns>
        public bool AppendLogEntry(double outsideTemperature, int uvIndex, int waterLevelPercentage, int stableId)
        {
            Open();

            try
            {
                string sql = $"INSERT INTO logHistory (outsideTemperature, uvIndex, waterLevelPercentage, stableId) VALUES ({outsideTemperature}, {uvIndex}, {waterLevelPercentage}, {stableId})";
                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, _connection))
                {
                    cmd.ExecuteScalar();
                }
            }
            catch (Exception)
            {
                return false;
            }

            Close();
            return true;
        }
        public void Clear()
        {
            Open();

            try
            {
                string sql = "TRUNCATE logHistory RESTART IDENTITY CASCADE";
                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, _connection))
                {
                    cmd.ExecuteScalar();
                }
            }
            catch (Exception)
            { }

            Close();
        }
    }
}