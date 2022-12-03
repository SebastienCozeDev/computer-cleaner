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
using ComputerCleaner.Utils;

namespace ComputerCleaner
{
    /// <summary>
    /// Classe d'interaction logique pour <c>MainWindow.xaml</c>.
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Informations du répertoire temporaire de Windows.
        /// </summary>
        private DirectoryInfo winTemp;

        /// <summary>
        /// Informations du répertoire temporatoire des applications.
        /// </summary>
        private DirectoryInfo appTemp;

        /// <summary>
        /// Crée une instance de <c>MainWindow</c>.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            winTemp = new DirectoryInfo(@"C:\Windows\Temp");
            appTemp = new DirectoryInfo(System.IO.Path.GetTempPath());
        }

        private void UpdateButtonClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Votre version du logiciel est à jour.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            LogManager.AddInLog("Information", "Your software version is up to date.");
        }

        private void CleanButtonClick(object sender, RoutedEventArgs e)
        {
            string content = "NETTOYER";
            LogManager.AddInLog("Information", "Cleaning in progress...");
            cleanButton.IsEnabled = false;
            cleanButton.Content = "Nettoyage en cours...";
            Clipboard.Clear();
            try
            {
                Cleaner.ClearTempData(winTemp);
            } catch (Exception ex)
            {
                LogManager.AddInLog("Error", ex.Message);
            }
            try
            {
                Cleaner.ClearTempData(appTemp);
            }
            catch (Exception ex)
            {
                LogManager.AddInLog("Error", ex.Message);
            }
            LogManager.AddInLog("Information", "Cleaning done.");
            cleanButton.IsEnabled = true;
            cleanButton.Content = content;
            title.Content = "Nettoyage effectué";
            space.Content = "0 Mb";
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

        private void AnalyzeButtonClick(object sender, RoutedEventArgs e)
        {
            AnalyseFolder();
        }

        private void AnalyseFolder()
        {
            Console.WriteLine("Start of analysis");
            LogManager.AddInLog("Information", "Start of analysis");
            long totalSize = 0;
            try
            {
                totalSize += Cleaner.DirSize(winTemp) / 1000000; // On divise par un million pour avoir la taille en méga.
                totalSize += Cleaner.DirSize(appTemp) / 1000000; // On divise par un million pour avoir la taille en méga.
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur : Impossible d'analyser les fichiers : Il se peut que vous n'êtes administrateur sur cette machine. Message : " + ex.Message, "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                LogManager.AddInLog("Error", ex.Message);
            }
            space.Content = totalSize + " Mb";
            date.Content = DateTime.Today;
            title.Content = "Analyse effectué";
        }
    }
}
