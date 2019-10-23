using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using BotWatson.Models;

namespace BotWatson.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<BotWatson.Models.Bot> Bot { get; set; }
        public DbSet<BotWatson.Models.Messagem> Messagem { get; set; }
    }
}
