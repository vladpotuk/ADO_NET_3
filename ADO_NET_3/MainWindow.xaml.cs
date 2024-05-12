using System.Windows;

namespace ADO_NET_3
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (DataBase.TestConnection())
            {
                MessageBox.Show("Connection successful!");
                
            }
            else
            {
                MessageBox.Show("Connection failed!");
            }
        }
    }
}
