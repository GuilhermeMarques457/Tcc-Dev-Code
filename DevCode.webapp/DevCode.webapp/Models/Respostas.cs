using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;



namespace DevCode.webapp.Models
{
    public class Respostas
    {
        [Key]
        public int IDRespostas { get; set; }
        public string ExplicacaoResposta { get; set; }
        public int IDPergunta { get; set; }
        public int IDUsuario { get; set; }

        /*public Pergunta pergunta { get; set; }
        Objeto vindo da classe pergunta*/
    }
}