using System;
using System.Collections.Generic;
using System.Text;

namespace Libarary_Terminal_Mid_Term_Project
{
    class Book
    {
        //fields
        private string title;
        private string author;
        private string status;
        private DateTime dueDate;

       


        //properties
        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
            }
        }
        public string Author
        {
            get
            {
                return author;
            }
            set
            {
                author = value;
            }
        }
        public string Status
        {
            get
            {
                return status;
            }
            set
            {
                status = value;
            }
        }
        public DateTime DueDate
        {
            get
            {
                return dueDate;
            }
            set
            {
                dueDate = value;
            }
        }
        //Constructor
        public Book()
        {

        }

        public Book(string title, string author, string status, DateTime dueDate)
        {
            Title = title;
            Author = author;
            Status = status;
            DueDate = dueDate;
        }

        //Methods

        
    }
}
