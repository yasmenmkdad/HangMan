using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace HangManProject
{
    public interface SqliteForPlayer
    {
        SQLiteConnection GetConnection();
        bool SaveData(Player player);
        List<Player> GetPlayers();
    }
}
