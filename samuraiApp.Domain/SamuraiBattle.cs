using System;
using System.Collections.Generic;
using System.Text;

namespace samuraiApp.Domain
{
    public class SamuraiBattle
    {
        public int SamuraiId { get; set; }
        public int BattleId { get; set; }
        public samurai Samurai { get; set; }
        public Battle Battle { get; set; }
    }
}
