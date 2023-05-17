using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DevCode.webapp.Models
{
    public class PerguntaRespostaVM
    {
        public IList<Respostas> Respostas { get; set; }
        public IList<Perguntas> Perguntas { get; set; }
        public Usuario Usuario { get; set; }
    }
}