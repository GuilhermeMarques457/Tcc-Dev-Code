using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DevCode.webapp.Models
{
    public class UsuarioAmigosVM
    {
        public List<Usuario> Usuarios { get; set; }
        public List<Amizade> Amizades { get; set; }
    }
}