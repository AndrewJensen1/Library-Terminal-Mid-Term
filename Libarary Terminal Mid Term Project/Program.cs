using System;
using System.Collections.Generic;
using System.Linq;

namespace Libarary_Terminal_Mid_Term_Project
{
    class Program
    {
        static void Main(string[] args)
        {
                Console.WriteLine("Welcome to the Library Terminal\n");
                DisplayMenuTaskManager();

                Console.Write("Please enter a number: \n");
            bool go = true;
            while (go)
            {
                if (int.TryParse(Console.ReadLine(), out int result))
                {
                    if (result == 1)
                    {
                        Console.Clear();
                        Console.WriteLine();
                        DisplayFullListOfBooks();
                        DisplayMenuTaskManager();
                    }
                    else if (result == 2)
                    {
                        Console.Clear();
                        Console.WriteLine();
                        Console.Write("Please enter author's name: ");
                        Console.WriteLine();
                        string userInput = Console.ReadLine().ToLower();
                        Console.WriteLine();
                        List<Book> displayAuthorsMethod = DisplaySearchByAuthor(userInput);
                        DisplayAuthors(displayAuthorsMethod);
                        Console.WriteLine();
                        DisplayMenuTaskManager();
                    }
                    else if (result == 3)
                    {
                        Console.Clear();
                        Console.WriteLine("Please enter a title to search: ");
                        string userInput = Console.ReadLine().ToLower();
                        List<Book> displayTitleMethod = DisplaySearchByTitle(userInput);
                        DisplayTitle(displayTitleMethod);
                        DisplayMenuTaskManager();
                    }
                    else if (result == 4)
                    {
                        Console.Clear();
                        ListSeparator();
                        Console.WriteLine("These are all the Titles On Shelf: \n");
                        Console.WriteLine("==================================");
                        OnShelfCheckedOut(LibraryDb.onShelf);
                        Console.WriteLine("These are the books that are checked out: \n");
                        Console.WriteLine("=========================================");
                        OnShelfCheckedOut(LibraryDb.checkedOut);
                        DisplayMenuTaskManager();
                    }
                    else if (result == 5)
                    {
                        Console.Clear();              
                        Console.WriteLine("Would you like to Check out a Book 1.)  Return a Book 2.) Return to Main Menu 3.)");
                        CheckInOrCheckOut();


                    }
                    else if (result == 6)
                    {
                        Console.Clear();
                        Console.WriteLine("Good Bye!");
                        go = Quit();
                    }
                    else
                    {
                        Console.WriteLine("Incorrect option please try again");
                    }
                }
            }
        }
        
        public static void DisplayMenuTaskManager()
        {
            Console.WriteLine("Library Main Menu\n");
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("1.) List Books");
            Console.WriteLine("2.) Search by Author");
            Console.WriteLine("3.) Search by Title");
            Console.WriteLine("4.) Search On Shelf and Checked out");
            Console.WriteLine("5.) Check out or Return a book");
            Console.WriteLine("6.) Exit");
        }

        
        public static void DisplayFullListOfBooks()
        {
            int counter = 0;
            foreach (Book book in LibraryDb.books)
            {
                counter++;
                Console.WriteLine($"{counter}: {book.Title}, {book.Author}, {book.Status}, {book.DueDate.ToString("MM/dd/yyyy")}\n");
            }
        }

        
        public static List<Book> DisplaySearchByAuthor(string userInput)
        {
            List<Book> authors = new List<Book>();

            foreach (Book book in LibraryDb.books)
            {
                if(userInput == book.Author.ToLower())
                {
                     authors.Add(book);
                }                
            }
            return authors;            
        }

        public static void DisplayAuthors(List<Book> authors)
        {
            int counter = 0;
            foreach (Book book in authors)
            {
                counter++;
                Console.WriteLine($"{counter}: {book.Title}, {book.Author}, {book.Status}\n");
            }
        }
        public static List<Book> DisplaySearchByTitle(string userInput)
        {
            List<Book> title = new List<Book>();

            foreach (Book book in LibraryDb.books)
            {
                if (userInput == book.Title.ToLower())
                {
                    title.Add(book);
                }
            }
            return title;
        }
        public static void DisplayTitle(List<Book> title)
        {
            int counter = 0;
            foreach (Book book in title)
            {
                counter++;
                Console.WriteLine($"{counter}: {book.Title}, {book.Author}, {book.Status}\n");
            }
        }

        public static void OnShelfCheckedOut(List<Book> onShelfOffShelf)
        {
            int counter = 0;
            foreach (Book book in onShelfOffShelf)
            {
                counter++;
                Console.WriteLine($"{counter}: {book.Title}, {book.Author}, {book.Status}, {book.DueDate.ToString("MM/dd/yyyy")}\n");
            }
        }

        public static void ListSeparator()
        {
            foreach (Book book in LibraryDb.books)
            {
                if(book.Status == "On Shelf")
                {
                    LibraryDb.onShelf.Add(book);
                }
                else
                {
                    LibraryDb.checkedOut.Add(book);
                }
            }
        }

        public static void CheckInOrCheckOut()
        {
            foreach (Book book in LibraryDb.books)
            {
                if (int.TryParse(Console.ReadLine(), out int result))
                {
                    if (result == 1)
                    {
                        DisplayFullListOfBooks();
                        CheckOut();
                        DisplayMenuTaskManager();
                        break;
                    }
                    else if (result == 2)
                    {
                        DisplayFullListOfBooks();
                        ReturnBook();
                        DisplayMenuTaskManager();
                        break;
                    }
                    else if (result == 3)
                    {
                        DisplayMenuTaskManager();
                        break;
                    }
                    else
                    {
                        Console.WriteLine("I'm sorry that is an incorrect option please try again");
                    }
                }
                else
                {
                    DisplayMenuTaskManager();
                    break;
                }
            }
        }

        public static void CheckOut()
        {
            //string onShelf = "On Shelf";
            //string statusChange = onShelf.Replace("On Shelf", "Checked Out");
            bool go = true;
            while (go)
            {
                int counter = 0;
                Console.WriteLine("What book would you like to check out?");
                OnShelfCheckedOut(LibraryDb.onShelf);
                if (int.TryParse(Console.ReadLine(), out int result))
                {
                    result = result - 1;
                    Book chosenBook = LibraryDb.books[result];
                    counter++;
                    Console.WriteLine();
                    if (result <= LibraryDb.books.Count && result >= 0)
                    {
                        Console.WriteLine($"{counter}, {chosenBook.Title}, {chosenBook.Author}, {chosenBook.Status}, {chosenBook.DueDate.ToString("MM/dd/yyyy")}");
                        Console.WriteLine("\nAre you sure you want to Check out this book? y or n");
                        string userInput = Console.ReadLine();

                        if (userInput == "y")
                        {
                            LibraryDb.books[result].Status = "Checked out";
                            LibraryDb.books[result].DueDate = (DateTime.Now.Date).AddDays(14);
                            go = false;
                        }
                        else if (userInput == "n")
                        {
                            DisplayMenuTaskManager();
                            go = false;

                        }
                        else
                        {
                            Console.WriteLine("That is an incorrect option please try again.");
                        }
                    }
                }
            }
        }

        public static void ReturnBook()
        {
            //string onShelf = "On Shelf";
            //string statusChange = onShelf.Replace("On Shelf", "Checked Out");
            bool go = true;
            while (go)
            {
                int counter = 0;
                Console.WriteLine("What book would you like to return?");
                OnShelfCheckedOut(LibraryDb.checkedOut);
                if (int.TryParse(Console.ReadLine(), out int result))
                {
                    result = result - 1;
                    Book chosenBook = LibraryDb.books[result];
                    counter++;
                    Console.WriteLine();
                    if (result <= LibraryDb.books.Count && result >= 0)
                    {
                        Console.WriteLine($"{counter}, {chosenBook.Title}, {chosenBook.Author}, {chosenBook.Status}");
                        Console.WriteLine("\nAre you sure you want to return this book? y or n");
                        string userInput = Console.ReadLine();

                        if (userInput == "y")
                        {
                            LibraryDb.books[result].Status = "On Shelf";
                            go = false;
                        }
                        else if (userInput == "n")
                        {
                            
                            DisplayMenuTaskManager();
                            go = false;
                        }
                        else
                        {
                            Console.WriteLine("That is an incorrect option please try again.");
                        }
                    }

                }
            }
        }

        public static bool Quit()
        {
            return false;
        }

    }

    







}

