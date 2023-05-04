using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using DevCode.webapp.Data;
using DevCode.webapp.Models;
using DevCode.webapp.Models.Enum;
using DevCode.webapp.Util;

namespace DevCode.webapp.Repositorio
{
    public class RepositorioPergunta : IRepositorio<Perguntas>
    {
        private readonly AplicationDbContext contexto;
    

        public RepositorioPergunta()
        {
            contexto = new AplicationDbContext();
        }


        public void Alterar(Perguntas entidade)
        {
            var perguntas = contexto.Pergunta.First(x => x.IDPergunta == entidade.IDPergunta);
            perguntas.IDPergunta = entidade.IDPergunta;
            perguntas.Titulo = entidade.Titulo;
            perguntas.Detalhes = entidade.Detalhes;
            perguntas.Esperado = entidade.Esperado;
            perguntas.DataEnvio = entidade.DataEnvio;
            contexto.SaveChanges();
        }

        public void Excluir(Perguntas entidade)
        {
            var perguntas = contexto.Pergunta.First(x => x.IDPergunta == entidade.IDPergunta);
            contexto.Set<Perguntas>().Remove(perguntas);
            contexto.SaveChanges();
        }

        public void Salvar(Perguntas entidade)
        {
            contexto.Pergunta.Add(entidade);
            contexto.SaveChanges();
        }

        public IList<Perguntas> Listar()
        {
            return contexto.Pergunta.ToList();
        }

        public Perguntas ObterPorId(int id)
        {
            return contexto.Pergunta.First(x => x.IDPergunta == id);
        }

        public Perguntas Find(int id)
        {
            return contexto.Pergunta.Find(id);
        }

        public void DarLike(Perguntas entidade)
        {
            var perguntas = contexto.Pergunta.First(x => x.IDPergunta == entidade.IDPergunta);
            if (!Util.UtilClass.deuLike)
            {
                if (perguntas.Likes == null)
                {
                    perguntas.Likes = 1;
                }
                else
                {
                    perguntas.Likes++;
                }
                Util.UtilClass.deuLike = true;
            }
            else
            {
                perguntas.Likes--;
                Util.UtilClass.deuLike = false;
            }


            contexto.SaveChanges();
        }

        public void Vizualizar(Perguntas entidade)
        {
            Perguntas pergunta = contexto.Pergunta.FirstOrDefault(x => x.IDPergunta == entidade.IDPergunta);

            if (pergunta.Views == null)
            {
                pergunta.Views = 1;
            }
            else
            {
                pergunta.Views++;
            }

            contexto.SaveChanges();
        }

        public void UpdateCometarios(Perguntas entidade)
        {
            Perguntas pergunta = contexto.Pergunta.FirstOrDefault(x => x.IDPergunta == entidade.IDPergunta);

            if(pergunta.Comments == null)
            {
                pergunta.Comments = 1;
            }
            else
            {
                pergunta.Comments++;
            }

            contexto.SaveChanges();
        }

   
    }
}