using System;
using System.Collections.Generic;

namespace SummaryBookApp
{

    public class Book: IGeneralElements
    {
        private int BookId;
        public string BookTitle;
        public int? PublisherId;
        public int? BookYear;
        public decimal? BookPrice;

        public Book()
        {
        }
        public Book(int BookId, string BookTitle)
        {
            try
            {
                this.BookId = BookId;
            }
            catch (FormatException fe)
            {
                Console.WriteLine("The format is not a valid format for BookId");
            }
            catch (ArgumentNullException ar)
            {
                Console.WriteLine("Null is not a valid value for BookId");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            this.BookTitle = BookTitle;
        }

        public int Id
        {
            get { return this.BookId; }
            set
            {
                if (value != null)
                {
                    this.BookId = value;
                }
                else if (value == null)
                {
                    throw new ArgumentNullException("BookId cannot be null");
                }
                else if (value.GetType()!="book".GetType())
                {
                    throw new FormatException("BookId should be an integer value");
                }
            }
        }

        public static void ShowBooks(List<Book> Book)
        {
            Console.WriteLine("BookId | BookTitle | BookYear | Price | PublisherId");
            foreach (var b in Book)
            {
                Console.WriteLine($"{b.BookId} | {b.BookTitle} | {b.BookYear} | {b.BookYear} | {b.PublisherId}");
            }
        }

        public void ShowTop()
        {
            DatabaseConnection connection = new DatabaseConnection("Week9");
            connection.ConnectionToDatabase(); 
            DatabaseCommands TopBook = new DatabaseCommands(connection.Connection);
            TopBook.Top10FromTable("Book2", "Title", "Year", "Price");
        }
    }
}
