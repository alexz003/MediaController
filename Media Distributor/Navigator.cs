using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Media_Distributor
{
    public class Navigator
    {
        private Dictionary<String, String> titleList;
        private static Configuration config;
        
        public Navigator(Configuration curConfig)
        {
            config = curConfig;
            titleList = new Dictionary<string, string>();
        }

        public void setTitleList(Dictionary<String, String> newList)
        {
            titleList = newList;
        }

        //Finished is assumed to be arranged into folders with titles as the folder name
        public void updateTitleListFromFinished()
        {
            try
            {
                DirectoryInfo rootDir = new DirectoryInfo(config.FinishedShowsFolder);
                DirectoryInfo[] dirs = rootDir.GetDirectories();

                String newDirectory = "";
                foreach (DirectoryInfo di in dirs)
                {
                    String sFileName = simpleFileName(di.Name);
                    newDirectory = config.FinishedShowsFolder + sFileName;
                    if (!titleList.Keys.Contains(sFileName))
                        titleList.Add(sFileName, newDirectory);

                }
                foreach (String s in titleList.Keys)
                {
                    String str;
                    titleList.TryGetValue(s, out str);
                    Console.WriteLine(s + "\t" + str);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + "\n");
            }
        }

        public void updateTitleList()
        {
            try
            {
                DirectoryInfo rootDir = new DirectoryInfo(config.UnsortedShowsFolder);
                FileInfo[] files = rootDir.GetFiles("*.mkv");
                String newDirectory = "";
                foreach (FileInfo fi in files) 
                {
                    String sFileName = simpleFileName(fi.Name);
                    newDirectory = config.UnsortedShowsFolder + sFileName;
                    if (!titleList.Keys.Contains(sFileName))
                        titleList.Add(sFileName, newDirectory);

                }
                foreach (String s in titleList.Keys) 
                {
                    String str;
                    titleList.TryGetValue(s, out str);
                    Console.WriteLine(s + "\t" + str);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + "\n");
            }
        }

        public Dictionary<String, String> getTitleList()
        {
            return titleList;
        }

        public String simpleFileName(String originalName)
        {
            String[] extras = { "EP", "Episode", "episode", "Season", "season", "HDTV", "x264", "Dimension", "Immerse", "BRRip", "BD", "FLAC", "bit", 
                                             "E0", "S0", "S1", "S2", "S3", "S4", "S5", "X1", "X2", "X3", "X4", "X5", "Subs", "Eng", "English",
                                             "480p", "720p", "1080p", "Webrip", "AAC", "Blu-Ray", "BR"
                                         };

            String[] brackets = { "{", "[", "(", "<"};
            String[] closers = {"}", "]", ")", ">"};
            String name = originalName;

            if(name.Contains("."))
                name = name.Remove(name.LastIndexOf('.'));
            name = name.Replace(".", " ");

            foreach(String s in extras)
                name = Regex.Replace(name, s, "", RegexOptions.IgnoreCase);
            

            for (int i = 0; i < brackets.Length; i++)
            {
                while (name.Contains(brackets[i]))
                {
                    int index1 = name.IndexOf(brackets[i]);
                    int index2 = name.IndexOf(closers[i]);
                    name = name.Remove(index1, index2 - index1 + 1);
                }
            }

            name = name.Replace(" - ", " ");
            name = name.Replace(" -", " ");
            name = name.Replace("- ", " ");

            name = Regex.Replace(name, @"\d", "");

            while (name.IndexOf(' ') == 0)
                name = name.Substring(1);

            while (name.LastIndexOf(' ') == name.Length - 1)
                name = name.Remove(name.LastIndexOf(' '));

            return name;
        }

        /*
        public void sortSubFolders()
        {
            try
            {
                DirectoryInfo dir = new DirectoryInfo(topLocation);
                FileInfo[] files = dir.GetFiles();
                DirectoryInfo[] allDirs = dir.GetDirectories();

                foreach (String s in titleList.Keys)
                {
                    if(!directoyExists(s, allDirs))
                        Directory.CreateDirectory(topLocation + s);
                    
                        

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        */
        
        private bool directoyExists(String dirName, DirectoryInfo[] dirs)
        {
            foreach (DirectoryInfo di in dirs)
            {
                if (di.Name.Equals(dirName))
                    return true;
            }
            return false;
        }
    }
}
