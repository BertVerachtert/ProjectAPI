using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectAPI.Models
{
    public class DBInitializer
    {
        public static void Initialize(DataContext context)
        {
            context.Database.EnsureCreated();

            if (context.Gebruikers.Any())
            {
                return;
            }

            context.Gebruikers.AddRange(
                new Gebruiker { Email = "bertverachtert@gmail.com", Wachtwoord = "123", Gebruikersnaam = "Bert", Activatie = true },
                new Gebruiker { Email = "HideoKojima@kojimaproductions.com", Wachtwoord = "hideo", Gebruikersnaam = "Kojima", Activatie = false },
                new Gebruiker { Email = "Miyazaki@DarkSouls.com", Wachtwoord = "miyazaki", Gebruikersnaam = "Miyazaki", Activatie = true },
                new Gebruiker { Email = "Pewds@Diepie.com", Wachtwoord = "barrels", Gebruikersnaam = "Pewdiepie", Activatie = true },
                new Gebruiker { Email = "Jack@scepticeye.com", Wachtwoord = "1234", Gebruikersnaam = "Jackscepticeye", Activatie = true }

            );
            context.SaveChanges();
            context.Lijsts.AddRange(
                new Lijst
                {
                    Naam = "Rappers of all time",
                    Beschrijving = "Vote for the best rapper of all time",
                    StartDatum = new DateTime(2020, 8, 21),
                    EindDatum = new DateTime(2020, 12, 31),
                    GebruikerID = 1
                },
                new Lijst
                {
                    Naam = "Singers of 2017",
                    Beschrijving = "Vote for the best singer of 2017",
                    StartDatum = new DateTime(2017, 1, 1),
                    EindDatum = new DateTime(2017, 12, 31),
                    GebruikerID = 2
                },
                new Lijst
                {
                    Naam = "Games of 2018",
                    Beschrijving = "Best games of 2018",
                    StartDatum = new DateTime(2018, 1, 1),
                    EindDatum = new DateTime(2018, 12, 31),
                    GebruikerID = 3
                },
                new Lijst
                {
                    Naam = "Games of 2019",
                    Beschrijving = "Best games of 2019",
                    StartDatum = new DateTime(2019, 1, 1),
                    EindDatum = new DateTime(2019, 12, 31),
                    GebruikerID = 1
                },
                  new Lijst
                  {
                      Naam = "Games of 2020",
                      Beschrijving = "Best games of 2020",
                      StartDatum = new DateTime(2020, 1, 1),
                      EindDatum = new DateTime(2020, 12, 31),
                      GebruikerID = 1
                  }

            );
            context.SaveChanges();
            context.Items.AddRange(
                new Item { LijstID = 1, Antwoord = "Eminem", BeschrijvingAntwoord = "Marshall Bruce Mathers III is an American rapper, songwriter, and record producer", Foto = "https://firebasestorage.googleapis.com/v0/b/projectangular-5ce9e.appspot.com/o/eminem.jpg?alt=media&token=9cf427c2-b51c-49c7-9acd-443268960eca" },
                new Item { LijstID = 1, Antwoord = "Tupac", BeschrijvingAntwoord = "Tupac Amaru Shakur was an American rapper and actor", Foto = "https://firebasestorage.googleapis.com/v0/b/projectangular-5ce9e.appspot.com/o/tupac.jpg?alt=media&token=cd878965-e70b-4490-8123-a5d5fe532582" },
                new Item { LijstID = 1, Antwoord = "Notorious BIG", BeschrijvingAntwoord = "Christopher George Latore Wallace was an American rapper and songwriter", Foto = "" },
                new Item { LijstID = 1, Antwoord = "Dr. Dre", BeschrijvingAntwoord = "Andre Romelle Young is an American rapper, record producer, audio engineer, record executive, entrepreneur, and actor", Foto = "https://firebasestorage.googleapis.com/v0/b/projectangular-5ce9e.appspot.com/o/drdre.jpg?alt=media&token=1695cb74-21b7-4859-9c9a-989a81808c66" },

                new Item { LijstID = 2, Antwoord = "Adele", BeschrijvingAntwoord = "Adele Laurie Blue Adkins is an English singer-songwriter", Foto = "https://firebasestorage.googleapis.com/v0/b/projectangular-5ce9e.appspot.com/o/Adele_2016.jpg?alt=media&token=3f3f2b32-1734-424a-a645-a438ed52ca88" },
                new Item { LijstID = 2, Antwoord = "Ariana Grande", BeschrijvingAntwoord = "Ariana Grande-Butera is an American singer, songwriter, and actress", Foto = "" },
                new Item { LijstID = 2, Antwoord = "Bruno Mars", BeschrijvingAntwoord = "Peter Gene Hernandez is an American singer, songwriter, record producer, multi-instrumentalist, and dancer", Foto = "" },
                new Item { LijstID = 2, Antwoord = "Ed Sheeran", BeschrijvingAntwoord = "Edward Christopher Sheeran is an English singer, songwriter, record producer, and actor", Foto = "" },

                new Item { LijstID = 3, Antwoord = "Red Dead Redemption 2", BeschrijvingAntwoord = "RDR2 is the epic tale of outlaw Arthur Morgan and the infamous Van der Linde gang, on the run across America at the dawn of the modern age.", Foto = "https://firebasestorage.googleapis.com/v0/b/projectangular-5ce9e.appspot.com/o/reddead.jpg?alt=media&token=b2a5bc45-04f6-4ef8-807a-2855190d33ab" },
                new Item { LijstID = 3, Antwoord = "God of War", BeschrijvingAntwoord = "Following the death of Kratos' second wife and Atreus' mother, they journey to fulfill her request that her ashes be spread at the highest peak of the nine realms. Kratos keeps his troubled past a secret from Atreus, who is unaware of his divine nature. Along their journey, they encounter monsters and gods of the Norse world. ", Foto = "" },
                new Item { LijstID = 3, Antwoord = "Super Smash Bros. Ultimate", BeschrijvingAntwoord = " The game follows the series' traditional style of gameplay: controlling one of the various characters, players must use differing attacks to weaken their opponents and knock them out of an arena. It features a wide variety of game modes, including a campaign for single-player and multiplayer versus modes. ", Foto = "https://firebasestorage.googleapis.com/v0/b/projectangular-5ce9e.appspot.com/o/super-smash-bros-ultimate-switch-hero.jpg?alt=media&token=1933a9b7-9e1c-4219-895d-047a7625fe87" },
                new Item { LijstID = 3, Antwoord = "Dead Cells", BeschrijvingAntwoord = "Dead Cells is a rogue-lite, metroidvania inspired, action-platformer.", Foto = "" },

                new Item { LijstID = 4, Antwoord = "Sekiro: Shadows Die Twice", BeschrijvingAntwoord = "The game follows a shinobi known as Wolf as he attempts to take revenge on a samurai clan who attacked him and kidnapped his lord.", Foto = "" },
                new Item { LijstID = 4, Antwoord = "Resident Evil 2", BeschrijvingAntwoord = "The player controls Leon S. Kennedy and Claire Redfield, who must escape Raccoon City after its citizens are transformed into zombies by a biological weapon two months after the events of the original Resident Evil.", Foto = "" },
                new Item { LijstID = 4, Antwoord = "Apex Legends", BeschrijvingAntwoord = "In Apex Legends, up to 20 three-person squads land on an island and search for weapons and supplies before attempting to defeat all other players in combat. The available play area on the island shrinks over time, forcing players to keep moving or else find themselves outside the play area which can be fatal.", Foto = "https://firebasestorage.googleapis.com/v0/b/projectangular-5ce9e.appspot.com/o/apex.jpg?alt=media&token=a950c0a0-0b91-48b8-8410-e0102c4510b8" },
                new Item { LijstID = 4, Antwoord = "Slay the Spire", BeschrijvingAntwoord = "We fused card games and roguelikes together to make the best single player deckbuilder we could. Craft a unique deck, encounter bizarre creatures, discover relics of immense power, and Slay the Spire!", Foto = "" },

                new Item { LijstID = 5, Antwoord = "The Last of Us Part II", BeschrijvingAntwoord = "Set five years after The Last of Us (2013), players control 19-year-old Ellie who sets out for revenge and becomes involved in a conflict between a militia and a cult in a post-apocalyptic United States.", Foto = "" },
                new Item { LijstID = 5, Antwoord = "Half-Life: Alyx", BeschrijvingAntwoord = "Half-Life: Alyx is Valve’s VR return to the Half-Life series. It’s the story of an impossible fight against a vicious alien race known as the Combine, set between the events of Half-Life and Half-Life 2. ", Foto = "" },
                new Item { LijstID = 5, Antwoord = "Animal Corssing: New Horizons", BeschrijvingAntwoord = "In New Horizons, the player assumes the role of a customizable character who moves to a deserted island after purchasing a package from Tom Nook, a tanuki character who has appeared in every entry in the Animal Crossing series. Taking place in real-time, the player can explore the island in a nonlinear fashion, gathering and crafting items, catching insects and fish, and developing the island into a community of anthropomorphic animals. ", Foto = "https://firebasestorage.googleapis.com/v0/b/projectangular-5ce9e.appspot.com/o/Animal_Crossing_New_Horizons.jpg?alt=media&token=461b5f78-f77b-4dd3-8d7f-6e1fbf6491fc" },
                new Item { LijstID = 5, Antwoord = "Doom Eternal", BeschrijvingAntwoord = "Hell’s armies have invaded Earth. Become the Slayer in an epic single-player campaign to conquer demons across dimensions and stop the final destruction of humanity. The only thing they fear... is you.", Foto = "" }
               );
            context.SaveChanges();
            context.Stems.AddRange(
             new Stem { ItemID = 1, GebruikerID = 1 },
             new Stem { ItemID = 3, GebruikerID = 1 },
             new Stem { ItemID = 5, GebruikerID = 1 },
             new Stem { ItemID = 4, GebruikerID = 2 },
             new Stem { ItemID = 2, GebruikerID = 2 },
             new Stem { ItemID = 3, GebruikerID = 2 },
             new Stem { ItemID = 10, GebruikerID = 3 },
             new Stem { ItemID = 8, GebruikerID = 3 },
             new Stem { ItemID = 9, GebruikerID = 3 },
             new Stem { ItemID = 15, GebruikerID = 4 },
             new Stem { ItemID = 16, GebruikerID = 4 },
             new Stem { ItemID = 19, GebruikerID = 4 }
               );
            context.SaveChanges();
        }
    }
}
