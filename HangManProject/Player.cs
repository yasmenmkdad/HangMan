using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
namespace HangManProject
{
    [Table("Players")]
    public class Player
    {
        [Column("PlayerName")]
        public string PlayerName { get; set;}
        [Column("PlayerScore")]
        private int playerScore { get; set; }
    }
}
