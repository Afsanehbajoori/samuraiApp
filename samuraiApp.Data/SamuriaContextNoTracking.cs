using Microsoft.EntityFrameworkCore;
using samuraiApp.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace samuraiApp.Data
{
    public class SamuriaContextNoTracking : DbContext
    {
        public SamuriaContextNoTracking()
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
        public DbSet<samurai> samurais { get; set; }
        public DbSet<Quote> Quotes { get; set; }
        public DbSet<Clan> Clans { get; set; }
        public DbSet<Battle> Battles { get; set; }
        public DbSet<Horse> Horses { get; set; }

    }
}
