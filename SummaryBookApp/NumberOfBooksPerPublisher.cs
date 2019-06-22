using System;
using System.Collections.Generic;

namespace SummaryBookApp
{
    //3. Number of books and publisher name ( Create a class NumberOfBooksPerPublisher { NoOfBooks, PublisherName }, load the information into a List<NumberOfBooksPerPublisher > )
    public class NumberOfBooksPerPublisher
    {
        private int? NoBooks;
        public string PublisherName;

        public NumberOfBooksPerPublisher(int? noBooks, string PublisherName)
        {
            try
            {
                this.NoBooks = noBooks; ;
            }
            catch (FormatException fe)
            {
                Console.WriteLine("The format is not a valid format for Number of Books field");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            this.PublisherName = PublisherName;
        }
        public NumberOfBooksPerPublisher()
        {

        }
        public int? NoOfBooks
        {
            get { return this.NoBooks; }
            set
            {
                try
                {
                    this.NoBooks = value; ;
                }
                catch (FormatException fe)
                {
                    Console.WriteLine("The format is not a valid format for Number of Books field");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
        public static void ShowBooksPerPublisher(List<NumberOfBooksPerPublisher> BooksPublisher)
        {
            Console.WriteLine("PublisherName | NumberOfBooks");
            foreach (var p in BooksPublisher)
            {
                Console.WriteLine($"{p.PublisherName} | {p.NoOfBooks}");
            }
        }
    }
}
