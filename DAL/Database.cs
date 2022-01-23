using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaBox_Receipt_Management.DML
{
    public class Database
    {
        private static Database dbInstance;
        string connectionString;
        private readonly SqlConnection conn;

        private Database()
        {
            connectionString = ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString;
            conn = new SqlConnection(connectionString);
        }

        public static Database getDbInstance()
        {
            if (dbInstance == null)
            {
                dbInstance = new Database();
            }
            return dbInstance;
        }

        public SqlConnection GetDBConnection()
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                Console.WriteLine("Connected");
            }
            catch (SqlException e)
            {
                Console.WriteLine("Not connected : " + e.ToString());
                Console.ReadLine();
            }
            finally
            {
                Console.WriteLine("End..");
                Console.ReadLine();
            }
            Console.ReadLine();
            return conn;
        }

        public void CloseConnection()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
        }
    }
}
