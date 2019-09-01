using System;
using System.Collections.Generic;
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
using LibraryFunctional;
namespace GUI
{
    /// <summary>
    /// Interaction logic for InfoAboutReaderWindow.xaml
    /// </summary>
    public partial class InfoAboutReaderWindow : Window
    {
        private BookRepository _repository;
        private Reader _reader;
        public InfoAboutReaderWindow(Reader reader, BookRepository repository)
        {
            InitializeComponent();
            _repository = repository;
            _reader = reader;
            ShowInfo();
        }

        private void ShowInfo()
        {
            NameLabel.Content = _reader.Name;
            IDLabel.Content = _reader.ID;
            ShowBooks();
        }

        private void ShowBooks()
        {
            BooksListBox.Items.Clear();

            foreach (var item in _repository.GetAllItems(_reader.ID))
                BooksListBox.Items.Add(item);
        }
    }
}
