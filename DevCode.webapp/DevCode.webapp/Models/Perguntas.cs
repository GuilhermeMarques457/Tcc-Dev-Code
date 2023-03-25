using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using DevCode.webapp.Models.Enum;

namespace DevCode.webapp.Models
{
    public class Perguntas
    {
        [Key]
        public int IDPergunta { get; set; }
        public string Titulo { get; set; }
        public string Detalhes { get; set; }
        public string Esperado { get; set; }
        public IList<Tags> TagPrincipal { get; set; }
        public DateTime DataEnvio { get; set; }

        //Tags será Lista
    }
}