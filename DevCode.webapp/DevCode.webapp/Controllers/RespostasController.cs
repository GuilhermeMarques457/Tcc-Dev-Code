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

        [Route("Respostas/Index/{IdPergunta}")]
        public ActionResult Index(int IdPergunta)
        {

            if (!Configuracao.VerificarUsuarioLogado())
            {
                return RedirectToAction("Entrar", "Login");
            }

            ListarPerguntaRespostasVM perguntaRespostasVM = new ListarPerguntaRespostasVM();

            perguntaRespostasVM.Respostas = repositorioResposta.Listar();
            perguntaRespostasVM.Pergunta = repositorioPergunta.ObterPorId(IdPergunta);


            return View(perguntaRespostasVM);

        }

        [Route("Respostas/Novo/{IdPergunta}")]
        [HttpGet]
        public ActionResult Novo(int IdPergunta)
        {
            if (!Configuracao.VerificarUsuarioLogado())
            {
                return RedirectToAction("Entrar", "Login");
            }

            ResponderPeguntaVM responderPeguntaVM = new ResponderPeguntaVM();
           
            responderPeguntaVM.Pergunta = repositorioPergunta.ObterPorId(IdPergunta);

            return View(responderPeguntaVM);

        }

        [HttpPost]
        public ActionResult Novo(ResponderPeguntaVM responderPeguntaVM)
        {
           

            if (ModelState.IsValid)
            {
                repositorioResposta.Salvar(responderPeguntaVM.Respostas);
                return RedirectToAction("Index", "Perguntas");
            }
            
            return View(responderPeguntaVM);
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