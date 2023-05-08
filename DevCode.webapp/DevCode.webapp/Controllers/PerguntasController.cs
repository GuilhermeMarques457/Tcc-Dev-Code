using DevCode.webapp.Models;
using DevCode.webapp.Models.Enum;
using DevCode.webapp.Repositorio;
using DevCode.webapp.Util;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DevCode.webapp.Controllers
{
    public class PerguntasController : Controller
    {
        // GET: Perguntas
        RepositorioPergunta repositorio = new RepositorioPergunta();
        RepositorioUsuario repositorioUsuario = new RepositorioUsuario();


        public ActionResult Index()
        {
            if (!Configuracao.VerificarUsuarioLogado())
            {
                return RedirectToAction("Entrar", "Login");
            }

            IList<Perguntas> perguntas = repositorio.Listar();
         
            foreach (Perguntas pergunta in perguntas)
            {
                pergunta.Usuario = repositorioUsuario.ObterPorId(pergunta.IDUsuarioPergunta);

            }

            return View(repositorio.Listar());

        }

        public ActionResult Novo()
        {
            if (!Configuracao.VerificarUsuarioLogado())
            {
                return RedirectToAction("Entrar", "Login");
            }

            var TagsPrincipal = Enum.GetValues(typeof(Tags))
                     .Cast<Tags>()
                     .Select(s => new SelectListItem
                     {
                         Value = ((int)s).ToString(),
                         Text = s.ToString()
                     }).ToList();

            var TagsSecundaria = Enum.GetValues(typeof(Tags))
                     .Cast<Tags>()
                     .Select(s => new SelectListItem
                     {
                         Value = ((int)s).ToString(),
                         Text = s.ToString()
                     }).ToList();

            ViewBag.TagPrincipal = TagsPrincipal;

            TagsSecundaria.Insert(0, new SelectListItem { Value = "", Text = "" });

            ViewBag.TagSecondaria = TagsSecundaria;

            return View(new Perguntas());

        }

        [HttpPost]
        public ActionResult Novo(Perguntas perguntas)
        {
            if (!Configuracao.VerificarUsuarioLogado())
            {
                return RedirectToAction("Entrar", "Login");
            }

            if (ModelState.IsValid)
            {  
                perguntas.DataEnvio = DateTime.Now;
                repositorio.Salvar(perguntas);
                return RedirectToAction("Index", "Perguntas");
            }
            return View(perguntas);
        }

        public ActionResult Alterar(int id)
        {
            if (!Configuracao.VerificarUsuarioLogado())
            {
                return RedirectToAction("Entrar", "Login");
            }

            Perguntas perguntas = repositorio.ObterPorId(id);
            return View(perguntas);
        }

        [HttpPost]
        public ActionResult Alterar(Perguntas perguntas)
        {

            if (ModelState.IsValid)
            {
                repositorio.Alterar(perguntas);

            }
            return View(perguntas);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Excluir(int Id)
        {
            Perguntas pergunta = repositorio.ObterPorId(Id);
            repositorio.Excluir(pergunta);

            return RedirectToAction("Index", "Perguntas");
        }

        public ActionResult Detalhes(int id)
        {
            if (!Configuracao.VerificarUsuarioLogado())
            {
                return RedirectToAction("Entrar", "Login");
            }

            Perguntas perguntas = repositorio.ObterPorId(id);
            return View(perguntas);
        }

        [HttpPost]
        public JsonResult Like(int id)
        {
            Perguntas pergunta = repositorio.Find(id);

            if (pergunta != null)
            {
                repositorio.DarLike(pergunta);
                return Json(new { likes = pergunta.Likes });
            }
            else
            {
                return Json(new { error = "Não foi possivel encontrar pergunta" });
            }
        }


    }
}