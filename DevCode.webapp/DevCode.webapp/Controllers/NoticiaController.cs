using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevCode.webapp.Areas.Admin.Models;
using DevCode.webapp.Repositorio;
using DevCode.webapp.Util;

namespace DevCode.webapp.Controllers
{
    public class NoticiaController : Controller
    {
        RepositorioNoticia repositorio = new RepositorioNoticia();
        RepositorioUsuario repositorioUsuario = new RepositorioUsuario();
        // GET: Noticia
        public ActionResult ListarNoticias()
        {
            if (!Configuracao.VerificarUsuarioLogado())
            {
                return RedirectToAction("Entrar", "Login");
            }

            IList<Noticia> noticias = repositorio.Listar();

            foreach (Noticia noticia in noticias)
            {
                noticia.Usuario = repositorioUsuario.ObterPorId(noticia.IDUsuarioNoticia);

            }

            return View(repositorio.Listar());

        }
    }
}