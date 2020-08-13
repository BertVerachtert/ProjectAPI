using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectAPI.Models
{
    public class Gebruiker
    {
        public long GebruikerID { get; set; }
        public string Email { get; set; }
        public Boolean Activatie { get; set; }
        public string Wachtwoord { get; set; }
        public string Gebruikersnaam { get; set; }
        public ICollection<Stem> Stems { get; set; }
        
        [NotMapped] 
        public string Token { get; set; }
}
}
