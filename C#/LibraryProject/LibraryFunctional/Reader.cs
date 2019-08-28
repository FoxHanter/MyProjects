using System.Collections.Generic;

namespace LibraryFunctional
{
    public class Reader
    {
        public string Name { get; private set; }
        public int ID { get; set; }
        public List<Book> Books { get; private set; }

        public Reader() { }

        public Reader(string name)
        {
            Name = name;
            Books = new List<Book>();
        }

        public Reader(int id,string name)
        {
            ID = id;
            Name = name;
            Books = new List<Book>();
        }

        public void AddBook(Book book)
        {
            Books.Add(book);
        }

        public void DeleteBook(Book book)
        {
            Books.Remove(book);
        }

        public override string ToString()
        {
            return ID + ". " + Name;
        }
    }
}
