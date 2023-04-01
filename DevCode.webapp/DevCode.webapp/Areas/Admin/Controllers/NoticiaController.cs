using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevCode.webapp.Areas.Admin.Models;
using DevCode.webapp.Repositorio;

namespace DevCode.webapp.Areas.Admin.Controllers
{
    public class NoticiaController : Controller
    {
        RepositorioNoticia repositorio = new RepositorioNoticia();
        // GET: Admin/Noticia
        public ActionResult Novo()
        {
            return View(new Noticia());
        }

        [HttpPost]
        public ActionResult Novo(Noticia noticia)
        {
            if (ModelState.IsValid)
            {
                repositorio.Salvar(noticia);
            }
            return View(noticia);
        }

        [HttpGet]
        public ActionResult Excluir(int id)
        {
            Noticia noticia = repositorio.ObterPorId(id);
            return View(noticia);
        }

        [HttpPost]
        public ActionResult Excluir(Noticia noticia)
        {
            repositorio.Excluir(noticia);
            return View(noticia);

        }
    }
}