using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DevCode.webapp.Models
{
    public class Perguntas
    {
        public int IDPergunta { get; set; }
        public string Titulo { get; set; }
        public string Detalhes { get; set; }
        public string Esperado { get; set; }
        public string TagPrincipal { get; set; }
        public string TagSecundaria { get; set; }
        
        //Tags será Lista
    }
}