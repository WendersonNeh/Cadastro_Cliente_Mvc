using Cadastro.Models;
using Cadastro_Clientes_Mvc_Teste.Repositorio;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Cadastro.Controllers
{


    public class ContatoController : Controller
    {
        private readonly IContatoRepositorio _contatoRepositorio;

        public ContatoController(IContatoRepositorio contatoRepositorio)
        {
            _contatoRepositorio = contatoRepositorio;
        }


        public IActionResult Index()
        {
            List<ContadoModel> contatos = _contatoRepositorio.BuscarTodos();

            return View(contatos);
        }

        public IActionResult CriarContato()
        {
            return View();
        }

        public IActionResult EditarContato(int id)
        {
            ContadoModel contato = _contatoRepositorio.ListarPorId(id);
            return View(contato);
        }

        public IActionResult ApagarConfirmacao(int id)
        {

            ContadoModel contato = _contatoRepositorio.ListarPorId(id);
            return View(contato);
        }

        public IActionResult Apagar(int id)
        {
            _contatoRepositorio.Apagar(id);
            return RedirectToAction("index");
        }

        [HttpPost]
        public IActionResult Criar(ContadoModel contato)
        {
            _contatoRepositorio.Adicionar(contato);
            return RedirectToAction("index");
               
        }

        [HttpPost]
        public IActionResult Alterar(ContadoModel contato)
        {
            _contatoRepositorio.Atualizar(contato);
            return RedirectToAction("index");

        }

    }
}
