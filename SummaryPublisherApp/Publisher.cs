using SummaryPublisherApp;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace SummaryBookApp
{
    public class Publisher : IGeneralElements
    {
        private int PublisherId;
        public string Name { get; set; }

        public Publisher(int publisherId, string name)
        {
            this.PublisherId = publisherId;
            this.Name = name;
        }
        public Publisher()
        {

        }
        public int Id
        {
            get { return this.PublisherId; }
            set
            {
                if (value != null)
                {
                    this.PublisherId = value;
                }
                else if (value == null)
                {
                    throw new ArgumentNullException("PublisherId cannot be null");
                }
                else if (value.GetType() != "book".GetType())
                {
                    throw new FormatException("PublisherId should be an integer value");
                }
            }
        }

        public static void ShowPublishers(List<Publisher> publisher)
        {
            Console.WriteLine("PublisherId | Name");
            foreach (var p in publisher)
            {
                Console.WriteLine($"{p.PublisherId} | {p.Name}");
            }
        }
        public void ShowTop()
        {
            DatabaseConnection connection = new DatabaseConnection("Week9");
            connection.ConnectionToDatabase();
            DatabaseCommands TopPublisher = new DatabaseCommands(connection.Connection);
            TopPublisher.Top10FromTable("Publisher2", "PublisherId", "Name", null);
        }
        public static void SumofBooksforAPublisher(string PublisherName)
        {
            try
            {
                DatabaseConnection con = new DatabaseConnection("Week9");
                con.ConnectionToDatabase();
                SqlCommand comanda = new SqlCommand();
                comanda.Connection = con.Connection;
                comanda.CommandText = "Select Sum(Price) as TotalPrice From Book2 inner join Publisher2 p on Book2.PublisherId = p.PublisherId group by p.Name having p.Name='@PublisherName'";
                 SqlParameter parameterName = new SqlParameter("@PublisherName", System.Data.DbType.String);
                parameterName.Value = PublisherName;
                comanda.Parameters.Add(parameterName);
                var result = comanda.ExecuteScalar();
                Console.WriteLine($"Sum of books for publisher: {PublisherName} is {result}");
               
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        public static void SumofBooksforEachPublisher()
        {
            try
            {
                DatabaseConnection con = new DatabaseConnection("Week9");
                con.ConnectionToDatabase();
                SqlCommand comanda = new SqlCommand("Select p.Name,Sum(Price) as TotalPrice From Book2 inner join Publisher2 p on Book2.PublisherId = p.PublisherId group by p.Name", con.Connection);

                var reader = comanda.ExecuteReader();
                Console.WriteLine("Sum of books per publisher");
                // write each record
                while (reader.Read())
                {
                    
                    Console.WriteLine("{0} -> {1}",
                        reader["Name"],
                        reader["TotalPrice"]);
                }
                reader.Close();


            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
