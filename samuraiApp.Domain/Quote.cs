using System;
using System.Collections.Generic;
using System.Text;

namespace samuraiApp.Domain
{
    public class Quote
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public samurai Samurai { get; set; }
        public int SamuraiId { get; set; }
    }
}
