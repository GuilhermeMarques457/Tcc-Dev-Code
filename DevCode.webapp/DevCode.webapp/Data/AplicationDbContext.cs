using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;

using System.Web;

namespace DevCode.webapp.Data
{
    public class AplicationDbContext : DbContext
    {
        public AplicationDbContext(): base("AplicationDbContext")
        {

        }

        public DbSet<DevCode.webapp.Models.Usuario> Usuario { get; set; }
        public DbSet<DevCode.webapp.Models.Respostas> Respostas { get; set; }
        public DbSet<DevCode.webapp.Models.Perguntas> Pergunta { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}