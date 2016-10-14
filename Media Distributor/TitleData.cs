using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Media_Distributor
{
    public class TitleData
    {
        public String UserTitle { get; set; }
        public String Title { get; set; }
        public String English { get; set; }
        public String[] Synonyms { get; set; }
        public String Type { get; set; }
        public String Synopsis { get; set; }
        public String ImageURL { get; set; }

        public TitleData(String thisTitle)
        {
            UserTitle = thisTitle;
        }

        public TitleData(String thisTitle, String thisEnglish)
        {
            UserTitle = thisTitle;
            English = thisEnglish;
        }
    }
}
