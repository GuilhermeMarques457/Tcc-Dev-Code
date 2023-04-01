using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DevCode.webapp.Data;
using DevCode.webapp.Models;
using DevCode.webapp.Models.Enum;

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
    }
}