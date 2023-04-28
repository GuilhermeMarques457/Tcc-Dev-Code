using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DevCode.webapp.Areas.Admin.Models;
using DevCode.webapp.Data;
using DevCode.webapp.Models;

namespace DevCode.webapp.Repositorio
{
    public class RepositorioResposta : IRepositorio<Respostas>
    {
        private readonly AplicationDbContext contexto;

        public RepositorioResposta()
        {
            contexto = new AplicationDbContext();
        }

        public void Alterar(Respostas entidade)
        {
            var respostas = contexto.Respostas.First(x => x.IDRespostas == entidade.IDRespostas);
            respostas.IDRespostas = entidade.IDRespostas;
            respostas.IDUsuarioResposta = entidade.IDUsuarioResposta;
            respostas.ExplicacaoResposta = entidade.ExplicacaoResposta;
            contexto.SaveChanges();
        }

        public void Excluir(Respostas entidade)
        {
            var resposta = contexto.Respostas.First(x => x.IDRespostas == entidade.IDRespostas);
            contexto.Set<Respostas>().Remove(resposta);
            contexto.SaveChanges();
        }

        public void Salvar(Respostas entidade)
        {
            contexto.Respostas.Add(entidade);
            contexto.SaveChanges();
        }

        public IList<Respostas> Listar()
        {
            return contexto.Respostas.ToList();
        }

        public Respostas ObterPorId(int id)
        {
            return contexto.Respostas.First(x => x.IDRespostas == id);
        }

        public IList<Respostas> ObterListaDePerguntasPorId(int id)
        {
            return contexto.Respostas.Where(x => x.IDPergunta == id).ToList();
        }

        public Respostas Find(int id)
        {
            return contexto.Respostas.Find(id);
        }

        public void DarLike(Respostas entidade)
        {

            var resposta = contexto.Respostas.First(x => x.IDRespostas == entidade.IDRespostas);
            if (!Util.UtilClass.deuLike)
            {
                if (resposta.Likes == null)
                {
                    resposta.Likes = 1;
                }
                else
                {
                    resposta.Likes++;
                }
                Util.UtilClass.deuLike = true;
            }
            else
            {
                resposta.Likes--;
                Util.UtilClass.deuLike = false;
            }

            contexto.SaveChanges();
        }
    }
}