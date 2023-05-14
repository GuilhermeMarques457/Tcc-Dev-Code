using DevCode.webapp.Models;
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
        public AplicationDbContext(): base("database")
        {

        }
        public DbSet<DevCode.webapp.Areas.Admin.Models.Noticia> Noticia { get; set; }
        public DbSet<DevCode.webapp.Models.Usuario> Usuario { get; set; }
        public DbSet<DevCode.webapp.Models.Respostas> Respostas { get; set; }
        public DbSet<DevCode.webapp.Models.Perguntas> Pergunta { get; set; }
        public DbSet<DevCode.webapp.Models.Amizade> Amizades { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
    }
}