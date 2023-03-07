using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DevCode.webapp.Models
{
    public class Usuario
    {
        public int Id { get; set; }

        [DisplayName("Nome")]
        [Required(ErrorMessage = "Campo {0} é obrigatório")]
        public string FirstName { get; set; }

        [DisplayName("Sobrenome")]
        [Required(ErrorMessage = "Campo {0} é obrigatório")]
        public string LastName { get; set; }

        [DisplayName("Email")]
        [Required(ErrorMessage = "Campo {0} é obrigatório")]
        public string Email { get; set; }

        [DisplayName("Senha")]
        [Required(ErrorMessage = "Campo {0} é obrigatório")]
        public string Senha { get; set; }

        [DisplayName("Celular")]
        [Required(ErrorMessage = "Campo {0} é obrigatório")]
        public string PhoneNumber { get; set; }





    }
}