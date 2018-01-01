using HotelEngine;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelModel
{
    public class HbgModel : DbContext
    {
        public DbSet<GameLogicPersistence> Game { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=localhost;userid=root;pwd=barthomer;port=3306;database=hbg;sslmode=none;");
        }
    }
}
