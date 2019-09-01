using System.Windows;

namespace GUI
{
    /// <summary>
    /// Interaction logic for ExceptionWindow.xaml
    /// </summary>
    public partial class ExceptionWindow : Window
    {
        public ExceptionWindow(string message)
        {
            InitializeComponent();

            ExceptionTextBlock.Text = message;
        }

        private void AcceptButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
