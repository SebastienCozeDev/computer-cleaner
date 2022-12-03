using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerCleaner.Utils
{
    /// <summary>
    /// Cette classe correspond au nettoyeur.
    /// </summary>
    public class Cleaner
    {
        /// <summary>
        /// Donne le poids d'un dossier.
        /// </summary>
        /// <param name="dir">Dossier.</param>
        /// <returns>Le poids du dossier.</returns>
        public static long DirSize(DirectoryInfo dir)
        {
            if (dir == null) { return 0; }
            return dir.GetFiles().Sum(fi => fi.Length) + dir.GetDirectories().Sum(fi => DirSize(fi));
        }

        /// <summary>
        /// Supprimer le contenu d'un dossier.
        /// </summary>
        /// <param name="dir">Le dossier en question.</param>
        public static void ClearTempData(DirectoryInfo dir)
        {
            int totalRemoveFile = 0;

            foreach (FileInfo fi in dir.GetFiles())
            {
                try
                {
                    fi.Delete();
                    Console.WriteLine(fi.FullName);
                    LogManager.AddInLog("Deletion", fi.FullName);
                    totalRemoveFile++;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    LogManager.AddInLog("Error", ex.Message);
                }
            }
            foreach (DirectoryInfo di in dir.GetDirectories())
            {
                try
                {
                    di.Delete(true);
                    Console.WriteLine(di.FullName);
                    LogManager.AddInLog("Deletion", di.FullName);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    LogManager.AddInLog("Error", ex.Message);
                }
            }
        }
    }
}
