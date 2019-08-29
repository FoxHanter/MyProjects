using LibraryFunctional;
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

namespace GUI
{
    /// <summary>
    /// Interaction logic for SelectBook.xaml
    /// </summary>
    public partial class SelectBook : Window
    {
        BookRepository _repository;

        public SelectBook(BookRepository repository)
        {
            InitializeComponent();
            _repository = repository;
            TextBoxShowAllItems();
        }

        private void ChooseReaderListBox_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            var item = ItemsControl.ContainerFromElement(ChooseReaderListBox, e.OriginalSource as DependencyObject) as ListBoxItem;
            tb.Text = item.DataContext.ToString();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            ChooseReaderListBox.Items.Clear();
            if (tb.Text != "")
            {
                var result = _repository.GetAllItems().Where(x => x.Name.ToLower().Contains(tb.Text.ToLower()) || x.ID.ToString().Contains(tb.Text)).ToArray();

                foreach (var item in result)
                    if (ChooseReaderListBox.Items.Count < 10)
                        ChooseReaderListBox.Items.Add(item);
            }
            else
            {
                TextBoxShowAllItems();
            }
        }

        private void TextBoxShowAllItems()
        {
            ChooseReaderListBox.Items.Clear();
            foreach (var item in _repository.GetAllItems())
                ChooseReaderListBox.Items.Add(item);
        }

        private void B_Click(object sender, RoutedEventArgs e)
        {
            Book book = _repository.GetAllItems().First(x => x.ToString().Equals(tb.Text));

            if (book != null)
            {
                (this.Owner as GiveBookWindow).ChooseBookTextBox.Text = book.ToString();
                (this.Owner.Owner as MainWindow).CallAcceptWindow($"Выбрана книга\n{book.ToString()}");
                this.Close();
            }
            else
            {
                (this.Owner.Owner as MainWindow).CallExceptionWindow("Такой книги не существует");
                return;
            }
        }
    }
}
