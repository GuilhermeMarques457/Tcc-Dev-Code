using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DevCode.webapp.Areas.Admin.Models;

namespace DevCode.webapp.Models
{
    public class HomeVM
    {
        public UsuarioVM UsuarioVM { get; set; }
        public List<Noticia> Noticias { get; set; }
        public List<Perguntas> Perguntas { get; set; }
    }
}