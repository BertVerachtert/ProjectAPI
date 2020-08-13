using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectAPI.Models
{
    public class Stem
    {
        public long StemID { get; set; }
        public long ItemID { get; set; }
        public long GebruikerID { get; set; }
        public Gebruiker Gebruiker { get; set; }
        public Item Item { get; set; }
    }
}
