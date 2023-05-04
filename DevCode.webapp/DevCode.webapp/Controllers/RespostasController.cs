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
        RepositorioUsuario repositorioUsuario = new RepositorioUsuario();

        [Route("Respostas/Index/{IdPergunta}")]
        public ActionResult Index(int IdPergunta)
        {
            if (!Configuracao.VerificarUsuarioLogado())
            {
                return RedirectToAction("Entrar", "Login");
            }

            ListarPerguntaRespostasVM perguntaRespostasVM = new ListarPerguntaRespostasVM() 
            {
                Respostas = repositorioResposta.ObterListaDePerguntasPorId(IdPergunta),
                Pergunta = repositorioPergunta.ObterPorId(IdPergunta)
            };

            
            ViewBag.Username = repositorioUsuario.ObterUsernamePorId(perguntaRespostasVM.Pergunta.IDUsuarioPergunta);
            ViewBag.CaminhoImagemPerfil = repositorioUsuario.ObterFotoPerfilPorId(perguntaRespostasVM.Pergunta.IDUsuarioPergunta);

            IList<Respostas> respostas = repositorioResposta.Listar();
           
            foreach (Respostas resposta in respostas)
            {
                resposta.Usuario = repositorioUsuario.ObterPorId(resposta.IDUsuarioResposta);
            }

            repositorioPergunta.Vizualizar(perguntaRespostasVM.Pergunta);

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

            ViewBag.Username = repositorioUsuario.ObterUsernamePorId(responderPeguntaVM.Pergunta.IDUsuarioPergunta);
            ViewBag.CaminhoImagemPerfil = repositorioUsuario.ObterFotoPerfilPorId(responderPeguntaVM.Pergunta.IDUsuarioPergunta);

            ViewBag.PeguntaModel = responderPeguntaVM.Pergunta;
            ViewBag.IdPergunta = responderPeguntaVM.Pergunta.IDPergunta;

            return View(new Respostas());

        }

        [Route("Respostas/Novo/{IdPergunta}")]
        [HttpPost]
        public ActionResult Novo(Respostas resposta)
        {
            
            if (ModelState.IsValid)
            {
                Perguntas pergunta = repositorioPergunta.ObterPorId(resposta.IDPergunta);
                repositorioPergunta.UpdateCometarios(pergunta);

                resposta.DataResposta = DateTime.Now;
                repositorioResposta.Salvar(resposta);

                

                return RedirectToAction("Index", "Respostas", resposta.IDPergunta);
            }
            
            return View(resposta);
        }

        [HttpPost]
        public JsonResult Like(int id)
        {
            Respostas resposta = repositorioResposta.Find(id);


            if (resposta != null)
            {
                repositorioResposta.DarLike(resposta);
                return Json(new { likes = resposta.Likes });
            }
            else
            {
                return Json(new { error = "Não foi possivel encontrar pergunta" });
            }
        }

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