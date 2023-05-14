using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DevCode.webapp.Areas.Admin.Models;
using DevCode.webapp.Data;
using DevCode.webapp.Models;
using DevCode.webapp.Util;

namespace DevCode.webapp.Repositorio
{
    public class RepositorioAmizade
    {
        private readonly AplicationDbContext contexto;

        public RepositorioAmizade()
        {
            contexto = new AplicationDbContext();
        }

        public List<Amizade> SearchAmizadeEncontrada(int idUsuarioRecebido)
        {
            return contexto.Amizades.Where(a => a.IDUsuarioResposta == idUsuarioRecebido && a.Pendente == true).ToList();
        }

        public void EnviarConvite(Amizade amizade)
        {
            contexto.Amizades.Add(amizade);
            contexto.SaveChanges();
        }

        public void AceitarSolicitacao(Amizade AmizadeFeita)
        {
            var Amizade  = contexto.Amizades.FirstOrDefault(a => a.IDUsuarioPedido == AmizadeFeita.IDUsuarioPedido && a.IDUsuarioResposta == AmizadeFeita.IDUsuarioResposta);
            Amizade.Pendente = false;
            Amizade.Amigos = true;

            contexto.SaveChanges();
        }

        public List<Amizade> PegarListaDeAmigos(int IdUsuario)
        {
            var Amizades = contexto.Amizades.Where(a => a.IDUsuarioResposta == IdUsuario || a.IDUsuarioPedido == IdUsuario).ToList();
            foreach (var amizade in Amizades)
            {
                if (amizade.IDUsuarioPedido == IdUsuario)
                {
                    amizade.UsuarioResposta = contexto.Usuario.FirstOrDefault(u => u.IDUsuario == amizade.IDUsuarioResposta);
                }
                else if (amizade.IDUsuarioResposta == IdUsuario)
                {
                    amizade.UsuarioPedido = contexto.Usuario.FirstOrDefault(u => u.IDUsuario == amizade.IDUsuarioPedido);
                }
            }

            return Amizades;
        }

        public Amizade PegarAmizade(int IdUsuario, int IdUsuariAmigo)
        {
            Amizade amizades = (from a in contexto.Amizades
                                         where (a.IDUsuarioResposta == Configuracao.Usuario.IDUsuario && a.IDUsuarioPedido == IdUsuariAmigo)
                                            || (a.IDUsuarioPedido == Configuracao.Usuario.IDUsuario && a.IDUsuarioResposta == IdUsuariAmigo)
                                         select a).FirstOrDefault();

            return amizades;
        }


        public void RejeitarSolicitacao(Amizade AmizadeFeita)
        {
            var Amizade = contexto.Amizades.FirstOrDefault(a => a.IDUsuarioPedido == AmizadeFeita.IDUsuarioPedido && a.IDUsuarioResposta == AmizadeFeita.IDUsuarioResposta);
            Amizade.Pendente = false;
            Amizade.Amigos = false;

            contexto.SaveChanges();
        }

        public string EncontrarAmizade(int idUsuarioPedido, int idUsuarioResposta)
        {
            var temAmizade = contexto.Amizades.FirstOrDefault(a => a.IDUsuarioPedido == idUsuarioPedido && a.IDUsuarioResposta == idUsuarioResposta);

            if (temAmizade != null)
            {
                if(temAmizade.Pendente == true)
                {
                    return "Você já enviou uma solicitação de amizade para este usuário.";
                }
                if(temAmizade.Amigos == true)
                {
                    return "Você já é amigo desse usuario";
                }
               
            }
            return "Convite enviado com sucesso";
        }

       
    }
}