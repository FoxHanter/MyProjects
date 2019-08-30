using LibraryFunctional;
using System.Data.OleDb;
using System.Windows;

namespace GUI
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Library _library;

        public MainWindow()
        {
            InitializeComponent();
            _library = new Library(new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=LibraryDataBase.mdb;"), "Books", "Readers");

            this.Closing += MainWindow_Closing;
        }

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _library.CloseConnection();
        }

        private void NewReaderButton_Click(object sender, RoutedEventArgs e)
        {
            var addReaderWindow = new AddReaderWindow(_library.Readers);
            addReaderWindow.Owner = this;

            if (addReaderWindow.ShowDialog() == true)
                addReaderWindow.Show();
        }

        private void NewBookButton_Click(object sender, RoutedEventArgs e)
        {

            var addBookWindow = new AddBookWindow(_library.Books);
            addBookWindow.Owner = this;

            if (addBookWindow.ShowDialog() == true)
                addBookWindow.Show();
        }

        private void GiveBookButton_Click(object sender, RoutedEventArgs e)
        {
            var giveBookWindow = new GiveBookWindow(_library);
            giveBookWindow.Owner = this;

            if (giveBookWindow.ShowDialog() == true)
                giveBookWindow.Show();
        }

        private void TakeBookButton_Click(object sender, RoutedEventArgs e)
        {
           var takeBookWindow = new TakeBookWindow(_library);
            takeBookWindow.Owner = this;

            if (takeBookWindow.ShowDialog() == true)
                takeBookWindow.Show();
        }

        public void CallExceptionWindow(string message)
        {
            var exceptionWindow = new ExceptionWindow(message);
            exceptionWindow.Owner = this;

            if (exceptionWindow.ShowDialog() == true)
                exceptionWindow.Show();
        }

        public void CallAcceptWindow(string message)
        {
            var acceptWindow = new AcceptWindow(message);
            acceptWindow.Owner = this;

            if (acceptWindow.ShowDialog() == true)
                acceptWindow.Show();
        }
    }
}
