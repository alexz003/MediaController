using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Media_Distributor
{
    public class Configuration
    {

        private static String startDirectory;
        private Dictionary<String, String> titleList;
        public DatabaseConnection database;

        public String FinishedShowsFolder { get; set; }
        public String UnfinishedShowsFolder { get; set; }
        public String UnsortedShowsFolder { get; set; }
        public int MaxResults { get; set; }
        public Dictionary<String, TitleData> WebData { get; set; }

        public Configuration()
        {
            database = new DatabaseConnection();
            loadConfiguration();
            loadWebData();
            titleList = database.getTitleList();
        }
        
        public void setTitleList(Dictionary<String, String> titles)
        {
            titleList = titles;
        }

        public void updateTitleList(Dictionary<String, String> titles)
        {
            foreach (KeyValuePair<String, String> kvp in titles)
            {
                if (!titleList.Keys.Contains(kvp.Key))
                    titleList.Add(kvp.Key, kvp.Value);
            }
        }

        public Dictionary<String, String> getTitleList()
        {
            return titleList;
        }

        public String getStartDirectory()
        {
            return startDirectory;
        }

        public void loadWebData()
        {
            WebData = database.loadWebData();
        }

        public void loadConfiguration()
        {
            String floc, ufloc, unsfloc;
            int maxres;
            database.getConfiguration(out floc, out ufloc, out unsfloc, out maxres);

            FinishedShowsFolder = floc;
            UnfinishedShowsFolder = ufloc;
            UnsortedShowsFolder = unsfloc;
            MaxResults = maxres;
        }

        public void saveToDb()
        {

        }
    }
}
