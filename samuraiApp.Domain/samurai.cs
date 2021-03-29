using System;
using System.Collections.Generic;
using System.Text;

namespace samuraiApp.Domain
{
    public class samurai
    {
        public samurai()
        {
            Quotes = new List<Quote>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Quote> Quotes { get; set; }
        public Clan Clan { get; set; }
        public List<SamuraiBattle> SamuraiBattles { get; set; }
        public Horse Horse { get; set; }

    }

}
