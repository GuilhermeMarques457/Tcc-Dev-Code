﻿using System;
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
    public class HomeController : Controller
    {
        RepositorioUsuario RepositorioUsuario = new RepositorioUsuario();
        RepositorioNoticia RepositorioNoticia = new RepositorioNoticia();
        RepositorioPergunta RepositorioPergunta = new RepositorioPergunta();

        public ActionResult Index()
        {
            HomeVM homeVM = new HomeVM();
            homeVM.Perguntas = RepositorioPergunta.Listar().OrderByDescending(x => x.IDPergunta).Take(4).ToList();
            homeVM.Noticias = RepositorioNoticia.Listar().OrderByDescending(x => x.IDNoticia).Take(4).ToList();
            return View(homeVM);
        }

        [HttpPost]
        public ActionResult Index(HomeVM homeVM)
        {
            if (ModelState.IsValid)
            {
                var buscaUsuario = RepositorioUsuario.Listar()
                    .Where(x => x.Username == homeVM.UsuarioVM.Username).FirstOrDefault();

                if (buscaUsuario != null)
                {
                    if (buscaUsuario.Senha == MD5.GerarHashMd5(homeVM.UsuarioVM.Senha))
                    {
                        FormsAuthentication.SetAuthCookie(homeVM.UsuarioVM.Username, true);
                        Configuracao.Usuario = buscaUsuario;
                        return RedirectToAction("Index", "Perguntas");
                    }
                }
            }
            homeVM.Perguntas = RepositorioPergunta.Listar().OrderByDescending(x => x.IDPergunta).Take(4).ToList();
            homeVM.Noticias = RepositorioNoticia.Listar().OrderByDescending(x => x.IDNoticia).Take(4).ToList();
            return View(homeVM);
        }

        [Authorize]
        public ActionResult Sair()
        {
            Session.Clear();
            FormsAuthentication.SignOut();
            return RedirectToAction("Entrar", "Login");
        }
    }
}