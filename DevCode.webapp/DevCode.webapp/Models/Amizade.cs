using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DevCode.webapp.Models
{
    public class Amizade
    {
        [Key]
        public int IDAmizade { get; set; }

        [ForeignKey("IDUsuarioPedido")]
        public Usuario UsuarioPedido { get; set; }
        public int IDUsuarioPedido { get; set; }

        [ForeignKey("IDUsuarioResposta")]
        public Usuario UsuarioResposta { get; set; }
        public int IDUsuarioResposta { get; set; }

        public bool Pendente { get; set; }

        public bool Amigos { get; set; }
    }
}