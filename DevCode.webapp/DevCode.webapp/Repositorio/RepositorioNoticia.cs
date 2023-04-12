using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DevCode.webapp.Areas.Admin.Models;
using DevCode.webapp.Data;

namespace DevCode.webapp.Repositorio
{
    public class RepositorioNoticia : IRepositorio<Noticia>
    {
        private readonly AplicationDbContext contexto;

        public RepositorioNoticia()
        {
            contexto = new AplicationDbContext();
        }
 

        public void Excluir(Noticia entidade)
        {
            var noticia = contexto.Noticia.First(x => x.IDNoticia == entidade.IDNoticia);
            contexto.Set<Noticia>().Remove(noticia);
            contexto.SaveChanges();
        }

        public void Salvar(Noticia entidade)
        {
            contexto.Noticia.Add(entidade);
            contexto.SaveChanges();
        }

        public IList<Noticia> Listar()
        {
            return contexto.Noticia.ToList();
        }

        public Noticia ObterPorId(int id)
        {
            return contexto.Noticia.First(x => x.IDNoticia == id);
        }

        public void Alterar(Noticia entidade)
        {
            throw new NotImplementedException();
        }
    }
}