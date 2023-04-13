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
    public class RespostasController : Controller
    {
        RepositorioResposta repositorioResposta = new RepositorioResposta();
        RepositorioPergunta repositorioPergunta = new RepositorioPergunta();

        public ActionResult Index(int IdPergunta)
        {
            PerguntaRespostasVM perguntaRespostasVM = new PerguntaRespostasVM();
            perguntaRespostasVM.Respostas = repositorioResposta.Listar();
            perguntaRespostasVM.Pergunta = repositorioPergunta.ObterPorId(IdPergunta);

            if (!Configuracao.VerificarUsuarioLogado())
            {
                return RedirectToAction("Entrar", "Login");
            }

            return View(perguntaRespostasVM);
        }

        public ActionResult Novo()
        {
            return View(new Respostas());
        }

        [HttpPost]
        public ActionResult Novo(Respostas resposta)
        {
            return View();
        }

        //public ActionResult Alterar(int id)
        //{
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult Alterar(Respostas resposta)
        //{

        //    return View();
        //}

        [HttpGet]
        public ActionResult Excluir(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Excluir(Respostas resposta)
        {
  
            return View();

        }
    }
}