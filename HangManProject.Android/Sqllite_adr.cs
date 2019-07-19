using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using HangManProject.Droid;
using SQLite;
using Xamarin.Forms;

[assembly: Dependency(typeof(Sqllite_adr))]
namespace HangManProject.Droid
{
    public class Sqllite_adr : SqliteForPlayer
    {
        SQLiteConnection database;
        public SQLiteConnection GetConnection()
        {
            string dbname = "mydatabase.db3";
            string dbpath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string pth = Path.Combine(dbpath, dbname);
            database = new SQLiteConnection(pth);
            database.CreateTable<Player>();
            return database;
        }
        public List<Player> GetPlayers()
        {
            string data = "SELECT *FROM Player";
            List<Player> players = database.Query<Player>(data);
            return players;
        }

        public bool SaveData(Player player)
        {
            bool res = false;
            try
            {
                database.Insert(player);
                res = true;
                //runy kda
            }
            catch (Exception ex)
            {
                res = false;
            }
            return res;
        }
    }
}