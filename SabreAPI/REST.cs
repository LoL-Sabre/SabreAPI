using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SabreAPI
{
    public class REST
    {
        /// <summary>
        /// Gets all of the currently released champions on both Live and PBE servers
        /// </summary>
        /// <returns></returns>
        public static List<string> GetChampions(bool keepFiles)
        {
            WebClient wc = new WebClient();
            List<string> Champions = new List<string>();
            string urlToDownload = "https://drive.google.com/uc?export=download&id=0Bz9aB-8O_UqfSTE0NHcxVXBOTnc";
            if(keepFiles)
            {
                wc.DownloadFile(urlToDownload, "champions.txt");
                Champions.AddRange(File.ReadAllLines("champions.txt"));
            }
            else
            {
                wc.DownloadFile(urlToDownload, "temp");
                Champions.AddRange(File.ReadAllLines("temp"));
                File.Delete("temp");
            }
            return Champions;
        }
        /// <summary>
        /// Gets all of the currently availible characters
        /// </summary>
        /// <returns></returns>
        public static List<string> GetCharacters(bool keepFiles)
        {
            WebClient wc = new WebClient();
            List<string> Characters = new List<string>();
            string urlToDownload = "https://drive.google.com/uc?export=download&id=0Bz9aB-8O_UqfZG9GVVdPM293WHM";
            if (keepFiles)
            {
                wc.DownloadFile(urlToDownload, "characters.txt");
                Characters.AddRange(File.ReadAllLines("characters.txt"));
            }
            else
            {
                wc.DownloadFile(urlToDownload, "temp");
                Characters.AddRange(File.ReadAllLines("temp"));
                File.Delete("temp");
            }
            return Characters;
        }
        /// <summary>
        /// Generates characters from a specified path
        /// </summary>
        /// <param name="pathToGenerateFrom"> Path to generate the characters from. Should have double \. Example: C:\\Wooxy\\extract\\files\\lol_game_client\\DATA\\Characters\\ </param>
        /// <param name="outputPath"> Path to save the file to. Will be: outputPath + characters.txt </param>
        /// <returns></returns>
        public static List<string> GetCharacters(string pathToGenerateFrom, string outputPath)
        {
            List<string> Characters = new List<string>();
            string[] temp = Directory.GetDirectories(pathToGenerateFrom);
            for (int i = 0; i < temp.Length; i++)
            { 
                temp[i] = temp[i].Remove(0, pathToGenerateFrom.Length);
            }
            Characters.AddRange(temp);
            StreamWriter sw = new StreamWriter(File.OpenWrite(outputPath + "characters.txt"));
            foreach(string s in Characters)
            {
                if (Characters.LastOrDefault() == s) sw.Write(s);
                else sw.Write(s + Environment.NewLine);
            }
            sw.Flush(); sw.Close();
            return Characters;
        }
    }
}
