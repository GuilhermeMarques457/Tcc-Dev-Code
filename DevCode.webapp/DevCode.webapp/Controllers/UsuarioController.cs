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
        RepositorioPergunta repositorioPergunta = new RepositorioPergunta();
        RepositorioResposta repositorioResposta = new RepositorioResposta();
       

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
                if (repositorio.ObterPorUsername(usuario.Username) == null)
                {
                    usuario.Senha = MD5.GerarHashMd5(usuario.Senha);
                    usuario.ConfirmarSenha = MD5.GerarHashMd5(usuario.ConfirmarSenha);
                    usuario.CaminhoImagemBanner = "/Content/imgs/ProfileImgs/foto-padrao-banner.png";
                    usuario.CaminhoImagemPerfil = "/Content/imgs/ProfileImgs/foto-padrao-perfil.png";
                    if (repositorio.Listar().Count == 0)
                    {
                        usuario.Admin = true;
                    }
                    repositorio.Salvar(usuario);
                    return RedirectToAction("Index", "Perguntas");
                }
                else
                {
                    ModelState.AddModelError("Username", "Username existente. Tente outro usuario");
                }
            }
            return View(usuario);
        }

        [Route("Usuario/Alterar/{IdUsuario}")]
        public ActionResult Alterar(int IdUsuario)
        {
            Usuario usuario = repositorio.ObterPorId(IdUsuario);
            List<Respostas> respostas = new List<Respostas>();
            List<Perguntas> perguntas = new List<Perguntas>();
            respostas = repositorioResposta.ObterRespostasDoUsuario(usuario.IDUsuario);
            perguntas = repositorioPergunta.ObterPerguntasDoUsuario(usuario.IDUsuario);
            ViewBag.Perguntas = perguntas.Count;
            ViewBag.Respostas = respostas.Count;
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

            Usuario usuarioErrado = repositorio.ObterPorId(usuario.IDUsuario);
            List<Respostas> respostas = new List<Respostas>();
            List<Perguntas> perguntas = new List<Perguntas>();
            respostas = repositorioResposta.ObterRespostasDoUsuario(usuarioErrado.IDUsuario);
            perguntas = repositorioPergunta.ObterPerguntasDoUsuario(usuarioErrado.IDUsuario);
            ViewBag.Perguntas = perguntas.Count;
            ViewBag.Respostas = respostas.Count;
            return View(usuarioErrado);

        }

        public ActionResult MostrarAmigo(int? Id)
        {
            if (!Configuracao.VerificarUsuarioLogado())
            {
                return RedirectToAction("Entrar", "Login");
            }

            int id = Convert.ToInt32(Id);

            Usuario usuario = repositorio.ObterPorId(id);
            PerguntaRespostaVM perguntaRespostaVM = new PerguntaRespostaVM();

            perguntaRespostaVM.Perguntas = repositorioPergunta.ObterPerguntasDoUsuario(usuario.IDUsuario);
            perguntaRespostaVM.Respostas = repositorioResposta.ObterRespostasDoUsuario(usuario.IDUsuario);
            perguntaRespostaVM.Usuario = usuario;
            for (int i = 0; perguntaRespostaVM.Respostas.Count > i; i++)
            {
                int IdPergunta = perguntaRespostaVM.Respostas[i].IDPergunta;
                perguntaRespostaVM.Respostas[i].Perguntas = repositorioPergunta.ObterPorId(IdPergunta);
                perguntaRespostaVM.Respostas[i].Perguntas.Usuario = repositorio.ObterPorId(perguntaRespostaVM.Respostas[i].Perguntas.IDUsuarioPergunta);
            }
            

            return View(perguntaRespostaVM);
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

        public ActionResult ObterListaUsuario()
        {
            // Lógica para obter a lista atualizada de usuários do seu sistema
            IList<Usuario> listaUsuarios = repositorio.Listar(); // Substitua com a sua lógica de obtenção da lista de usuários

            // Retorna a lista de usuários em formato JSON
            return Json(listaUsuarios, JsonRequestBehavior.AllowGet);
        }

    }
}