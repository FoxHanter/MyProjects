using System.Collections.Generic;
using System.Data.OleDb;

namespace LibraryFunctional
{
    public class BookRepository : DatabaseQueryMaker, IRepository<Book>
    {
        List<Book> _books;
        private OleDbConnection myConnection;
        public string Table { get; private set; }

        public BookRepository(OleDbConnection connection, string table)
        {
            _books = new List<Book>();
            myConnection = connection;
            Table = table;
        }

        public void Create(Book item)
        {
            if (FindByName(item) > 0)
                Update(item, item.Count);
            else
                VoidQuery($"INSERT INTO {Table} (b_name, b_count) VALUES ('{item.Name}', '{item.Count}')", myConnection);
        }

        public void Delete(int id)
        {
            VoidQuery($"DELETE FROM {Table} WHERE b_id = {id}", myConnection);
        }

        private int FindByName(Book book)
        {
            var items = DataQuery($"SELECT b_id FROM {Table} WHERE b_name = '{book.Name}'", myConnection);
            int id = 0;

            foreach (var item in items)
                id = int.Parse(item[0].ToString());

            return id;
        }

        public IEnumerable<Book> GetAllItems()
        {
            var items = DataQuery($"SELECT b_id, b_name, b_count FROM {Table} WHERE b_id>0", myConnection);
            _books = new List<Book>();

            foreach (var item in items)
                _books.Add(new Book(int.Parse(item[0].ToString()),item[1].ToString(), int.Parse(item[2].ToString())));

            return _books;
        }

        public Book GetItem(int id)
        {
            var items = DataQuery($"SELECT b_id, b_name, b_count FROM {Table} WHERE b_id={id}", myConnection);
            Book book = new Book();

            foreach (var item in items)
                book = new Book(int.Parse(item[0].ToString()), item[1].ToString(), int.Parse(item[2].ToString()));

            return book;
        }

        public void Save()
        {
            //не нашел как сохранять изменения в бд
        }

        public void Update(Book item, int delta)
        {
            VoidQuery($"UPDATE {Table} SET b_count = b_count+ {delta} WHERE b_id = {FindByName(item)}", myConnection);
        }
    }
}
