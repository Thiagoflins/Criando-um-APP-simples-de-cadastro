using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dio.Series.interfaces {
    public interface IRepositorio <T>{
       
            List<T> Lista();

            T RetornaPorId(int Id);

            void Insere(T entidade);

            void Excluir(int Id);

            void Atualizar(int id, T entidade);

            int ProximoId();
    }
    
}
