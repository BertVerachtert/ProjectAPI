using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectAPI.Models
{
    public class Item
    {
        public long ItemID { get; set; }
        public long LijstID { get; set; }
        public string Antwoord { get; set; }
        public string BeschrijvingAntwoord { get; set; }
        public string Foto { get; set; }
        public ICollection<Stem> Stems { get; set; }
        public Lijst Lijst { get; set; }
    }
}
