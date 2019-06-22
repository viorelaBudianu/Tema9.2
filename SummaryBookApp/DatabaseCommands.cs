using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace SummaryBookApp
{
    public class DatabaseCommands
        {
            private SqlCommand comanda = new SqlCommand();

            public DatabaseCommands(SqlConnection connection)
            {
                try
                {
                    comanda.Connection = connection;
                }
                catch (SqlException s)
                {
                    Console.WriteLine(s.Message);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

        public void DisposeCommands()
        {
            this.comanda.Dispose();
        }
        public List<Book> BooksInYear(int Year)
        {
            try
            {
                comanda.CommandText = "Select * From Book2 where Year=@Year;";
                SqlParameter parameterYear = new SqlParameter("@Year", System.Data.DbType.Int32);
                parameterYear.Value = Year;
                comanda.Parameters.Add(parameterYear);
                var returned = comanda.ExecuteScalar();
                if (String.IsNullOrWhiteSpace(Convert.ToString(comanda.ExecuteScalar())))
                {
                    Console.WriteLine($"Books in year {Year} doesn't exist in database, therefor no result has been returned");
                    return null;
                }
                else
                {
                    Console.WriteLine($"Books from year {Year}:");
                    SqlDataReader ss = comanda.ExecuteReader();
                   // parameterYear.Value = null;
                    List<Book> Books = new List<Book>();

                    while (ss.Read())
                    {
                        Book book = new Book();
                        book.Id = (int)ss[0];
                        book.BookTitle = ss[1] as string;
                        book.PublisherId = (int)ss["PublisherId"];
                        book.BookYear = ss["Year"] is DBNull ? null : (int?)ss["Year"];
                        book.BookPrice = ss["Price"] is DBNull ? null : (decimal?)ss["Price"];

                        Books.Add(book);
                      
                    }
                    ss.Close();
                    comanda.Dispose();
                    return Books;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                comanda.Dispose();
                return null;
            }
            
        }

        public int maxYear()
        {
            try
            {
                comanda.CommandText = "Select Max(Year) from Book2";

                if (String.IsNullOrWhiteSpace(Convert.ToString(comanda.ExecuteScalar())))
                {
                    Console.WriteLine("Please check again the table's name");
                    comanda.Dispose();
                    return 0;
                }
                else
                {
                    var year = comanda.ExecuteScalar();
                    comanda.Dispose();
                    return Int32.Parse(Convert.ToString(year));

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                comanda.Dispose();
                return 0;
                
            }
        }

        public void Top10FromTable(string TableName, string FirstColumn, string SecondColumn, string ThirdColumn)
        {
            try
            {
                if (ThirdColumn == null)
                {
                    StringBuilder sb = new StringBuilder("select top (10) * from ");
                    comanda.CommandText = Convert.ToString(sb.Append(TableName));

                    if (String.IsNullOrWhiteSpace(Convert.ToString(comanda.ExecuteScalar())))
                    {
                        Console.WriteLine("Please check again the table's name");
                    }
                    else
                    {
                        var reader = comanda.ExecuteReader();

                        // write each record
                        while (reader.Read())
                        {
                            Console.WriteLine("{0}, {1}",
                                reader[FirstColumn],
                                reader[SecondColumn]);
                        }
                        reader.Close();
                    }

                }
                else
                {
                    StringBuilder sb = new StringBuilder("select top (10) * from ");
                    comanda.CommandText = Convert.ToString(sb.Append(TableName));

                    if (String.IsNullOrWhiteSpace(Convert.ToString(comanda.ExecuteScalar())))
                    {
                        Console.WriteLine("Please check again the table's name");
                    }
                    else
                    {
                        var reader = comanda.ExecuteReader();

                        // write each record
                        while (reader.Read())
                        {
                            Console.WriteLine("{0}, {1}, {2}",
                                reader[FirstColumn],
                                reader[SecondColumn],
                                reader[ThirdColumn]);
                        }
                        reader.Close();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
        public void NumberOfRowsFromTable(string TableName)
        {

            try
            {
                StringBuilder sb = new StringBuilder("Select Count(*) from ");
                comanda.CommandText = Convert.ToString(sb.Append(TableName));

                if (String.IsNullOrWhiteSpace(Convert.ToString(comanda.ExecuteScalar())))
                {
                    Console.WriteLine("Please check again the table's name");
                }
                else
                    Console.WriteLine($"Number of rows in table {TableName} is {comanda.ExecuteScalar()}");

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public List<NumberOfBooksPerPublisher> CountofBooksPerPublisher()
        {
            try
            {
                comanda.CommandText = "Select p.Name,Count(BookID) as NumberOfBooks From Book2 inner join Publisher2 p on Book2.PublisherId = p.PublisherId group by p.Name";
                List<NumberOfBooksPerPublisher> numberOfBooksPerPublishers = new List<NumberOfBooksPerPublisher>();
                var reader = comanda.ExecuteReader();
                Console.WriteLine("Number of books per publisher");
                // write each record
                while (reader.Read())
                {
                    NumberOfBooksPerPublisher numberOf = new NumberOfBooksPerPublisher();
                    numberOf.PublisherName =  reader["Name"] as string;
                    numberOf.NoOfBooks=reader["NumberOfBooks"] is DBNull?null:(int?)reader["NumberOfBooks"];
                    numberOfBooksPerPublishers.Add(numberOf);
                }
                return numberOfBooksPerPublishers;
                reader.Close();


            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

       
        }
    }

