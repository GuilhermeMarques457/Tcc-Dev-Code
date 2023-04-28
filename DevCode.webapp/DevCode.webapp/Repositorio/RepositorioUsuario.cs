﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DevCode.webapp.Data;
using DevCode.webapp.Models;

namespace DevCode.webapp.Repositorio
{
    public class RepositorioUsuario : IRepositorio<Usuario>
    {
        private readonly AplicationDbContext contexto;

        public RepositorioUsuario()
        {
            contexto = new AplicationDbContext();
        }


        public void Alterar(Usuario entidade)
        {
            var usuario = contexto.Usuario.First(x => x.IDUsuario == entidade.IDUsuario);
            usuario.IDUsuario = entidade.IDUsuario;
            usuario.Nome = entidade.Nome;
            usuario.Sobrenome = entidade.Sobrenome;
            usuario.Username = entidade.Username;
            usuario.Senha = entidade.Senha;
            usuario.Telefone = entidade.Telefone;
            usuario.Email = entidade.Email;
            usuario.Profissao = entidade.Profissao;
            usuario.CaminhoImagemPerfil = entidade.CaminhoImagemPerfil;
            usuario.CaminhoImagemBanner = entidade.CaminhoImagemBanner;

            contexto.SaveChanges();
        }

        public void Excluir(Usuario entidade)
        {
            var usuario = contexto.Usuario.First(x => x.IDUsuario == entidade.IDUsuario);
            contexto.Set<Usuario>().Remove(usuario);
            contexto.SaveChanges();
        }

        public void Salvar(Usuario entidade)
        {
            contexto.Usuario.Add(entidade);
            contexto.SaveChanges();
        }

        public IList<Usuario> Listar()
        {
            return contexto.Usuario.ToList();
        }

        public Usuario ObterPorId(int id)
        {
            return contexto.Usuario.First(x => x.IDUsuario== id);
        }

        public string ObterUsernamePorId(int id)
        {
            return contexto.Usuario.First(x => x.IDUsuario == id).Username;
        }

        public string ObterFotoPerfilPorId(int id)
        {
            return contexto.Usuario.First(x => x.IDUsuario == id).CaminhoImagemPerfil;
        }

        //public void AlterarFotoDePerfil(int userId, string profileImagePath)
        //{
        //    Usuario user = contexto.Usuario.Find(userId);
        //    if (user != null)
        //    {
        //        user.CaminhoImagemPerfil = profileImagePath;
        //        contexto.SaveChanges();
        //    }
        //}
    }
}