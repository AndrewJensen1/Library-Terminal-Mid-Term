using System;
using System.Collections.Generic;
using System.Text;

namespace Libarary_Terminal_Mid_Term_Project
{
    class LibraryDb
    {
        public static List<Book> onShelf = new List<Book>();
        public static List<Book> checkedOut = new List<Book>();

        public static List<Book> books = new List<Book>
        {
            new Book("The Great Gatsby", "F. Scott Fitzgerald", "On Shelf", DateTime.Now.Date),
            new Book("To Kill a Mockingbird", "Harper Lee", "Checked Out", DateTime.Now.Date),
            new Book("Harry Potter and the Sorcerer's Stone", "J.K. Rowling", "On Shelf", DateTime.Now.Date),
            new Book("1984", "George Orwell", "On Shelf", DateTime.Now.Date),
            new Book("The Catcher in the Rye", "J.D. Salinger", "On Shelf", DateTime.Now.Date),
            new Book("The Hobbit", "J.R.R. Tolkien", "Checked Out", DateTime.Now.Date),
            new Book("Fahrenheit 451", "Ray Bradbury", "On Shelf", DateTime.Now.Date),
            new Book("Pride and Prejudice", "Jane Austen", "On Shelf", DateTime.Now.Date),
            new Book("Brave New World", "Aldous Huxley", "On Shelf", DateTime.Now.Date),
            new Book("The Alchemist", "Paulo Coelho", "Checked Out", DateTime.Now.Date),
            new Book("The Hitchhiker's Guide To The Galaxy", "Douglas Adams", "On Shelf", DateTime.Now.Date),
            new Book("The Restaurant At The End Of The Universe", "Douglas Adams", "On Shelf", DateTime.Now.Date),
            new Book("So Long, And Thanks For All The Fish", "Douglas Adams", "On Shelf", DateTime.Now.Date)
        };

    }
}
