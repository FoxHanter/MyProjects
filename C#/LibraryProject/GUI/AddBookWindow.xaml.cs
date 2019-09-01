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
                int count = int.Parse(BookCountTextBox.Text);
                BookNameTextBox.Clear();
                BookCountTextBox.Clear();
                _books.Create(new Book(name,count));
            }
            catch (Exception exp)
            {
                (Owner.Owner as MainWindow).CallExceptionWindow($"Что-то пошло не так :(\n+{exp.Message}");
                return;
            }

            (Owner.Owner as MainWindow).CallAcceptWindow("Книга добавлена успешно");
        }
    }
}
