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

            TB_Accept.Text = message;
        }
    }
}
