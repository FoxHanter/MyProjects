using LibraryFunctional;
using System;
using System.Windows;

namespace GUI
{
    /// <summary>
    /// Логика взаимодействия для AddBookWindow.xaml
    /// </summary>
    public partial class AddBookWindow : Window
    {
        private BookRepository _books;

        public AddBookWindow(BookRepository books)
        {
            InitializeComponent();
            _books = books;
        }

        private void AcceptButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string name = BookNameTextBox.Text;
                BookNameTextBox.Clear();
                _books.Create(new Book(name));
            }
            catch (Exception exp)
            {
                (this.Owner as MainWindow).CallExceptionWindow($"Что-то пошло не так :(\n+{exp.Message}");
                return;
            }

            (this.Owner as MainWindow).CallAcceptWindow("Книга добавлена успешно");

        }
    }
}
