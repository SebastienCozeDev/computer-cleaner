using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ComputerCleaner.Utils
{
    public class Save
    {
        /// <summary>
        /// Nom du fichier où est sauvegardé la dernière date d'analyse.
        /// </summary>
        private const string DATE_FILE = "date.data";

        /// <summary>
        /// Sauvegarder la dernière date d'analyse.
        /// </summary>
        /// <param name="dateTime">La date à sauvergarder.</param>
        public static void SaveLastDateAnalysis(string dateTime)
        {
            string date = dateTime.ToString();
            try
            {
                File.WriteAllText(DATE_FILE, date);
                LogManager.AddInLog("Date", date);
            } catch (Exception ex) { LogManager.AddInLog("Error", ex.Message); }
        }

        /// <summary>
        /// Obtenir la date de la dernière analyse.
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static string GetLastDateAnalysis()
        {
            string date =  File.ReadAllText(DATE_FILE);
            if (string.IsNullOrEmpty(date))
            {
                return "Jamais";
            }
            return date;
        }
    }
}
