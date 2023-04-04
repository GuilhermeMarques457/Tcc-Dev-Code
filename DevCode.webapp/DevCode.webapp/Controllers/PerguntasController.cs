using DevCode.webapp.Models;
using DevCode.webapp.Models.Enum;
using DevCode.webapp.Repositorio;
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
            //return View(repositorio.Listar());
            List<Perguntas> Perguntas = new List<Perguntas>
            {
                new Perguntas()
                {
                    Titulo = "Titulo1",
                    Detalhes = "Detalhe1",
                    DataEnvio = new DateTime().Date,
                    Esperado = "Esperos ser feliz",
                    IDPergunta = 1,
               
              
                },
                 new Perguntas()
                {
                    Titulo = "Titulo2",
                    Detalhes = "Detalhe2",
                    DataEnvio = new DateTime().Date,
                    Esperado = "Esperos ser muito feliz",
                    IDPergunta = 1,


                },

            };

            return View(Perguntas);
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