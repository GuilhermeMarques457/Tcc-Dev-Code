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

            return View(new Perguntas());

        }

        [HttpPost]
        public ActionResult Novo(Perguntas perguntas)
        {
       
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

        [HttpGet]
        public ActionResult Excluir(int id)
        {
            Perguntas perguntas = repositorio.ObterPorId(id);
            return View(perguntas);
        }

        [HttpPost]
        public ActionResult Excluir(Perguntas perguntas)
        {
            repositorio.Excluir(perguntas);
            return View(perguntas);

        }

        public ActionResult Detalhes(int id)
        {
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