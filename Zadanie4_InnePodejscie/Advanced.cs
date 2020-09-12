using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Zadanie4_InnePodejscie
{
     public class Advanced
    {
        [Key]
        public int Id { get; set; }
        public string Team { get; set; }
        public string Conference { get; set; }
        public bool excludeGarbageTime { get; set; }
        public int startWeek { get; set; }
        public int endWeek { get; set; }
        public int Year { get; set; }
        //public List<Teams> Teams { get; set; }
    }
}
