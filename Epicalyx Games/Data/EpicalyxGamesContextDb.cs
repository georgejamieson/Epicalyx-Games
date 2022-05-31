using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EpicalyxGame.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

    public class EpicalyxGamesContextDb : IdentityDbContext<IdentityUser, IdentityRole, string>
{
        public EpicalyxGamesContextDb (DbContextOptions<EpicalyxGamesContextDb> options)
            : base(options)
        {
        }

        public DbSet<EpicalyxGame.Models.Game> Game { get; set; }

        public DbSet<EpicalyxGame.Models.FinalReview> FinalReview { get; set; }

        public DbSet<EpicalyxGame.Models.User> User { get; set; }

        public DbSet<EpicalyxGame.Models.AspectReview> AspectReview { get; set; }
    }
