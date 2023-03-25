using DevCode.webapp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DevCode.webapp.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult Index()
        {
            return View();
        }

        //Página de Cadastro de Usuario
        public ActionResult CadastrarUsuario()
        {
            return View(new Usuario());
        }

        //Página de Cadastro de Usuario
        [HttpPost]
        public ActionResult CadastrarUsuario(Usuario usuario)
        {

            //Vai redirecionar para page das Perguntas
            //Com a partial view de usuario ao lado
            if (ModelState.IsValid)
            {
                //Retorna Perguntas
                return RedirectToAction("Index", "Perguntas", usuario);
            }
            return View(usuario);
        }


        //Página de Entrar no Perfil do usuario
       /* public ActionResult EntrarUsuario(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                //RedirectToAction(string actionName, string controllerName, object routeValues);
                return RedirectToAction("MostrarUsuario", "Usuario", usuario);
            }
            return View();
        }*/



        //Página de Mostrar Usuário
        /*public ActionResult MostrarUsuario(Usuario usuario)
        {
            return View(usuario);

        }*/

    }
}