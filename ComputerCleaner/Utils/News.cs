using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ComputerCleaner.Utils
{
    public class News
    {
        /// <summary>
        /// Donne l'annonce.
        /// </summary>
        /// <param name="url">URL de l'annonceur.</param>
        /// <returns>L'annonce.</returns>
        public static string CheckNews(string url)
        {
            if (string.IsNullOrEmpty(url))
            {
                return "";
            }
            using (WebClient client = new WebClient())
            {
                try
                {
                    string actu = client.DownloadString(url);
                    return actu;
                } catch (Exception e)
                {
                    return "";
                }
            }
        }

    }
}
