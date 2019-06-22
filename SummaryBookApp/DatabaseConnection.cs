using System;
using System.Data.SqlClient;
using System.Text;

namespace SummaryBookApp
{

    public class DatabaseConnection
    {
        private string database;
        public StringBuilder sb = new StringBuilder("Data Source=.; Initial Catalog=", 3000);
        private SqlConnection connection = new SqlConnection();

        public DatabaseConnection(string DatabaseName)
        {
            try
            {
                if (String.IsNullOrEmpty(DatabaseName))
                {
                    throw new ArgumentNullException("Database name cannot be null!");
                }
                else
                {
                    this.database = DatabaseName;
                    sb.Append(DatabaseName);
                    sb.Append(";Integrated Security=True;");
                    Console.WriteLine($"Connection is:{Convert.ToString(sb)}");
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public string DatabaseName
        {

            get { return this.database; }
            set
            {
                if (value != null)
                {
                    this.database = value;
                }
                else if (value == null)
                {
                    throw new ArgumentNullException("Database Name cannot be null");
                }
            }
        }
        public SqlConnection Connection
        {
            get { return this.connection; }
        }
        public void ConnectionToDatabase()
        {
            try
            {
                if (Convert.ToString(connection.State) != "Open")
                {
                    connection.ConnectionString = Convert.ToString(sb);

                    connection.Open();
                    Console.WriteLine($"Connection to database {this.database} has been established");
                }
                else
                {
                    throw new Exception("The connection is already opened!");
                }
            }
            catch (SqlException odbcEx)
            {
                Console.WriteLine(odbcEx.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void DisposeConnection()
        {
            if (Convert.ToString(connection.State) == "Open")
            {
                connection.Dispose();
            }
            else
            {
                throw new Exception("We cannot dispose a connection that is not opened!!!");
            }
        }

    }
}
