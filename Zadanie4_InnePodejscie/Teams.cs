using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace Zadanie4_InnePodejscie
{
    public class Teams
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string School { get; set; }
        public string Abbreviation { get; set; }
        public string Conference { get; set; }
        public string Division { get; set; }
        public List<Advanced> Advanced { get; set; } = new List<Advanced>();
    }
}