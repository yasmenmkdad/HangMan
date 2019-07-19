using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
namespace HangManProject
{
    public interface Isqlite
    {
        SQLiteConnection GetConnection();
         bool SaveData(word wrd);
         List<word> GetWords();
    }
}
