using DevCode.webapp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DevCode.webapp.Repositorio;

namespace DevCode.webapp.Util
{
    public class UtilMethods
    {
        public static List<Amizade> PegarListaDeAmigos(int IdUsuario)
        {
            RepositorioAmizade RepositorioAmizade = new RepositorioAmizade();

            return RepositorioAmizade.PegarListaDeAmigos(IdUsuario);
        }

        public static Amizade PegarAmizade(int IdUsuario, int IdUsuarioAmigo)
        {
            RepositorioAmizade RepositorioAmizade = new RepositorioAmizade();

            return RepositorioAmizade.PegarAmizade(IdUsuario, IdUsuarioAmigo);

        }

        public static int? PegarPontos(int idUsuario)
        {
            RepositorioUsuario repositorioUsuario = new RepositorioUsuario();

            return repositorioUsuario.PegarPontos(idUsuario);
        }

        public static List<Usuario> PegarUsuarioPorPontos()
        {
            RepositorioUsuario repositorioUsuario = new RepositorioUsuario();

            return repositorioUsuario.ObterListaPorPontuação();
        }

        public static int SearchAmizadeEncontrada(int idUsuarioRecebido)
        {
            RepositorioAmizade RepositorioAmizade = new RepositorioAmizade();

            return RepositorioAmizade.SearchAmizadeEncontrada(idUsuarioRecebido).Count();
        }
    }
}