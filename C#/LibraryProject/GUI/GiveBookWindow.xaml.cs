using LibraryFunctional;
using System;
using System.Linq;
using System.Windows;

namespace GUI
{
    /// <summary>
    /// Логика взаимодействия для GiveBookWindow.xaml
    /// </summary>
    public partial class GiveBookWindow : Window
    {
        private Library _library;

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
                        var bookToReader = new BookToReader(book.ID, reader.ID, DateOfIssuePicker.SelectedDate, ReturnDatePicker.SelectedDate);
                        _library.TakenBooks.Create(bookToReader);
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
