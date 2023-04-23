using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using DevCode.webapp.Models;
using DevCode.webapp.Repositorio;
using DevCode.webapp.Util;

namespace DevCode.webapp.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        RepositorioUsuario repositorio = new RepositorioUsuario();

        public ActionResult Entrar()
        {
            return View(new UsuarioVM());
        }

        [HttpPost]
        public ActionResult Entrar(UsuarioVM usuarioVM)
        {
            if (ModelState.IsValid)
            {
                var buscaUsuario = repositorio.Listar()
                    .Where(x => x.Username == usuarioVM.Username).FirstOrDefault();

                if (buscaUsuario != null)
                {
                    if (buscaUsuario.Senha == MD5.GerarHashMd5(usuarioVM.Senha))
                    {
                        FormsAuthentication.SetAuthCookie(usuarioVM.Username, true);
                        Configuracao.Usuario = buscaUsuario;
                        return RedirectToAction("Index", "Perguntas");
                    }
                }
            }
            return View(usuarioVM);
        }

        [Authorize]
        public ActionResult Sair()
        {
            Session.Clear();
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}