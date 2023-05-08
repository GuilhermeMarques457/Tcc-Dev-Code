using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using DevCode.webapp.Models;
using DevCode.webapp.Models.Enum;

namespace DevCode.webapp.Areas.Admin.Models
{
    public class Noticia
    {
        [Key]
        public int IDNoticia { get; set; }

        [ForeignKey("IDUsuarioNoticia")]
        public Usuario Usuario { get; set; }
        public int IDUsuarioNoticia { get; set; }
        public string Titulo { get; set; }
        public string Detalhes { get; set; }
        public Tags TagPrincipal { get; set; }
        public Tags? TagSecundaria { get; set; }
        public DateTime DataEnvio { get; set; }
        public int? Likes { get; set; }

        public virtual string DetalhesAbreviada
        {
            get
            {
                return Detalhes.Length > 100 ? $"{Detalhes.Substring(0, 180)}..." : Detalhes;

            }
        }
    }
}