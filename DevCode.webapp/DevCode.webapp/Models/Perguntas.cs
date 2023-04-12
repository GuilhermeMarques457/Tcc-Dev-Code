using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using DevCode.webapp.Models.Enum;

namespace DevCode.webapp.Models
{
    public class Perguntas
    {
        [Key]
        public int IDPergunta { get; set; }

        public int IDUsuario { get; set; }

        //[ForeignKey(nameof(IDPergunta))]
        //public Usuario Usuario { get; set; }
        public string Titulo { get; set; }

        [DisplayName("Detalhes da sua pergunta")]
        public string Detalhes { get; set; }

        [DisplayName("O que eu espero com essa pergunta")]
        public string Esperado { get; set; }
        public IList<Tags>? TagPrincipal { get; set; }
        public DateTime DataEnvio { get; set; }

        //Tags será Lista
    }
}