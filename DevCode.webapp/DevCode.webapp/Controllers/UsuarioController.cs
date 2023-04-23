using DevCode.webapp.Models;
using DevCode.webapp.Repositorio;
using DevCode.webapp.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DevCode.webapp.Controllers
{
    public class UsuarioController : Controller
    {
        RepositorioUsuario repositorio = new RepositorioUsuario();

        public ActionResult Index()
        {
            return View(repositorio.Listar());
        }

        public ActionResult Novo()
        {
            return View(new Usuario());
        }

        [HttpPost]
        public ActionResult Novo(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                usuario.Senha = MD5.GerarHashMd5(usuario.Senha);
                repositorio.Salvar(usuario);
                return RedirectToAction("Index", "Perguntas");
            }
            return View(usuario);
        }

        [Route("Usuario/Alterar/{IdUsuario}")]
        public ActionResult Alterar(int IdUsuario)
        {
            Usuario usuario = repositorio.ObterPorId(IdUsuario);
            return View(usuario);
        }


        [Route("Usuario/Alterar/{IdUsuario}")]
        [HttpPost]
        public ActionResult Alterar(Usuario usuario)
        {
            
            if (ModelState.IsValid)
            {
                repositorio.Alterar(usuario);
                return RedirectToAction("Index", "Perguntas");

            }
            return View(usuario);

        }

        [HttpGet]
        public ActionResult Excluir(int id)
        {
            Usuario usuario = repositorio.ObterPorId(id);
            return View(usuario);
        }

        [HttpPost]
        public ActionResult Excluir(Usuario usuario)
        {
            repositorio.Excluir(usuario);
            return View(usuario);

        }

        public ActionResult Detalhes(int id)
        {
            Usuario usuario= repositorio.ObterPorId(id);
            return View(usuario);
        }

    }
}