using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using SummaryBookApp;
using System.Runtime.Serialization;
using System.Web.UI;
using System.Web.Script.Serialization;



namespace Serialization
{   
    class Program
    {
        static void Main(string[] args)
        {
            List<Book> books = new List<Book>();
            Book b1 = new Book();
            Book b2 = new Book();
            Book b4 = new Book();
            Book b3 = new Book();
            b1.Id = 1;
            b1.BookPrice = 20.1m;
            b1.BookTitle = "Cartea celor mici";
            b1.PublisherId = 2;
            b1.BookYear = 2017;

            b2.Id = 11;
            b2.BookPrice = 120.1m;
            b2.BookTitle = "Twilight series";
            b2.PublisherId = 2;
            b2.BookYear = 2014;
            b3.Id = 12;
            b3.BookPrice = 30;
            b3.BookTitle = "Matematica Pentru toti";
            b3.PublisherId = 3;
            b3.BookYear = 2019;
            b4.Id = 3;
            b4.BookPrice = 10;
            b4.BookTitle = "Carte de colorat pentru cei mici";
            b4.PublisherId = 1;
            b4.BookYear = 2018;
            books.Add(b1);
            books.Add(b2);
            books.Add(b3);
            books.Add(b4);
            var json = new JavaScriptSerializer();
            var serializedResult = json.Serialize(RegisteredUsers);
        }
    }
}
