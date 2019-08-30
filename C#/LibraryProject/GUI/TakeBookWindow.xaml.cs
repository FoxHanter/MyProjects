using LibraryFunctional;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GUI
{
    /// <summary>
    /// Логика взаимодействия для TakeBookWindow.xaml
    /// </summary>
    public partial class TakeBookWindow : Window
    {
        Library _library;
        public TakeBookWindow(Library library)
        {
            InitializeComponent();
            _library = library;
        }

        private void SelectReaderButton_Click(object sender, RoutedEventArgs e)
        {
            var selectReaderWindow = new SelectReader(_library.Readers);
            selectReaderWindow.Owner = this;

            if (selectReaderWindow.ShowDialog() == true)
                selectReaderWindow.Show();
        }

        private void SelectBookButton_Click(object sender, RoutedEventArgs e)
        {
            Reader reader = _library.Readers.GetAllItems().FirstOrDefault(x => x.ToString().Equals(ChooseReaderTextBox.Text));

            if (reader == null)
            {
                (Owner as MainWindow).CallExceptionWindow($"Читатель не выбран");
                return;
            }

            var selectBookWindow = new SelectBook(_library.Books, reader.ID);
            selectBookWindow.Owner = this;

            if (selectBookWindow.ShowDialog() == true)
                selectBookWindow.Show();
        }

        private void AcceptButton_Click(object sender, RoutedEventArgs e)
        {
              try
              {
                  var book = _library.Books.GetAllItems().First(x => x.ToString().Equals(ChooseBookTextBox.Text));
                  var reader = _library.Readers.GetAllItems().First(x => x.ToString().Equals(ChooseReaderTextBox.Text));

                if (book != null && reader != null)
                {
                    _library.Books.Update(book, 1);
                    var book1 = new BookToReader();
                    book1.BookId = book.ID;
                    book1.ReaderId = reader.ID;
                    DatabaseQueryMaker maker = new DatabaseQueryMaker();
                    var con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=LibraryDataBase.mdb;");
                    con.Open();
                    maker.VoidQuery($"DELETE FROM BooksToReaders WHERE r_id = {reader.ID} and b_id={book.ID}", con);
                }
                else
                {
                    (Owner as MainWindow).CallExceptionWindow("Книга, либо читатель не выбраны");
                    return;
                }
              }
              catch (Exception exp)
              {
                  (Owner as MainWindow).CallExceptionWindow($"Что-то пошло не так :(\n+{exp.Message}");
                  return;
              }

              ChooseBookTextBox.Text = "";
              ChooseReaderTextBox.Text = "";
              (Owner as MainWindow).CallAcceptWindow("Книга возвращена успешно");

        }
    }
}
