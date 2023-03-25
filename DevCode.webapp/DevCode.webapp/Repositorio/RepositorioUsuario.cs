using System;
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
            throw new NotImplementedException();
        }

        public void Excluir(Usuario entidade)
        {
            throw new NotImplementedException();
        }

        public IList<Usuario> Listar()
        {
            throw new NotImplementedException();
        }

        public Usuario ObterPorId(int id)
        {
            throw new NotImplementedException();
        }

        public void Salvar(Usuario entidade)
        {
            throw new NotImplementedException();
        }
    }
}