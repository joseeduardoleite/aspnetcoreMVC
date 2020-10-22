using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using aspnetcoreMVC.Models;
using aspnetcoreMVC.Database;
using Microsoft.EntityFrameworkCore;

namespace aspnetcoreMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDBContext database;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, ApplicationDBContext database)
        {
            _logger = logger;
            this.database = database;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Teste()
        {
            // Categoria categoria1 = new Categoria();
            // categoria1.Nome = "Victor";
            // Categoria categoria2 = new Categoria();
            // categoria2.Nome = "Jose";
            // Categoria categoria3 = new Categoria();
            // categoria3.Nome = "Erik";
            // Categoria categoria4 = new Categoria();
            // categoria4.Nome = "Wesley";

            // List<Categoria> catList = new List<Categoria>();
            // catList.Add(categoria1);
            // catList.Add(categoria2);
            // catList.Add(categoria3);
            // catList.Add(categoria4);

            // database.AddRange(catList);

            // database.SaveChanges();

            var listaCategorias = database.Categorias.Where(categorias => categorias.Nome.Equals("Jose")).ToList();

            Console.WriteLine("----Categorias----");

            listaCategorias.ForEach(categoria => {
                Console.WriteLine(categoria.ToString());
            });

            return Content("Dados salvos");
        }

        public IActionResult Relacionamento()
        {
            // Produto prod = new Produto();
            // prod.Nome = "arroz";
            // prod.Categoria = database.Categorias.First(x => x.Id == 1);

            // Produto prod2 = new Produto();
            // prod2.Nome = "feijao";
            // prod2.Categoria = database.Categorias.First(x => x.Id == 2);

            // Produto prod3 = new Produto();
            // prod3.Nome = "lentilha";
            // prod3.Categoria = database.Categorias.First(x => x.Id == 3);

            // database.Add(prod);
            // database.Add(prod2);
            // database.Add(prod3);

            // database.SaveChanges();

            // var listaProdutos = database.Produtos.Include(p => p.Categoria).ToList();

            // listaProdutos.ForEach(produto => {
            //     Console.WriteLine(produto.ToString());
            // });

            var listaProdutosCategoria = database.Produtos.Where(p => p.Categoria.Id == 1).ToList();

            listaProdutosCategoria.ForEach(produto => {
                Console.WriteLine(produto.ToString());
            });

            return Content("Relacionamento");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
