using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace HangManProject
{
    [Table("words")]
    public class word
    {
       [Column("name")]
        public string Name { get; set; }
       // public string type { get; set; }
    }
}
