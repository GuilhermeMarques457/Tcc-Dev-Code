using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DevCode.webapp.Models
{
    public class UsuarioVM
    {
        [DisplayName("Username")]
        [Required(ErrorMessage = "Campo {0} é obrigatório")]
        public string Username { get; set; }
        [DisplayName("Senha")]
        [Required(ErrorMessage = "Campo {0} é obrigatório")]
        public string Senha { get; set; }
    }
}