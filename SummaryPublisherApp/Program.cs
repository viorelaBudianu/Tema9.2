using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SummaryBookApp;

namespace SummaryPublisherApp
{


    class Program
    {
        static void Main(string[] args)
        {
            DatabaseConnection databaseConnection = new DatabaseConnection("Week9");
            databaseConnection.ConnectionToDatabase();

            DatabaseCommands command = new DatabaseCommands(databaseConnection.Connection);
            //Number of rows from the Publisher table (Execute scalar)
            command.NumberOfRowsFromTable("Publisher2");
            //Top 10 publishers (Id, Name) (SQL Data Reader)
            Publisher publisher = new Publisher();
            publisher.ShowTop();

            //Number of books for each publisher (Publiher Name, Number of Books)
            List<NumberOfBooksPerPublisher> numberOfBooks = new List<NumberOfBooksPerPublisher>();
            numberOfBooks = command.CountofBooksPerPublisher();
            NumberOfBooksPerPublisher.ShowBooksPerPublisher(numberOfBooks);

            //The total price for books for a publisher
            Publisher.SumofBooksforAPublisher("Litera");
            //
            Publisher.SumofBooksforEachPublisher();

        }
    }
}
