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

        [ForeignKey("IDUsuarioPergunta")]
        public Usuario Usuario { get; set; }
        public int IDUsuarioPergunta { get; set; }

        [DisplayName("Titulo")]
        [Required(ErrorMessage = "Campo {0} é obrigatório")]
        public string Titulo { get; set; }


        [DisplayName("Detalhes da sua pergunta")]
        [Required(ErrorMessage = "Campo {0} é obrigatório")]
        public string Detalhes { get; set; }

        [DisplayName("O que eu espero com essa pergunta")]
        [Required(ErrorMessage = "Campo {0} é obrigatório")]
        public string Esperado { get; set; }
        public Tags TagPrincipal { get; set; }
        public Tags? TagSecundaria { get; set; }
        public DateTime DataEnvio { get; set; }
        public int? Views { get; set; }
        public int? Comments { get; set; }
        public int? Likes { get; set; }

        public virtual string TituloAbreviado
        {
            get
            {
                return Titulo.Length > 60 ? $"{Titulo.Substring(0, 60)}..." : Titulo;
            }
        }
        public virtual string DetalhesAbreviada
        {
            get
            {
                return Detalhes.Length > 100 ? $"{Detalhes.Substring(0, 180)}..." : Detalhes;

            }
        }


    }
}