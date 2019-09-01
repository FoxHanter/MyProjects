using System.Windows;

namespace GUI
{
    /// <summary>
    /// Interaction logic for AcceptWindow.xaml
    /// </summary>
    public partial class AcceptWindow : Window
    {
        public AcceptWindow(string message)
        {
            InitializeComponent();

            AcceptTextBlock.Text = message;
        }

        private void AcceptButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
