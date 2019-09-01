using System;
using System.Linq;
using System.Windows;
using LibraryFunctional;

namespace GUI
{
    /// <summary>
    /// Interaction logic for BooksCatalogWindow.xaml
    /// </summary>
    public partial class BooksCatalogWindow : Window
    {
        private BookRepository _repository;

        public BooksCatalogWindow(BookRepository repository)
        {
            InitializeComponent();
            _repository = repository;
            ListBoxShowAllItems();
        }

        private void AddBookButton_Click(object sender, RoutedEventArgs e)
        {
            var addBookWindow = new AddBookWindow(_repository);
            addBookWindow.Owner = this;

            if (addBookWindow.ShowDialog() == true)
                addBookWindow.Show();
        }

        private void DeleteBookButton_Click(object sender, RoutedEventArgs e)
        {
            if (BooksCatalogListBox.SelectedItem != null)
            {
                try
                {
                    Book book = _repository.GetAllItems().First(x => x.ToString().Equals(BooksCatalogListBox.SelectedItem.ToString()));
                    _repository.Delete(book.ID);
                }
                catch (Exception exp)
                {
                    (Owner as MainWindow).CallExceptionWindow($"Что-то пошло не так :(\n+{exp.Message}");
                    return;
                }

                (Owner as MainWindow).CallAcceptWindow($"Книга успешно удалена\nОбновите список");
            }
            else
            {
                (Owner as MainWindow).CallExceptionWindow("Сначала выберите книгу, кликнув на ее название");
                return;
            }
        }

        private void UpdateCatalogButton_Click(object sender, RoutedEventArgs e)
        {
            ListBoxShowAllItems();
        }

        private void ListBoxShowAllItems()
        {
            BooksCatalogListBox.Items.Clear();

            foreach (var item in _repository.GetAllItems())
                BooksCatalogListBox.Items.Add(item);
        }
    }
}
