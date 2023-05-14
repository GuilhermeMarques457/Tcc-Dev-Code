﻿using DevCode.webapp.Models;
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
    }
}