using DevCode.webapp.Models;
using DevCode.webapp.Repositorio;
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
            public ActionResult CadastrarUsuario()
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
                repositorio.Salvar(usuario);
            }
            return View(usuario);
        }

        public ActionResult Alterar(int id)
        {
            Usuario usuario = repositorio.ObterPorId(id);
            return View(usuario);
        }

        [HttpPost]
        public ActionResult Alterar(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                repositorio.Alterar(usuario);

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