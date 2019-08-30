using LibraryFunctional;
using System;
using System.Data.OleDb;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace GUI
{
    /// <summary>
    /// Логика взаимодействия для GiveBookWindow.xaml
    /// </summary>
    public partial class GiveBookWindow : Window
    {
        Library _library;
        public GiveBookWindow(Library library)
        {
            InitializeComponent();
            _library = library;
        }

        private void AcceptButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var book = _library.Books.GetAllItems().First(x => x.ToString().Equals(ChooseBookTextBox.Text));
                var reader = _library.Readers.GetAllItems().First(x => x.ToString().Equals(ChooseReaderTextBox.Text));

                if (book != null && reader != null)
                    if (book.Count == 0)
                    {
                        (this.Owner as MainWindow).CallExceptionWindow("Книга закончилась");
                        return;
                    }
                    else
                    {
                        _library.Books.Update(book, -1);
                        var book1 = new BookToReader();
                        book1.BookId = book.ID;
                        book1.ReaderId = reader.ID;
                        DatabaseQueryMaker maker = new DatabaseQueryMaker();
                        var con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=LibraryDataBase.mdb;");
                        con.Open();
                        maker.VoidQuery($"INSERT INTO BooksToReaders (b_id, r_id, t_in, t_out) VALUES('{book1.BookId}','{book1.ReaderId}','{Din.SelectedDate}','{Dout.SelectedDate}')", con);
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
            (Owner as MainWindow).CallAcceptWindow("Книга выдана читателю успешно");

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
            var selectBookWindow = new SelectBook(_library.Books);
            selectBookWindow.Owner = this;

            if (selectBookWindow.ShowDialog() == true)
                selectBookWindow.Show();
        }
    }
}
