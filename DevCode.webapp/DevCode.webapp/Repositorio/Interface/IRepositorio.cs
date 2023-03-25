using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevCode.webapp.Repositorio
{
    public interface IRepositorio<T> where T : class
    {
        void Salvar(T entidade);
        void Alterar(T entidade);
        void Excluir(T entidade);
        IList<T> Listar();
        T ObterPorId(int id);
    }
}
