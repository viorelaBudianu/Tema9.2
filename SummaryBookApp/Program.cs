using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SummaryBookApp
{

    partial class Program
    {
        static void Main(string[] args)
        {
            DatabaseConnection databaseConnection = new DatabaseConnection("Week9");
            databaseConnection.ConnectionToDatabase();

            DatabaseCommands comenzi = new DatabaseCommands(databaseConnection.Connection);

            Book book = new Book();
            //All the books that are published in 2010 - nu am in baza de date 2010 - o sa pun 2017

           Book.ShowBooks(comenzi.BooksInYear(2017));
           comenzi.DisposeCommands();
            //The book that is published in the max year (can use multiple commands)
            Book.ShowBooks(comenzi.BooksInYear(2017));

            //Top 10 books (Title, Year, Price)
            book.ShowTop();

        }
    }
}
