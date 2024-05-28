using AcessoDadosClassLibrary;
using CrudProjetoClassLibrary.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudProjetoClassLibrary.Dados
{
    public class ProdutoDados
    {
        internal void CreateProduto(Produto produto)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "CadastrarProduto";
            command.Parameters.Add("@Nome", SqlDbType.NVarChar, 100).Value = produto.Nome;
            command.Parameters.Add("@Preco", SqlDbType.Float, 100).Value = produto.Preco;
            DAO.ExecutaProcedure(command);
        }
        internal List<Produto> RetornaProdutos()
        {
            List<Produto> produtos = new List<Produto>();
            SqlCommand command = new SqlCommand();
            command.CommandText = "ListarTodosProdutos";         
            DAO.ExecutaProcedure(command);
            using (IDataReader reader = DAO.ExecutaDataReader(command))
            {
                while (reader.Read())
                {
                    produtos.Add(new Produto()
                    {
                        Id = reader.GetInt32(0),
                        Nome = reader.GetString(1),
                        Preco = (float)Convert.ToDecimal(reader["Preco"])
                    });
                }
            }
            return produtos.Count == 0 ? null : produtos;
        }

        internal void ExcluirProduto(int id)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "ExcluirProduto";
            command.Parameters.Add("@Id", SqlDbType.Int, 100).Value = id;
            DAO.ExecutaProcedure(command);
        }

        internal void AtualizaProduto(Produto produto)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "AtualizarProdutoCerto";
            command.Parameters.Add("@Id", SqlDbType.NVarChar, 100).Value = produto.Id;
            command.Parameters.Add("@Nome", SqlDbType.NVarChar, 100).Value = produto.Nome;
            command.Parameters.Add("@Preco", SqlDbType.Float, 100).Value = produto.Preco;
            DAO.ExecutaProcedure(command);
        }

    }
}
