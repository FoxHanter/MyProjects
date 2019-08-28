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

            TB_Exception.Text = message;
        }
    }
}
