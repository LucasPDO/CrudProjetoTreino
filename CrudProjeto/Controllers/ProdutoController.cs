using CrudProjetoClassLibrary.Entidades;
using CrudProjetoClassLibrary.Negocios;
using Microsoft.AspNetCore.Mvc;

namespace CrudProjeto.Controllers
{
    public class ProdutoController : Controller
    {
        public IActionResult Index()
        {
            var produtos = new ProdutoNegocios().RetornaProdutos();
            return View(produtos);
        }     
        [HttpPost]
        public IActionResult Create(Produto produto)
        {
            if (ModelState.IsValid)
            {               
                try
                {
                    new ProdutoNegocios().CreateProduto(produto);

                    TempData["SuccessMessage"] = "Produto criado com sucesso!";
                    return RedirectToAction("Index");

                }
                catch (Exception ex)
                {
                    TempData["ErrorMessage"] = $"Ocorreu um erro ao criar o produto: {ex.Message}";
                }
            }
            return View(produto);
        }
        [HttpPost]
        public IActionResult Edit(Produto produto)
        {
            new ProdutoNegocios().AtualizaProduto(produto);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            try
            {
                new ProdutoNegocios().ExcluirProduto(id);
                TempData["SuccessMessage"] = "Produto excluído com sucesso!";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Ocorreu um erro ao excluir o produto: {ex.Message}";
            }
            return RedirectToAction("Index");
        }
    }
}
