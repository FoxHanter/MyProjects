using LibraryFunctional;
using System;
using System.Windows;

namespace GUI
{
    /// <summary>
    /// Логика взаимодействия для AddReaderWindow.xaml
    /// </summary>
    public partial class AddReaderWindow : Window
    {
        private ReaderRepository _readers;

        public AddReaderWindow(ReaderRepository readers)
        {
            InitializeComponent();
            _readers = readers;
        }

        private void AcceptButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string name = ReaderNameTextBox.Text;
                ReaderNameTextBox.Clear();
                _readers.Create(new Reader(name));
            }
            catch (Exception exp)
            {
                (Owner.Owner as MainWindow).CallExceptionWindow($"Что-то пошло не так :(\n+{exp.Message}");
                return;
            }
               
            (Owner.Owner as MainWindow).CallAcceptWindow("Читатель зарегистрирован успешно");           
        }
    }
}
