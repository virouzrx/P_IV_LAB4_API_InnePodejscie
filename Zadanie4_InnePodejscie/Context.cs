using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
//using DbContext = Microsoft.EntityFrameworkCore.DbContext;

namespace Zadanie4_InnePodejscie
    {
        public class FootballContext : DbContext
        {
            public DbSet<Teams> Teams { get; set; }
            public DbSet<Advanced> Advanced { get; set; }
            protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
            {
                optionBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=KolejnaBazaFB;Trusted_Connection=True;");
            }
        }
    }

