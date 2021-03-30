using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using samuraiApp.Data;
using samuraiApp.Domain;
using System.Diagnostics;


namespace unitTest
{
    [TestClass]
    public class DatabaseTests
    {
        [TestMethod]
        public void CanInsertSamuraiIntoDatabase()
        {
            using (var context= new samuraiContext())
            {
                //context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                var samurai = new samurai();
                context.samurais.Add(samurai);
                Debug.WriteLine($"Before save: {samurai.Id}");
                context.SaveChanges();
                Debug.WriteLine($"After save: {samurai.Id}");
                Assert.AreNotEqual(0, samurai.Id);
            }
        }


        
    }
}
