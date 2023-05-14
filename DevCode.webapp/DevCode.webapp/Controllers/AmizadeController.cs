using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevCode.webapp.Models;
using DevCode.webapp.Repositorio;
using DevCode.webapp.Util;

namespace DevCode.webapp.Controllers
{
    public class AmizadeController : Controller
    {
        RepositorioAmizade RepositorioAmizade = new RepositorioAmizade();
        RepositorioUsuario RepositorioUsuario = new RepositorioUsuario();

        public ActionResult VerPessoas()
        {
            if (!Configuracao.VerificarUsuarioLogado())
            {
                return RedirectToAction("Entrar", "Login");
            }

            UsuarioAmigosVM usuarioAmigosVM = new UsuarioAmigosVM()
            {
                Usuarios = RepositorioUsuario.Listar().ToList(),
                Amizades = RepositorioAmizade.SearchAmizadeEncontrada(Configuracao.Usuario.IDUsuario)
                
            };

            for (int i = 0; i < usuarioAmigosVM.Amizades.Count; i++)
            {
                usuarioAmigosVM.Amizades[i].UsuarioPedido =
                    RepositorioUsuario.ObterPorId(
                        usuarioAmigosVM.Amizades[i].IDUsuarioPedido);

            }
            

            return View(usuarioAmigosVM);
        }

        [HttpPost]
        public ActionResult EnviarSolicitacao(int IdUsuarioResposta)
        {
            Usuario usuarioResposta = RepositorioUsuario.ObterPorId(IdUsuarioResposta);
            Usuario usuarioPedido = RepositorioUsuario.ObterPorId(Configuracao.Usuario.IDUsuario);


            if (usuarioPedido != null && usuarioResposta != null)
            {
                Amizade amizade = new Amizade()
                {
                    IDUsuarioPedido = usuarioPedido.IDUsuario,
                    IDUsuarioResposta = usuarioResposta.IDUsuario,
                    Amigos = false,
                    Pendente = true
                };

                string mensagemAmizade = RepositorioAmizade.EncontrarAmizade(amizade.IDUsuarioPedido, amizade.IDUsuarioResposta);

                if (mensagemAmizade != "Convite enviado com sucesso")
                {
                    return Json(new { success = false, message = mensagemAmizade });
                }

                RepositorioAmizade.EnviarConvite(amizade);

                return Json(new { success = true });
            }

            return Json(new { error = "Falhou em enviar" });
        }

        [HttpPost]
        public ActionResult AceitarSolicitacao(int IdUsuarioPedido)
        {
            Usuario usuarioPedido = RepositorioUsuario.ObterPorId(IdUsuarioPedido);
            Usuario usuarioResposta = RepositorioUsuario.ObterPorId(Configuracao.Usuario.IDUsuario);


            if (usuarioPedido != null && usuarioResposta != null)
            {
                Amizade amizade = new Amizade()
                {
                    IDUsuarioPedido = usuarioPedido.IDUsuario,
                    IDUsuarioResposta = usuarioResposta.IDUsuario,
                    
                };

                RepositorioAmizade.AceitarSolicitacao(amizade);

                return Json(new { success = true });
            }

            return Json(new { error = "Falhou em enviar" });
        }

        [HttpPost]
        public ActionResult RejeitarSolicitacao(int IdUsuarioPedido)
        {
            Usuario usuarioPedido = RepositorioUsuario.ObterPorId(IdUsuarioPedido);
            Usuario usuarioResposta = RepositorioUsuario.ObterPorId(Configuracao.Usuario.IDUsuario);


            if (usuarioPedido != null && usuarioResposta != null)
            {
                Amizade amizade = new Amizade()
                {
                    IDUsuarioPedido = usuarioPedido.IDUsuario,
                    IDUsuarioResposta = usuarioResposta.IDUsuario,

                };

                RepositorioAmizade.RejeitarSolicitacao(amizade);

                return Json(new { success = true });
            }

            return Json(new { error = "Falhou em enviar" });
        }
    }
}