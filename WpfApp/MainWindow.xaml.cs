using System.Windows;
using WpfApp.ViewModel;

namespace WpfApp
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Constructeur de la Fenêtre principale
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new HomeViewModel();
        }

        private void ListeEleve_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void ListeEleve_Loaded_1(object sender, RoutedEventArgs e)
        {

        }

        private void ListeEleve_Loaded_2(object sender, RoutedEventArgs e)
        {

        }
    }
}
