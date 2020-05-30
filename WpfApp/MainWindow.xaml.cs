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
    }
}
