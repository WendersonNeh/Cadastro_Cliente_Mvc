using Cadastro.Models;
using cadastro_cliente_mvc.Data;
using System.Collections.Generic;
using System.Linq;


namespace Cadastro_Clientes_Mvc_Teste.Repositorio
{
    public class ContatoRepositorio : IContatoRepositorio
    {

        private readonly BancoContext _bancoContext;
        private object contatodb;

        public ContatoRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public ContadoModel ListarPorId(int id)
        {
            return _bancoContext.Contatos.FirstOrDefault(x => x.Id == id);
        }

        //Lista de clientes
        public List<ContadoModel> BuscarTodos()
        {
            return _bancoContext.Contatos.ToList();
        }

        //Adicionar clientes
        public ContadoModel Adicionar(ContadoModel contato)
        {
            _bancoContext.Contatos.Add(contato);
            _bancoContext.SaveChanges();
            return contato;

        }


        //Atualizar Contato
        public ContadoModel Atualizar(ContadoModel contato)
        {
            ContadoModel contatoDB = ListarPorId(contato.Id);
            if (contato == null) throw new System.Exception("Houve um erro na atualização do contato!!");

            contatoDB.Name = contato.Name;
            contatoDB.email = contato.email;
            contatoDB.celular = contato.celular;

            _bancoContext.Contatos.Update(contatoDB);
            _bancoContext.SaveChanges();

            return contatoDB;

        }


        //deletar
        public bool Apagar(int id)
        {

            ContadoModel contatoDB = ListarPorId(id);

            if (contatoDB == null) throw new System.Exception("Houve um erro ao deletar!!");
            {

                _bancoContext.Contatos.Remove(contatoDB);
                _bancoContext.SaveChanges();
                

                return true;
            }
            
            
        }
    }

   
}
