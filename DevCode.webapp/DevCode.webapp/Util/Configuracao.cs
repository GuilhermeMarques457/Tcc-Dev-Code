using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DevCode.webapp.Models;
using DevCode.webapp.Repositorio;

namespace DevCode.webapp.Util
{
    public class Configuracao
    {
        public static Usuario Usuario
        {
            get
            {
                if (HttpContext.Current.Session["Usuario"] == null)
                    Usuario = new RepositorioUsuario()
                        .ObterPorId(int.Parse(HttpContext.Current.User.Identity.Name));

                return HttpContext.Current.Session["Usuario"] as Usuario;
            }
            set
            {
                HttpContext.Current.Session["Usuario"] = value;
            }
        }

        public static bool VerificarUsuarioLogado()
        {
            if (HttpContext.Current.Session["Usuario"] == null)
                return false;
            else
                return true;
        }
    }
}