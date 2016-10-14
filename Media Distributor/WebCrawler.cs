using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Media_Distributor
{
    public class WebCrawler
    {
        private DatabaseConnection connection;

        public String SearchTitle { get; set; }
        public TitleData Result { get; set; }

        public WebCrawler()//DatabaseConnection con)
        {
            //connection = con;
        }

        public void crawl(String title)
        {
            SearchTitle = title;
            List<TitleData> results = getSearchResults2(title, 10);
            TitleData narrowedResult;
            if (narrowSearch(results, title, out narrowedResult))
            {
                Result = narrowedResult;// Console.WriteLine("Found result: " + title + "--\t" + narrowedResult.Title);
            }
            else
            {
                Console.WriteLine("No result found for " + title);
                if(results.Count > 0)
                {
                    using (SearchResultChoiceForm form = new SearchResultChoiceForm(results, title))
                    {
                        if(form.ShowDialog() == DialogResult.OK)
                        {
                            Result = results.ElementAt(form.listIndex%results.Count);
                        }
                    }
                }
            }
            
        }

        public List<TitleData> getSearchResults2(String searchTitle, int maxResults)
        {

            String[] splitTitle = searchTitle.Split(' ');
            List<TitleData> searchResults = new List<TitleData>();
            int retryCount = 0;
            bool requestFinished = false;
            while (!requestFinished && retryCount < 5)
            {
                try
                {
                    String base64 = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes("Distributor:MALdistro"));
                    HttpWebRequest client = (HttpWebRequest)WebRequest.Create("http://myanimelist.net/api/anime/search.xml?q=" + searchTitle.ToLower());
                    client.ContentType = "application/xml";
                    client.Method = "GET";
                    client.Headers.Add("Authorization", "Basic " + base64);
                    client.Timeout = 5000;

                    HttpWebResponse response = (HttpWebResponse)client.GetResponse();


                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        StreamReader sr = new StreamReader(response.GetResponseStream());
                        String xml = sr.ReadToEnd();
                        StringReader sreader = new StringReader(xml);
                        using (XmlReader reader = XmlReader.Create(sreader))
                        {
                            String title, english, type, synopsis, imageURL;
                            String[] synonyms;
                            try
                            {
                                for (int count = 0; count < maxResults && reader.ReadToFollowing("entry"); )
                                {
                                    reader.ReadToFollowing("title");
                                    title = reader.ReadElementContentAsString();
                                    TitleData item = new TitleData(title);
                                    if (!title.Equals(""))
                                    {
                                        reader.ReadToFollowing("english");
                                        english = reader.ReadElementContentAsString();

                                        reader.ReadToFollowing("synonyms");
                                        synonyms = reader.ReadElementContentAsString().Split(new[] { "; " }, StringSplitOptions.None);

                                        reader.ReadToFollowing("type");
                                        type = reader.ReadElementContentAsString();

                                        reader.ReadToFollowing("synopsis");
                                        synopsis = reader.ReadElementContentAsString();

                                        reader.ReadToFollowing("image");
                                        imageURL = reader.ReadElementContentAsString();

                                        item.UserTitle = searchTitle;
                                        item.Title = title;
                                        item.English = english;
                                        item.Synonyms = synonyms;
                                        item.Type = type;
                                        item.Synopsis = synopsis;
                                        item.ImageURL = imageURL;

                                        searchResults.Add(item);
                                        //Console.WriteLine(title + "\t" + english + "\t" + type);
                                    }


                                }
                            }
                            catch (XmlException xmlE)
                            {
                                Console.WriteLine(xmlE.Message);
                            }
                        }
                    }
                    response.Close();
                    requestFinished = true;
                }
                catch (WebException e)
                {
                    retryCount++;
                    requestFinished = false;
                    Console.WriteLine("Failed, retrying: " + retryCount);
                    Console.WriteLine(e.Message);
                }
            }

            if(searchResults.Count == 0 && splitTitle.Length > 1)
            {
                return getSearchResults2(splitTitle[0], 15);

            }

                return searchResults;
        }

        private String titleFromURL(String url) 
        {

            return url.Substring(url.LastIndexOf('/') + 1).Replace('_', ' ');
        }

        public String simpleFileName(String name)
        {
            String[] extras = { "EP", "Episode", "episode", "Season", "season", "HDTV", "x264", "Dimension", "Immerse", "BRRip", "BD", "FLAC", "bit", 
                                             "E0", "S0", "S1", "S2", "S3", "S4", "S5", "X1", "X2", "X3", "X4", "X5", "Subs", "Eng", "English",
                                             "480p", "720p", "1080p", "Webrip", "AAC", "Blu-Ray", "BR"
                                         };

            String[] brackets = { "{", "[", "(", "<" };
            String[] closers = { "}", "]", ")", ">" };

            if (name.Contains('.'))
                name = name.Remove(name.LastIndexOf('.'));
            while(name.Contains('.'))
                name = name.Replace(".", " ");

            foreach (String s in extras)
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

            name = name.Replace(":", "");

            name = name.Replace(" - ", " ");
            name = name.Replace(" -", " ");
            name = name.Replace("- ", " ");

            name = Regex.Replace(name, @"\d", "");

            while (name.IndexOf(' ') == 0)
                name = name.Substring(1);

            while (name.Length > 0 && name.LastIndexOf(' ') == name.Length - 1)
                name = name.Remove(name.LastIndexOf(' '));

            return name;
        }

        public bool narrowSearch(List<TitleData> results, String title, out TitleData result)
        {

            if (title.Contains("Ranpo")) 
            {
                ;
            }

            foreach (TitleData data in results)
            {

                String titleTemp = simpleFileName(data.Title.ToLower());
                String searchTemp = simpleFileName(title.ToLower());
                String englishTemp = simpleFileName(data.English.ToLower());


                if (titleTemp.Equals(searchTemp) || englishTemp.Equals(searchTemp)) 
                {
                    result = data;
                    return true;
                }
                if (levDist(titleTemp, searchTemp) > 90 || levDist(englishTemp, searchTemp) > 90)
                {
                    result = data;
                    return true;
                }
                foreach (String syn in data.Synonyms)
                {
                    String synTemp = syn.ToLower();

                    if (synTemp.Equals(searchTemp))
                    {
                        result = data;
                        return true;
                    }
                    if (levDist(synTemp, searchTemp) > 90)
                    {
                        result = data;
                        return true;
                    }
                }
            }

            if(results.Count == 1)
            {
                result = results.ElementAt(0);
                return true;
            }

            result = new TitleData(title);
            return false;
        }
        //Levenshtein Distance to calculate the difference between two strings.
        public static int levDist(string s, string t)
        {
            if (string.IsNullOrEmpty(s))
            {
                if (string.IsNullOrEmpty(t))
                    return 0;
                return t.Length;
            }

            if (string.IsNullOrEmpty(t))
            {
                return s.Length;
            }

            int n = s.Length;
            int m = t.Length;
            int[,] d = new int[n + 1, m + 1];

            // initialize the top and right of the table to 0, 1, 2, ...
            for (int i = 0; i <= n; d[i, 0] = i++) ;
            for (int j = 1; j <= m; d[0, j] = j++) ;

            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= m; j++)
                {
                    int cost = (t[j - 1] == s[i - 1]) ? 0 : 1;
                    int min1 = d[i - 1, j] + 1;
                    int min2 = d[i, j - 1] + 1;
                    int min3 = d[i - 1, j - 1] + cost;
                    d[i, j] = Math.Min(Math.Min(min1, min2), min3);
                }
            }

            int top = Math.Max(s.Length, t.Length);
            return Convert.ToInt32(100*((double)(top - d[n, m]) / top));
        }
    }
}
