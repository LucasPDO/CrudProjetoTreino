using CrudProjetoClassLibrary.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace CrudProjeto.Controllers
{
    public class ProdutoController : Controller
    {
        private static List<Produto> Produtos = new List<Produto>
        {
            new Produto { Id = 1, Nome = "Produto A", Preco = 10.0m },
            new Produto { Id = 2, Nome = "Produto B", Preco = 20.0m },
            new Produto { Id = 3, Nome = "Produto C", Preco = 30.0m }
        };
        public IActionResult Index()
        {
            return View(Produtos);
        }
        [HttpPost]
        public IActionResult Edit(Produto produto)
        {
            var prod = Produtos.FirstOrDefault(p => p.Id == produto.Id);
            if (prod != null)
            {
                prod.Nome = produto.Nome;
                prod.Preco = produto.Preco;
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var prod = Produtos.FirstOrDefault(p => p.Id == id);
            if (prod != null)
            {
                Produtos.Remove(prod);
            }
            return RedirectToAction("Index");
        }
    }
}
