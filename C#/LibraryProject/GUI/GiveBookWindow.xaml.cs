using LibraryFunctional;
using System;
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
            InitPopupReader(ChooseReaderTextBox, ChooseReaderPopup, ChooseReaderListBox);
            InitPopupBook(ChooseBookTextBox, ChooseBookPopup, ChooseBookListBox);
        }

        private void InitPopupReader(TextBox textBox, Popup popup, ListBox listBox)
        {
            textBox.PreviewKeyUp += (sender, e) =>
            {
                listBox.Items.Clear();
                var result = _library.Readers.GetAllItems().Where(x => x.Name.ToLower().Contains(textBox.Text.ToLower()) || x.ID.ToString().Contains(textBox.Text)).ToArray();

                foreach (var item in result)
                    if (listBox.Items.Count < 10)
                        listBox.Items.Add(item);

                if (listBox.Items.Count > 0) popup.IsOpen = true;
                if (textBox.Text.Length == 0) popup.IsOpen = false;

            };

            textBox.LostFocus += (sender, e) =>
            {
                popup.IsOpen = false;
            };
        }

        private void InitPopupBook(TextBox textBox, Popup popup, ListBox listBox)
        {
            textBox.PreviewKeyUp += (sender, e) =>
            {
                listBox.Items.Clear();
                var result = _library.Books.GetAllItems().Where(x => x.Name.ToLower().Contains(textBox.Text.ToLower()) || x.ID.ToString().Contains(textBox.Text)).ToArray();

                foreach (var item in result)
                    if (listBox.Items.Count < 10)
                        listBox.Items.Add(item);

                if (listBox.Items.Count > 0) popup.IsOpen = true;
                if (textBox.Text.Length == 0) popup.IsOpen = false;

            };

            textBox.LostFocus += (sender, e) =>
            {
                popup.IsOpen = false;
            };
        }

        private void ChooseReaderListBox_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            var item = ItemsControl.ContainerFromElement(ChooseReaderListBox, e.OriginalSource as DependencyObject) as ListBoxItem;
            ChooseReaderTextBox.Text = item.DataContext.ToString();
            ChooseReaderPopup.IsOpen = false;
        }

        private void ChooseBookListBox_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            var item = ItemsControl.ContainerFromElement(ChooseBookListBox, e.OriginalSource as DependencyObject) as ListBoxItem;
            ChooseBookTextBox.Text = item.DataContext.ToString();
            ChooseBookPopup.IsOpen = false;
        }

        private void AcceptButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var book = _library.Books.GetAllItems().First(x => x.ToString().Equals(ChooseBookTextBox.Text));
                var reader = _library.Readers.GetAllItems().Where(x => x.ToString().Equals(ChooseReaderTextBox.Text));

                if (book != null && reader != null)
                    if (book.Count == 0)
                    {
                        (this.Owner as MainWindow).CallExceptionWindow("Книга закончилась");
                        return;
                    }
                    else
                        _library.Books.Update(book, -1);
                else
                {
                    (this.Owner as MainWindow).CallExceptionWindow("Книга, либо читатель не выбраны");
                    return;
                }
            }
            catch (Exception exp)
            {
                (this.Owner as MainWindow).CallExceptionWindow($"Что-то пошло не так :(\n+{exp.Message}");
                return;
            }

            ChooseBookTextBox.Text = "";
            ChooseReaderTextBox.Text = "";
            (this.Owner as MainWindow).CallAcceptWindow("Книга выдана читателю успешно");

        }
    }
}
