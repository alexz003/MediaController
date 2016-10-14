using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;

namespace Media_Distributor
{
    public class DatabaseConnection
    {

        private SQLiteConnection connection;

        public DatabaseConnection()
        {
            String dbName = "MediaDistributor.sqlite";

            if (!File.Exists(dbName))
            {
                SQLiteConnection.CreateFile(dbName);
                initializeDatabase(dbName);
            }
            else
            {
                connection = new SQLiteConnection("Data Source =" + dbName + ";Verision=3;");
            }

            
            
        }

        public void initializeDatabase(String dbName)
        {
            try
            {
                int count = 0;
                connection = new SQLiteConnection("Data Source =" + dbName + ";Verision=3;");
                connection.Open();

                String sqlString = "create table if not exists Titles (usertitle text, location text, webdata int, unique(usertitle, location))";
                SQLiteCommand command = new SQLiteCommand(sqlString, connection);
                count += command.ExecuteNonQuery();

                sqlString = "create table if not exists UserSettings (id int, finishedlocation text, unfinishedlocation text, unsortedlocation text, maxresults int, unique(id))";
                command = new SQLiteCommand(sqlString, connection);
                command.ExecuteNonQuery();

                sqlString = "create table if not exists WebData (usertitle text, title text, synopsis text, image text, unique(usertitle))";
                command = new SQLiteCommand(sqlString, connection);
                command.ExecuteNonQuery();

                sqlString = "create table if not exists Actors (usertitle text, image blob, unique(usertitle))";
                command = new SQLiteCommand(sqlString, connection);
                command.ExecuteNonQuery();
                command.Dispose();

                connection.Close();
            }
            catch (SQLiteException e)
            {
                Console.WriteLine(e.Message);
            }

        }

        public void saveConfiguration(String finishedLocation, String unfinishedLocation, String unsortedLocation, int maxResults)
        {
            connection.Open();
            int count = 0;
            try
            {
                
                SQLiteCommand command = new SQLiteCommand(connection);
                command.CommandText = "insert or replace into UserSettings (id, finishedlocation, unfinishedlocation, unsortedlocation, maxresults) values (1, @floc, @ufloc, @unsloc, @maxres)";
                command.Parameters.AddWithValue("@floc", finishedLocation);
                command.Parameters.AddWithValue("@ufloc", unfinishedLocation);
                command.Parameters.AddWithValue("@unsloc", unsortedLocation);
                command.Parameters.AddWithValue("@maxres", maxResults);
                count += command.ExecuteNonQuery();
            }
            catch (SQLiteException e)
            {
                Console.WriteLine(e.Message);
            }
            connection.Close();
        }

        public void getConfiguration(out String finishedLocation, out String unfinishedLocation, out String unsortedLocation, out int maxResults)
        {
            String floc = "";
            String ufloc = "";
            String unsloc = "";
            int maxres = 10;

            try
            {
                connection.Open();
                String sqlString = "select * from UserSettings where id=1";
                SQLiteCommand command = new SQLiteCommand(sqlString, connection);

                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        floc = reader["finishedlocation"].ToString();
                        ufloc = reader["unfinishedlocation"].ToString();
                        unsloc = reader["unsortedlocation"].ToString();

                        int temp;
                        if(Int32.TryParse(reader["maxresults"].ToString(), out temp))
                            maxres = temp;
                    }
                }

                connection.Close();
            }
            catch (SQLiteException e)
            {
                Console.WriteLine(e.Message);
            }


            finishedLocation = floc;
            unfinishedLocation = ufloc;
            unsortedLocation = unsloc;
            maxResults = maxres;
        }

        public Dictionary<String, TitleData> loadWebData()
        {
            Dictionary<String, TitleData> data = new Dictionary<String, TitleData>();

            try
            {
                connection.Open();
                String sqlString = "select * from WebData";
                SQLiteCommand command = new SQLiteCommand(sqlString, connection);

                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        TitleData item = new TitleData(reader["usertitle"].ToString());
                        item.Title = reader["title"].ToString();
                        item.Synopsis = reader["synopsis"].ToString();
                        item.ImageURL = reader["image"].ToString();
                        data.Add(item.UserTitle, item);
                    }
                }

                connection.Close();
            }
            catch (SQLiteException e)
            {
                Console.WriteLine(e.Message);
            }
            return data;
        } 

        public void saveTitleData(Dictionary<String, TitleData> titleList)
        {
            int count = 0;
            connection.Open();
            foreach (KeyValuePair<String, TitleData> kvp in titleList)
            {
                try
                {
                    String sqlString = "update Titles set webdata = 1 where usertitle = \'" + kvp.Key + "\'";
                    SQLiteCommand command = new SQLiteCommand(sqlString, connection);
                    command.ExecuteNonQuery();
                    command.CommandText = "insert or ignore into WebData(usertitle, title, synopsis, image) values (@utitle, @title, @synop, @image)";
                    command.Parameters.AddWithValue("@utitle", kvp.Key);
                    command.Parameters.AddWithValue("@title", kvp.Value.Title);
                    command.Parameters.AddWithValue("@synop", kvp.Value.Synopsis);
                    command.Parameters.AddWithValue("@image", kvp.Value.ImageURL);
                    count += command.ExecuteNonQuery();
                }
                catch (SQLiteException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            connection.Close();
            Console.WriteLine("Updated " + count + " items");
        }

        public void saveTitles(Dictionary<String, String> titles)
        {
            connection.Open();
            int count = 0;
            foreach (KeyValuePair<String, String> kvp in titles)
            {
                String sqlString = "insert or ignore into Titles (usertitle, location, webdata) values (\'" + kvp.Key + "\', \'" + kvp.Value + "\', " + 0 + ")";
                SQLiteCommand command = new SQLiteCommand(sqlString, connection);

                int cnt = command.ExecuteNonQuery();
                count += cnt;
            }
            connection.Close();
            Console.WriteLine("Saved " + count + " titles.");
        }

        public Dictionary<String, String> getTitleList()
        {

            Dictionary<String, String> titleList = new Dictionary<string, string>();
            try
            {
                String sqlString = "select * from Titles";
                SQLiteCommand command = new SQLiteCommand(sqlString, connection);
                connection.Open();

                SQLiteDataReader reader = command.ExecuteReader();
                int count = 0;


                while (reader.Read())
                {
                    count++;
                    String name = reader["usertitle"].ToString();
                    String location = reader["location"].ToString();
                    if(!titleList.Keys.Contains(name))
                        titleList.Add(name, location);
                }

                Console.WriteLine("Loaded " + count + " titles.");
                connection.Close();
                //reader.Close();
                command.Dispose();
            }
            catch (SQLiteException e)
            {
                Console.WriteLine(e.Message);
            }

            return titleList;
        }

        public void closeConnection()
        {
            connection.Close();
        }


    }
}
