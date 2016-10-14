/*
 * 
 * MAL Login Info
 *  -User: Distributor
 *  -Pass: MALdistro
 *  -Email: maldistributor@gmail.com
 * 
 * TDT(To Do Tomorrow):
 *  -Load finished and unfinished folders into database
 *      -Maybe create a new DB for unfinished titles or use some identifier to mark as unfinished.
 *  
 * 4/9/2016
 *  -Main Form
 *      -Loads titles previously saved
 *      -Loads data saved to db
 *      -New menu item (Tools->Settings)
 * 
 *  -Settings Form
 *      -Added to main form
 *      -Loads previous settings
 *      -Saves changed settings
 *  
 * 4/6-8/2016
 *  -Settings Form
 *      -Started Settings form
 *      -Dialog Search boxes to determine folder
 *      -Counter for max results per search
 *      
 *  -Database
 *      -Database Saves and Loads Web Data
 *      
 *  -Web Crawler
 *      -Title, English Title, Synopsis, and ImageURL are all saved
 *      -Data retrieval changed to xml through MAL api
 *      
 *  -Search Form
 *      -Form gives user choice to add from a selection of search results
 *      
 * 4/1/16
 *  -Search Selection form
 *      TODO
 *      -Create a form that displays the list of search results
 * 
 *  -Web Crawler
 *      -Now detects many show titles
 *      http://myanimelist.net/modules.php?go=api
 * 
 * 3/29/16
 *  -Main Program
 *      -Multi-threads web crawler
 *      
 *  -Web Crawler
 *      -Downloads web information from MAL
 *      -Searches MAL for titles and combines those titles into a Title-URL list
 *          -Finds beginning of table
 *          -Retrieves relevant title and URL information.
 *      TODO
 *      -Narrow search to a single title
 *      -Extract title details
 *          -Description, Characters, Voice Actors
 *      -Store extracted information into database
 *          -Check if that information already exists before storing
 * 
 * 3/28/16
 *  -Main Form
 *      -Created main form with basic layout
 *      -Listbox generates titles from dictionary
 *          -Changing indexes will adjust information appropriately
 *      -Title and Location labels working properly
 *      TODO
 *      ######### WAIT FOR WEB CRAWLER BEFORE FINISHING THIS LIST #########
 *      -Display images of title in PictureBox
 *      -Load Description and Information details about shows
 *      -Load Character List and Voice Actors from data
 *      
 * 3/27/16
 *  -SQLite Database
 *      -Creates non-existing tables
 *      -Saves and Loads titles from database
 *      TODO
 *      -Add descriptions to title entries
 *      
 *  -Title Sorting Media
 *      -Creates new directories for each title
 *      TODO
 *      ########## WAIT FOR DATABASE TO SAVE TITLE NAMES AND LOCATIONS PROPERLY ###########
 *      -Move files to their appropriate folder
 *      -Undo changes made
 *      
 *  -Dynamic Title Recognition
 *      -Skewers titles of jargon
 *      -Removes extension
 *      TODO
 *      -Compare Titles to a compiled list of shows from internet(web crawler?)
 * 
 * 
 *
 */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Media_Distributor
{
    public class Program
    {
        public static Configuration curConfig;

        [STAThread]
        static void Main(string[] args)
        {

            curConfig = new Configuration();

            Application.Run(new MainForm(curConfig));
        }
    }
}
