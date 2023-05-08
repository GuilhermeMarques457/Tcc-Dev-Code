using DevCode.webapp.Models;
using DevCode.webapp.Repositorio;
using DevCode.webapp.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
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
                usuario.ConfirmarSenha = MD5.GerarHashMd5(usuario.ConfirmarSenha);
                usuario.CaminhoImagemBanner = "/Content/imgs/ProfileImgs/foto-padrao-banner.png";
                usuario.CaminhoImagemPerfil = "/Content/imgs/ProfileImgs/foto-padrao-perfil.png";
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
        public ActionResult Alterar(Usuario usuario, HttpPostedFileBase profile, HttpPostedFileBase banner)
        {
            
            if (ModelState.IsValid)
            {
                if (profile != null && profile.ContentLength > 0)
                {
                    usuario.CaminhoImagemPerfil = MudarFoto(profile);
                    Configuracao.Usuario.CaminhoImagemPerfil = MudarFoto(profile);
                }
                else
                {
                    usuario.CaminhoImagemPerfil = Configuracao.Usuario.CaminhoImagemPerfil;
                }

                if (banner != null && banner.ContentLength > 0)
                {
                    usuario.CaminhoImagemBanner = MudarFoto(banner);
                    Configuracao.Usuario.CaminhoImagemBanner = MudarFoto(banner);
                }
                else
                {
                    usuario.CaminhoImagemBanner = Configuracao.Usuario.CaminhoImagemBanner;
                }

                repositorio.Alterar(usuario);
                return RedirectToAction("Index", "Perguntas");

            }
            return View(usuario);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Excluir(int Id)
        {
            Usuario usuario = repositorio.ObterPorId(Id);
            repositorio.Excluir(usuario);

            return RedirectToAction("Sair", "Login");
        }

        public ActionResult Detalhes(int id)
        {
            Usuario usuario= repositorio.ObterPorId(id);
            return View(usuario);
        }

        [HttpPost]
        public ActionResult UploadProfileImage(HttpPostedFileBase file)
        {
            return RedirectToAction("Index", "Perguntas");
        }

        public string MudarFoto(HttpPostedFileBase img)
        {
            var fileName = Path.GetFileName(Configuracao.Usuario.IDUsuario + img.FileName);
            var path = Path.Combine(Server.MapPath("~/Content/imgs/ProfileImgs"), fileName);
            img.SaveAs(path);

            return "/Content/imgs/ProfileImgs/" + fileName;
        }

    }
}