using LibraryFunctional;
using System;
using System.Linq;
using System.Windows;

namespace GUI
{
    /// <summary>
    /// Логика взаимодействия для TakeBookWindow.xaml
    /// </summary>
    public partial class TakeBookWindow : Window
    {
        private Library _library;

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
                    _library.TakenBooks.Delete(reader.ID, book.ID);
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
