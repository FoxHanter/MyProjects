using System.Collections.Generic;

namespace LibraryFunctional
{
    public class Reader
    {
        public string Name { get; private set; }
        public int ID { get; set; }
        public List<BookToReader> Books { get; private set; }

        public Reader() { }

        public Reader(string name)
        {
            Name = name;
            Books = new List<BookToReader>();
        }

        public Reader(int id,string name)
        {
            ID = id;
            Name = name;
            Books = new List<BookToReader>();
        }

        public void AddBook(BookToReader book)
        {
            Books.Add(book);
        }

        public void DeleteBook(BookToReader book)
        {
            Books.Remove(book);
        }

        public override string ToString()
        {
            return ID + ". " + Name;
        }
    }
}
