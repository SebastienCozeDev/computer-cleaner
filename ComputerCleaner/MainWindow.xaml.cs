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
using System.Threading;
using System.Windows.Media.Effects;

namespace ComputerCleaner
{
    /// <summary>
    /// Classe d'interaction logique pour <c>MainWindow.xaml</c>.
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// URL pour obtenir la dernière annonce.
        /// </summary>
        private const string URL_FOR_NEWS = "https://computercleaner.sebastiencoze.repl.co/news.txt";

        /// <summary>
        /// URL pour obtenir la dernière version.
        /// </summary>
        private const string URL_FOR_VERSION = "https://computercleaner.sebastiencoze.repl.co/version.txt";

        /// <summary>
        /// URL du site web.
        /// </summary>
        private const string URL_WEBSITE = "https://sebastiencozedev.github.io/e-portfolio/";

        private const string VERSION = "v.1.0.1";

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
            coyrightLabel.Content = "Copyright " + VERSION + " " + DateTime.Today.Year + " - Coze Sébastien";
            string newsContent = News.CheckNews(URL_FOR_NEWS);
            if (newsContent != String.Empty)
            {
                news.Content= newsContent;
                news.Visibility = Visibility.Visible;
                newsRectangle.Visibility = Visibility.Visible;
            }
            date.Content = Save.GetLastDateAnalysis();
        }

        /// <summary>
        /// Cette méthode est appelé quand l'utilisateur clique sur le bouton de mise à jour.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateButtonClick(object sender, RoutedEventArgs e)
        {
            string newVersionContent = News.CheckNews(URL_FOR_VERSION);
            if (newVersionContent != VERSION && newVersionContent != String.Empty)
            {
                MessageBox.Show("Une mise à jour est disponible : " + newVersionContent, "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                LogManager.AddInLog("Information", "Your software version is not up to date.");
                try
                {
                    Process.Start(new ProcessStartInfo(URL_WEBSITE)
                    {
                        UseShellExecute = true,
                    });
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur : " + ex.Message, "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                    LogManager.AddInLog("Error", ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Votre version du logiciel est à jour.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                LogManager.AddInLog("Information", "Your software version is up to date.");
            }
        }

        /// <summary>
        /// Cette méthode est appelé quand l'utilisateur clique sur le bouton de nettoyage.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CleanButtonClick(object sender, RoutedEventArgs e)
        {
            string content = "NETTOYER";
            cleanButton.IsEnabled = false;
            cleanButton.Content = "Nettoyage en cours...";
            LogManager.AddInLog("Information", "Cleaning in progress...");
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

        /// <summary>
        /// Cette méthode est appelé quand l'utilisateur clique sur le bouton de l'historique.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HistoryButtonClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Cette fonctionnalité n'est pas disponible pour cette version du logiciel.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            LogManager.AddInLog("Information", "This feature is not available for this version of the software.");
        }

        /// <summary>
        /// Cette méthode est appelé quand l'utilisateur clique sur le bouton pour accéder au site web.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WebsiteButtonClick(object sender, RoutedEventArgs e)
        {
            try
            {
                Process.Start(new ProcessStartInfo(URL_WEBSITE)
                {
                    UseShellExecute = true,
                });
            } catch (Exception ex)
            {
                MessageBox.Show("Erreur : " + ex.Message, "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                LogManager.AddInLog("Error", ex.Message);
            }
        }

        /// <summary>
        /// Cette méthode est appelé quand l'utilisateur clique sur le bouton d'analyse.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AnalyzeButtonClick(object sender, RoutedEventArgs e)
        {
            AnalyseFolder();
        }

        /// <summary>
        /// Analyser les dossiers.
        /// </summary>
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
            Save.SaveLastDateAnalysis(DateTime.Now.ToString());
            date.Content =  Save.GetLastDateAnalysis();
            title.Content = "Analyse effectuée";
        }
    }
}
