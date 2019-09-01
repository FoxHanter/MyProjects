using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using LibraryFunctional;

namespace GUI
{
    /// <summary>
    /// Interaction logic for SelectReader.xaml
    /// </summary>
    public partial class SelectReader : Window
    {
        private ReaderRepository _repository;

        public SelectReader(ReaderRepository repository)
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
            Reader reader= _repository.GetAllItems().First(x => x.ToString().Equals(tb.Text));

            if (reader!=null)
            {
                if (Owner is TakeBookWindow) (Owner as TakeBookWindow).ChooseReaderTextBox.Text = reader.ToString();
                if (Owner is GiveBookWindow) (Owner as GiveBookWindow).ChooseReaderTextBox.Text = reader.ToString();
                (this.Owner.Owner as MainWindow).CallAcceptWindow($"Выбран читатель\n{reader.ToString()}");
                this.Close();
            }
            else
            {
                (this.Owner.Owner as MainWindow).CallExceptionWindow("Такого читателя не существует");
                return;
            }
        }

    }
}
