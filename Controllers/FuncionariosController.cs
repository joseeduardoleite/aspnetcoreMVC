using System.Linq;
using aspnetcoreMVC.Database;
using aspnetcoreMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace aspnetcoreMVC.Controllers
{
    public class FuncionariosController : Controller
    {
        private readonly ApplicationDBContext database;
        public FuncionariosController(ApplicationDBContext database)
        {
            this.database = database;
        }

        public IActionResult Index()
        {
            //retorna um set (colecao) de funcionarios
            var funcionarios = database.Funcionarios.ToList();
            return View(funcionarios);
        }

        public IActionResult Cadastrar()
        {
            return View();
        }

        public IActionResult Editar(int id)
        {
            Funcionario funcionario = database.Funcionarios.First(registro => registro.Id == id);
            return View("Cadastrar", funcionario);
        }

        public IActionResult Deletar(int id)
        {
            Funcionario funcionario = database.Funcionarios.First(registro => registro.Id == id);
            database.Funcionarios.Remove(funcionario);
            database.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Salvar(Funcionario funcionario)
        {
            if (funcionario.Id == 0)
                database.Funcionarios.Add(funcionario);
            else
            {
                Funcionario funcionarioBanco = database.Funcionarios.First(registro => registro.Id == funcionario.Id);
                funcionarioBanco.Nome = funcionario.Nome;
                funcionarioBanco.Salario = funcionario.Salario;
                funcionario.Cpf = funcionario.Cpf;
            }

            database.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}