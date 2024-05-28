using CrudProjetoClassLibrary.Dados;
using CrudProjetoClassLibrary.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudProjetoClassLibrary.Negocios
{
    public class ProdutoNegocios
    {
        public void CreateProduto(Produto produto)
        {
            //Colocar as regras de negocio
           

            new ProdutoDados().CreateProduto(produto);
        }
        public List<Produto> RetornaProdutos()
        {
            return new ProdutoDados().RetornaProdutos();
        }

        public void ExcluirProduto(int id)
        {
            new ProdutoDados().ExcluirProduto(id);
        }
        public void AtualizaProduto(Produto produto)
        {
            //Colocar as regras de negocio


            new ProdutoDados().AtualizaProduto(produto);
        }
    }
}
