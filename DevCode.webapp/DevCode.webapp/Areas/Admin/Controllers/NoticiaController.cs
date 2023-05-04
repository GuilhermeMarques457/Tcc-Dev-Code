using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevCode.webapp.Areas.Admin.Models;
using DevCode.webapp.Repositorio;
using DevCode.webapp.Util;

namespace DevCode.webapp.Areas.Admin.Controllers
{
    public class NoticiaController : Controller
    {
        RepositorioNoticia repositorio = new RepositorioNoticia();
     

        public ActionResult Novo()
        {
            return View(new Noticia());
        }

        [HttpPost]
        public ActionResult Novo(Noticia noticia)
        {
            if (ModelState.IsValid)
            {
                noticia.DataEnvio = DateTime.Now;
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

        public ActionResult Alterar(int id)
        {
            Noticia noticia = repositorio.ObterPorId(id);
            return View(noticia);
        }

        [HttpPost]
        public ActionResult Alterar(Noticia noticia)
        {
            if (ModelState.IsValid)
            {
                repositorio.Alterar(noticia);

            }
            return View(noticia);

        }
    }
}