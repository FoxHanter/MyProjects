using System;

namespace LibraryFunctional
{
    public class Book : IComparable
    {
        public int ID { get; set; }
        public string Name { get; private set; }
        public int Count { get; set; }

        public Book() { }

        public Book(string name, int count = 1)
        {
            Name = name;
            Count = count;
        }

        public Book(int id,string name, int count = 1)
        {
            ID = id;
            Name = name;
            Count = count;
        }

        public int CompareTo(object obj)
        {
            Book otherBook = (Book)obj;

            return Name.CompareTo(otherBook.Name);
        }

        public override string ToString()
        {
            return ID + ". " + Name; 
        }
    }
}
