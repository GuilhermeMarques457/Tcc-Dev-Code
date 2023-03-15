using DevCode.webapp.Models;
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
        public ActionResult Index()
        {
            return View();
        }

        //Tela de Cadastro e Exibir

        [HttpGet]
        public ActionResult CadastroPerguntas()
        {
            return View(new Perguntas());
        }


        [HttpPost]
        public ActionResult CadastroPerguntas(Perguntas perguntas)
        {
            if(ModelState.IsValid)
            {
                //Retorna para algume view
                return View();

            }
            return View();
        }



    }
}