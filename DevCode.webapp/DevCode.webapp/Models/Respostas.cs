using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;



namespace DevCode.webapp.Models
{
    public class Respostas
    {
        [Key]
        public int IDRespostas { get; set; }
        public string ExplicacaoResposta { get; set; }
        [ForeignKey("IDUsuarioResposta")]
        public Usuario Usuario { get; set; }
        public int IDUsuarioResposta { get; set; }
        [ForeignKey("IDPergunta")]
        public Perguntas Perguntas { get; set; }
        public int IDPergunta { get; set; }
        
        public DateTime DataResposta { get; set; }
        public int? Likes { get; set; }
    }
}