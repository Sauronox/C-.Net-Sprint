using System;
using Microsoft.EntityFrameworkCore;
using SocialCS.Models;

namespace SocialCS.Models
{
    public class SocialCSContext : DbContext
    {
        public SocialCSContext(DbContextOptions<SocialCSContext> options) : base(options)
        {
        }

        public DbSet<SocialCS.Models.MvcUser> MvcUser { get; set; }

        public DbSet<SocialCS.Models.MvcArticles> MvcArticles { get; set; }
    }
}
