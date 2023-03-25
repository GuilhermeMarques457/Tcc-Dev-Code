using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using DevCode.webapp.Models.Enum;

namespace DevCode.webapp.Areas.Admin.Models
{
    public class Noticia
    {
        [Key]
        public int IDNoticia { get; set; }
        public string Titulo { get; set; }
        public string Detalhes { get; set; }
        public IList<Tags> Tags { get; set; }
        public DateTime DataEnvio { get; set; }
        [ForeignKey("IDUsuario")]
        public int IDUsuario { get; set; }
        [ForeignKey("IDResposta")]
        public int IDResposta { get; set; }
        
    }
}