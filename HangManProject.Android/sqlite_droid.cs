using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;
using System.IO;
using Xamarin.Forms;
using HangManProject.Droid;


[assembly:Dependency(typeof(sqlite_droid))]
namespace HangManProject.Droid
{
    public class sqlite_droid : Isqlite
    {
        SQLiteConnection database;
        public SQLiteConnection GetConnection()
        {
            string dbname = "mydatabase.db3";
            string dbpath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string pth = Path.Combine(dbpath, dbname);
            database = new SQLiteConnection(pth);
            database.CreateTable<word>();
            return database;
        }
        public List<word> GetWords()
        {
            string data = "SELECT *FROM word";
            List<word> words = database.Query<word>(data);
            return words;
        }
        public bool SaveData(word wrd)
        {
            bool res = false;
            try
            {
                database.Insert(wrd);
                res = true;
                //runy kda
            }
            catch (Exception ex)
            {
                res = false;
            }
            return res;
            //public void SaveData()
            //{
            //    throw new NotImplementedException();
            //}
        }
    }
}