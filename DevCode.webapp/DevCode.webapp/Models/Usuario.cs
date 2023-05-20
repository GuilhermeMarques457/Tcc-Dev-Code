using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;

namespace DevCode.webapp.Models
{
    public class Usuario
    {
        [Key]
        public int IDUsuario { get; set; }

        [DisplayName("Nome")]
        [Required(ErrorMessage = "Campo {0} é obrigatório")]
        public string Nome { get; set; }

        [DisplayName("Sobrenome")]
        [Required(ErrorMessage = "Campo {0} é obrigatório")]
        public string Sobrenome { get; set; }

        [DisplayName("Username")]
        [Required(ErrorMessage = "Campo {0} é obrigatório")]
        public string Username { get; set; }

        [DisplayName("Email")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Por favor entre com um email valido.")]
        [RegularExpression(@"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$", ErrorMessage = "Por favor entre com um email valido.")]
        [Required(ErrorMessage = "Campo {0} é obrigatório")]
        public string Email { get; set; }

        [BindNever]
        [DisplayName("Senha")]
        [Required(ErrorMessage = "Campo {0} é obrigatório")]
        public string Senha { get; set; }

        [BindNever]
        [DisplayName("Confirmar Senha")]
        [Required(ErrorMessage = "Campo {0} é obrigatório")]
        public string ConfirmarSenha { get; set; }

        [DisplayName("Telefone")]
        public string Telefone { get; set; }

        [DisplayName("Profissão")]
        public string Profissao { get; set; }

        public string CaminhoImagemPerfil { get; set; }
        public string CaminhoImagemBanner { get; set; }
        public bool Admin { get; set; }

        //Pontos?
        public int? Pontos { get; set; }
       
       
                

    }
}