using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
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
            if(usuario != null)
            {
               
                var perguntas = contexto.Pergunta.Where(x => x.IDUsuarioPergunta == usuario.IDUsuario);

                foreach (var pergunta in perguntas)
                {
                    var respostasPergunta = contexto.Respostas.Where(x => x.IDPergunta == pergunta.IDPergunta);

                    contexto.Respostas.RemoveRange(respostasPergunta);
                    contexto.Pergunta.Remove(pergunta);
                }

                var respostas = contexto.Respostas.Where(x => x.IDUsuarioResposta == usuario.IDUsuario);
                contexto.Respostas.RemoveRange(respostas);

                var amizades = contexto.Amizades.Where(x => x.IDUsuarioResposta == usuario.IDUsuario || x.IDUsuarioPedido == usuario.IDUsuario);
                contexto.Amizades.RemoveRange(amizades);

                var noticias = contexto.Noticia.Where(n => n.IDUsuarioNoticia == usuario.IDUsuario);
                contexto.Noticia.RemoveRange(noticias);

            }
           
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

        public void AumentarPontos(int id)
        {
            Usuario usuario = contexto.Usuario.First(x => x.IDUsuario == id);
            if(usuario != null)
            {
                if (usuario.Pontos == null)
                {
                    usuario.Pontos = 5;
                }
                else
                {
                    usuario.Pontos+= 5;
                }
            }
            contexto.SaveChanges();
        
        }

        public int? PegarPontos(int id)
        {
            Usuario usuario = contexto.Usuario.First(x => x.IDUsuario == id);
            return usuario.Pontos;
        }

        public List<Usuario> ObterListaPorUsername(string username)
        {
            return contexto.Usuario.Where(p => p.Username.Contains(username)).ToList();
        }
    }
}