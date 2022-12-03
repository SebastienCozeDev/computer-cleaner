using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ComputerCleaner
{
    /// <summary>
    /// Classe gérant les logs.
    /// </summary>
    public class LogManager
    {
        /// <summary>
        /// Chemin du fichier de logs principal.
        /// </summary>
        private const string LOG_FILE = "cleaner.log";

        /// <summary>
        /// Ajoute une ligne dans le fichier de logs.
        /// </summary>
        /// <param name="type">Type du log.</param>
        /// <param name="log">Content du log.</param>
        public static void AddInLog(string type, string log)
        {
            string[] content;
            try
            {
                content = new string[File.ReadAllLines(LOG_FILE).Length + 1];
                content = File.ReadAllLines(LOG_FILE);
                foreach (string line in content)
                {
                    Console.WriteLine(line);
                }
                content[content.Length - 1] = "[" + type.ToUpper() + "] " + log;
                File.WriteAllLines(LOG_FILE, content);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                File.WriteAllText(LOG_FILE, "[" + type.ToUpper() + "] " + log);
            }
        }
    }
}
