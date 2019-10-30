using LibraryFunctional;
using System;
using System.Linq;
using System.Windows;

namespace GUI
{
    /// <summary>
    /// Interaction logic for ReadersCatalogWindow.xaml
    /// </summary>
    public partial class ReadersCatalogWindow : Window
    {
        private Library _library;

        public ReadersCatalogWindow(Library library)
        {
            InitializeComponent();
            _library = library;
            ListBoxShowAllItems();
        }

        private void AddReaderButton_Click(object sender, RoutedEventArgs e)
        {
            var addReaderWindow = new AddReaderWindow(_library.Readers);
            addReaderWindow.Owner = this;

            if (addReaderWindow.ShowDialog() == true)
                addReaderWindow.Show();

            UpdateCatalog();
        }

        private void DeleteReaderButton_Click(object sender, RoutedEventArgs e)
        {
            if (ReadersCatalogListBox.SelectedItem != null)
            {
                try
                {
                    Reader reader = _library.Readers.GetAllItems().First(x => x.ToString().Equals(ReadersCatalogListBox.SelectedItem.ToString()));
                    _library.Readers.Delete(reader.ID);
                }
                catch (Exception exp)
                {
                    (Owner as MainWindow).CallExceptionWindow($"Что-то пошло не так :(\n+{exp.Message}");
                    return;
                }

               (Owner as MainWindow).CallAcceptWindow($"Читатель успешно удален\nОбновите список");
            }
            else
            {
                (Owner as MainWindow).CallExceptionWindow("Сначала выберите читателя, кликнув на его имя");
                return;
            }

            UpdateCatalog();
        }

        private void UpdateCatalog()
        {
            ListBoxShowAllItems();
        }

        private void ListBoxShowAllItems()
        {
            ReadersCatalogListBox.Items.Clear();

            foreach (var item in _library.Readers.GetAllItems())
                ReadersCatalogListBox.Items.Add(item);
        }

        private void ReadersCatalogListBox_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Reader reader = _library.Readers.GetAllItems().First(x => x.ToString().Equals(ReadersCatalogListBox.SelectedItem.ToString()));

            var infoAboutReaderWindow = new InfoAboutReaderWindow(reader, _library.Books);
            infoAboutReaderWindow.Owner = this;

            if (infoAboutReaderWindow.ShowDialog() == true)
                infoAboutReaderWindow.Show();
        }
    }
}
