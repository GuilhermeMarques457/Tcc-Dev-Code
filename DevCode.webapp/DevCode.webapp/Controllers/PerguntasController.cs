using DevCode.webapp.Models;
using DevCode.webapp.Models.Enum;
using DevCode.webapp.Repositorio;
using DevCode.webapp.Util;
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

        public ActionResult Index()
        {
            if (!Configuracao.VerificarUsuarioLogado())
            {
                return RedirectToAction("Entrar", "Login");
            }

            return View(repositorio.Listar());
       
        }

        public ActionResult Novo()
        {
            return View(new Perguntas());
        }

        [HttpPost]
        public ActionResult Novo(Perguntas perguntas)
        {
            if (ModelState.IsValid)
            {
                perguntas.DataEnvio = DateTime.Now;
                repositorio.Salvar(perguntas);
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



    }
}