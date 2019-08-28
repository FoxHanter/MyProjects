using System.Collections.Generic;
using System.Data.OleDb;

namespace LibraryFunctional
{
    public class DatabaseQueryMaker
    {
        public void VoidQuery(string query, OleDbConnection connection)
        {
            OleDbCommand command = new OleDbCommand(query, connection);
            command.ExecuteNonQuery();
        }

        public List<List<string>> DataQuery(string query, OleDbConnection connection)
        {
            OleDbCommand command = new OleDbCommand(query, connection);
            OleDbDataReader reader;
            reader = command.ExecuteReader();

            var items =new List<List<string>>();
            int i = 0;

            while (reader.Read())
            {
                items.Add(new List<string>());

                for (int j = 0; j < reader.FieldCount; j++)               
                    items[i].Add(reader[j].ToString());

                i++;
            }

            return items;
        }
    }
}
