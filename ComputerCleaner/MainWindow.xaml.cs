using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace ComputerCleaner
{
    /// <summary>
    /// Classe d'interaction logique pour <c>MainWindow.xaml</c>.
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Crée une instance de <c>MainWindow</c>.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
        }

        private void UpdateButtonClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Votre version du logiciel est à jour.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            LogManager.AddInLog("Information", "Your software version is up to date.");
        }

        private void CleanButtonClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Cette fonctionnalité n'est pas disponible pour cette version du logiciel.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            LogManager.AddInLog("Information", "This feature is not available for this version of the software.");
        }

        private void HistoryButtonClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Cette fonctionnalité n'est pas disponible pour cette version du logiciel.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            LogManager.AddInLog("Information", "This feature is not available for this version of the software.");
        }

        private void WebsiteButtonClick(object sender, RoutedEventArgs e)
        {
            try
            {
                Process.Start(new ProcessStartInfo("https://sebastiencozedev.github.io/e-portfolio/")
                {
                    UseShellExecute = true,
                });
            } catch (Exception ex)
            {
                MessageBox.Show("Erreur : " + ex.Message, "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                LogManager.AddInLog("Error", ex.Message);
            }
        }

    }
}
