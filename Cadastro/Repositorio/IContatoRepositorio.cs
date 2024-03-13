using Cadastro.Models;
using System.Collections.Generic;

namespace Cadastro_Clientes_Mvc_Teste.Repositorio
{
    public interface IContatoRepositorio
    {
        ContadoModel ListarPorId(int id);

        List<ContadoModel> BuscarTodos();
        ContadoModel Adicionar(ContadoModel contato);
        ContadoModel Atualizar(ContadoModel contato);
        bool Apagar(int id);


    }
}
