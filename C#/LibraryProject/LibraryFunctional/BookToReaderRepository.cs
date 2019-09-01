using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryFunctional
{
    public class BookToReaderRepository : DatabaseQueryMaker, IRepository<BookToReader>
    {
        List<BookToReader> _books;
        private OleDbConnection myConnection;
        public string Table { get; private set; }

        public BookToReaderRepository(OleDbConnection connection, string table)
        {
            _books = new List<BookToReader>();
            myConnection = connection;
            Table = table;
        }

        public void Create(BookToReader item)
        {
            VoidQuery($"INSERT INTO BooksToReaders (b_id, r_id, t_in, t_out) VALUES('{item.BookId}','{item.ReaderId}','{item.DateOfIssue}','{item.ReturnDate}')",myConnection);
        }

        public void Delete(int id){}

        public void Delete(int readerID,int bookID)
        {
            VoidQuery($"DELETE FROM BooksToReaders WHERE r_id = {readerID} and b_id={bookID}", myConnection);
        }

        public IEnumerable<BookToReader> GetAllItems()
        {
            throw new NotImplementedException();
        }

        public BookToReader GetItem(int id)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(BookToReader item, int delta)
        {
            throw new NotImplementedException();
        }
    }
}
