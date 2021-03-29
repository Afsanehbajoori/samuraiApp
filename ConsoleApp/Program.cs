using samuraiApp.Domain;
using System;
using System.Linq;
using samuraiApp.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ConsoleApp
{
    internal class Program
    {
          
     private static samuraiContext _context = new samuraiContext();
       

     private static void Main(string[] args)
     {
            //context.Database.EnsureCreated();
            //GetSamurais("Before Add:");
            //AddSamurai();
            //GetSamurais("After Add:");
            //InsertMultipleSamurais();
            //GetSamuraisSimpler();
            //queryfilters();
            //RetrieveAndUpdateSamurai();
            //RetrieveAndUpdateMultipleSamurai();
            // MultipleDatabaseOperations();
            //RetrieveAndDeleteASamurai();
            //InsertBattle();
            //QueryAndUpdateBattle_Disconnected();
            //InsertNewSamuraiWithAQuote();
            //InsertNewSamuraiWithManyQuotes();
            //AddQuoteToExistingSamuraiWhileTracked();
            //AddQuoteToExistingSamuraiNotTracked(5);
            //AddQuoteToExistingSamuraiNotTracked_Easy(5);
                        
                          

            Console.WriteLine("Press any key .......");
            Console.ReadKey();
     }

        private static void AddQuoteToExistingSamuraiNotTracked_Easy(int samuraiId)
        {
            var quote = new Quote
            {
                Text = "Now that I saved you, will you feed me dinner again?",
                SamuraiId = samuraiId
            };
            using (var newContext = new samuraiContext())
            {
                newContext.Quotes.Add(quote);
                newContext.SaveChanges();
            }

        }

        private static void AddQuoteToExistingSamuraiNotTracked(int samuraiId)
        {
            var samurai = _context.samurais.Find(samuraiId);
            samurai.Quotes.Add(new Quote
            {
                Text = "Now that I saved you , will you feed me dinner?"
            });
            using (var newContext = new samuraiContext())
            {
                newContext.samurais.Update(samurai);
                newContext.SaveChanges();
            }
        }

        private static void InsertNewSamuraiWithManyQuotes()
        {
            var samurai = new samurai
            {
                Name = "Kyuzo",
                Quotes = new List<Quote>
                {
                    new Quote{Text="Watch out for my sharp sword!"},
                    new Quote {Text="I told you to watch out for the sharp sword! oh well!"}
                }
            };
            _context.samurais.Add(samurai);
            _context.SaveChanges();

        }

        private static void AddQuoteToExistingSamuraiWhileTracked()
        {
            var samurai = _context.samurais.FirstOrDefault();
            samurai.Quotes.Add(new Quote

            {
                Text = "I bet you're happy that I've saved you!"
            });
            _context.SaveChanges();
        }

        private static void InsertNewSamuraiWithAQuote()
        {
            var samurai = new samurai
            {
                Name = "Kambei Shimada",
                Quotes = new List<Quote>
                {
                    new Quote{Text="I've come to save you"}
                }
            };
            _context.samurais.Add(samurai);
            _context.SaveChanges();
        }

        private static void QueryAndUpdateBattle_Disconnected()
        {
            var battle = _context.Battles.AsNoTracking().FirstOrDefault();
            battle.EndDate = new DateTime(1560, 06, 30);
            using (var newContextInstance = new samuraiContext())
            {
                newContextInstance.Battles.Update(battle);
                newContextInstance.SaveChanges();
            }
        }

        private static void InsertBattle()
        {
            _context.Battles.Add(new Battle
            {
                Name = "Battle of Okehazama",
                StartDate = new DateTime(1560, 05, 01),
                EndDate = new DateTime(1560, 06, 15)
            }
                );
            _context.SaveChanges();
        }

        private static void RetrieveAndDeleteASamurai()
        {
            var samurai = _context.samurais.Find(18);
            _context.samurais.Remove(samurai);
            _context.SaveChanges();
        }

        private static void MultipleDatabaseOperations()
        {
            var samurai = _context.samurais.FirstOrDefault();
            samurai.Name += "San";
            _context.samurais.Add(new samurai { Name = "Kikuchiyo" });
            _context.SaveChanges();
        }

        private static void RetrieveAndUpdateMultipleSamurai()
        {
            var samurais = _context.samurais.Skip(1).Take(3).ToList();
            samurais.ForEach(s => s.Name += "San");
            _context.SaveChanges();
        }

        private static void RetrieveAndUpdateSamurai()
        {
             var samurai = _context.samurais.FirstOrDefault();
            samurai.Name += "San";
            _context.SaveChanges();
        }

        private static void queryfilters()
        {
            //var samurais = _context.samurais.Where(s => s.Name=="Sampsom").ToList();

            var name = "Sampson";
            // _context.samurais.Where(s => s.Name.Contains("abc"));
            // var samuris = _context.samurais.FirstOrDefault(s => s.Name == name);
            // var samurais = _context.samurais.Where(s => EF.Functions.Like(s.Name, "j%")).ToList();
            // var samuris = _context.samurais.Where(s => s.Name == name).FirstOrDefault();
            //var samuris = _context.samurais.FirstOrDefault(s => s.Id == 2);
            // var samurais = _context.samurais.Find(2);
             var samurais = _context.samurais.OrderBy(s=>s.Id).LastOrDefault(s=>s.Name==name);
        }

        private static void InsertMultipleSamurais()
        {
            var samurai = new samurai { Name = "Sampson" };
            var samurai2 = new samurai { Name = "Tasha" };
            var samurai3 = new samurai { Name = "Number3" };
            var samurai4 = new samurai { Name = "Number4" };
            _context.samurais.AddRange(samurai, samurai2, samurai3, samurai4);
            _context.SaveChanges();
        }

        private static void InsertVariousTypes()
        {
            var samurai = new samurai { Name = "Kikuchio" };
            var clan = new Clan { ClanName = "Imperial Clan" };
            _context.AddRange(samurai.Clan);
            _context.SaveChanges();
        }


        private static void AddSamurai()
        {
            var samurai = new samurai { Name = "Sampson" };
            _context.samurais.Add(samurai);
            _context.SaveChanges();
        }

        private static void GetSamuraisSimpler()
        {
            //var samurais = context.samurais.ToList();
            var query = _context.samurais;
            //var samurais = query.ToList();
            foreach (var samurai in query)
            {
                Console.WriteLine(samurai.Name);
            } 
                       
        }

        private static void GetSamurais(string text)
        {
            var samurais = _context.samurais.ToList();
            Console.WriteLine($"{text}: Samurai count is {samurais.Count}");
            foreach (var samurai in samurais)
            {
                Console.WriteLine(samurai.Name);
            }
            {

            }
        }
    }
}
