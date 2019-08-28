using System.Collections.Generic;
using System.Data.OleDb;

namespace LibraryFunctional
{
    public class ReaderRepository : DatabaseQueryMaker, IRepository<Reader>
    {
        List<Reader> _readers;
        private OleDbConnection myConnection;
        public string Table { get; private set; }

        public ReaderRepository(OleDbConnection connection, string table)
        {
            _readers = new List<Reader>();
            myConnection = connection;
            Table = table;
        }

        public void Create(Reader item)
        {
            VoidQuery($"INSERT INTO {Table} (r_name) VALUES ('{item.Name}')", myConnection);
        }

        public void Delete(int id)
        {
            VoidQuery($"DELETE FROM {Table} WHERE r_id = {id}", myConnection);
        }

        public IEnumerable<Reader> GetAllItems()
        {
            var items = DataQuery($"SELECT r_id, r_name FROM {Table} WHERE r_id>0", myConnection);
            _readers = new List<Reader>();

            foreach (var item in items)
                _readers.Add(new Reader(int.Parse(item[0]),item[1].ToString()));

            return _readers;
        }

        public Reader GetItem(int id)
        {
            var items = DataQuery($"SELECT r_id, r_name FROM {Table} WHERE r_id={id}", myConnection);
            Reader currentReader = new Reader();

            foreach (var item in items)
                currentReader = new Reader(int.Parse(item[0]), item[1].ToString());

            return currentReader;
        }

        public void Save()
        {
           
        }

        public void Update(Reader item, int delta)
        {
            //пока не знаю что можно изменить у одного читателя (в упрощенной версии нет таких полей)
        }
    }
}
