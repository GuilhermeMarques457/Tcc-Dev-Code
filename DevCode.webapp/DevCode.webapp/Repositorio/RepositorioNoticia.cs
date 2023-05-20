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

        public Noticia Find(int id)
        {
            return contexto.Noticia.Find(id);
        }

        public void DarLike(Noticia entidade)
        {
            var noticia = contexto.Noticia.First(x => x.IDNoticia == entidade.IDNoticia);


            if (UtilClass.ListIdNoticiasLiked.Count == 0)
            {
                if (noticia.Likes == null)
                {
                    noticia.Likes = 1;
                }
                else
                {
                    noticia.Likes++;
                }
                UtilClass.ListIdNoticiasLiked.Add(entidade.IDNoticia);
            }
            else
            {
               
                if (!UtilClass.ListIdNoticiasLiked.Contains(entidade.IDNoticia))
                {
                    if (noticia.Likes == null)
                    {
                        noticia.Likes = 1;
                        UtilClass.ListIdNoticiasLiked.Add(entidade.IDNoticia);
                      
                    }
                    else
                    {
                        noticia.Likes++;
                        UtilClass.ListIdNoticiasLiked.Add(entidade.IDNoticia);
                    }

                }
                else
                {
                    UtilClass.ListIdNoticiasLiked.Remove(entidade.IDNoticia);
                    noticia.Likes--;
                   
                }
             
            }


            contexto.SaveChanges();
        }

        public void Alterar(Noticia entidade)
        {
            throw new NotImplementedException();
        }

        public List<Noticia> SearchNoticias(string query)
        {
            return contexto.Noticia.Where(n => n.Titulo.Contains(query) || n.Detalhes.Contains(query)).ToList();
        }
    }
}