using System.Data;
using System.Data.OleDb;

namespace LibraryFunctional
{
    public class Library
    {
        public BookRepository Books { get; private set; }
        public ReaderRepository Readers { get; private set; }
        public BookToReaderRepository TakenBooks { get; set; }

        private OleDbConnection _connection;

        public Library(OleDbConnection connection, string BooksTable, string ReadersTable,string TakenBooksTable)
        {
            Books = new BookRepository(connection, BooksTable);
            Readers = new ReaderRepository(connection, ReadersTable);
            TakenBooks = new BookToReaderRepository(connection, TakenBooksTable);
            _connection = connection;

            if (_connection.State == ConnectionState.Closed)
                _connection.Open();          
        }

        public void CloseConnection()
        {
            _connection.Close();
        }
    }
}
