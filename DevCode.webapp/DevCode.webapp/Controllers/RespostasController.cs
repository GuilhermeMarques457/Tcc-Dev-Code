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

        [HttpGet]
        public ActionResult Index(int IdPergunta)
        {
            ListarPerguntaRespostasVM perguntaRespostasVM = new ListarPerguntaRespostasVM();

            perguntaRespostasVM.Respostas = repositorioResposta.Listar();
            perguntaRespostasVM.Pergunta = repositorioPergunta.ObterPorId(IdPergunta);

            if (!Configuracao.VerificarUsuarioLogado())
            {
                return RedirectToAction("Entrar", "Login");
            }

            return View(perguntaRespostasVM);


            //{
            //    Pergunta = new Perguntas()
            //    {
            //        DataEnvio = new DateTime(),
            //        Detalhes = "asasa",
            //        Esperado = "dasdas",
            //        IDPergunta = 2,
            //        IDUsuario = 3,

            //    },
            //    Respostas = new List<Respostas>() 
            //    {

            //    }
            //};

            //Respostas respostas1 = new Respostas()
            //{
            //    DataResposta = new DateTime(),
            //    ExplicacaoResposta = "adsadass",
            //    IDPergunta = 1,
            //    IDRespostas = 1,
            //    IDUsuario = 1,
            //};
            //Respostas respostas2 = new Respostas()
            //{
            //    DataResposta = new DateTime(),
            //    ExplicacaoResposta = "afasdf3242",
            //    IDPergunta = 2,
            //    IDRespostas = 2,
            //    IDUsuario = 2,
            //};

            //perguntaRespostasVM.Respostas.Add(respostas1);
            //perguntaRespostasVM.Respostas.Add(respostas2);


        }

        [HttpGet]
        public ActionResult Novo(int IdPergunta)
        {
            ResponderPeguntaVM responderPeguntaVM = new ResponderPeguntaVM();
           
            responderPeguntaVM.Pergunta = repositorioPergunta.ObterPorId(IdPergunta);

            return View(responderPeguntaVM);



            //{
            //    Pergunta = new Perguntas()
            //    {
            //        DataEnvio = new DateTime(),
            //        Detalhes = "asasa",
            //        Esperado = "dasdas",
            //        IDPergunta = 2,
            //        IDUsuario = 3,

            //    },
            //};
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