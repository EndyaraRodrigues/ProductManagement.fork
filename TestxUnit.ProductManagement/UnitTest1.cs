using Microsoft.Data.Sqlite;
using ProductManagement.Domain.Entities;
using ProductManagement.Data.Repositories;
using System.Runtime.CompilerServices;
using TestxUnit.ProductManagement.Helpers;



namespace TestxUnit.ProductManagement
{
    public class UnitTest1


    {

        private ProdutoSQLiteRepository CreateRepository (SqliteConnection con)
        {
            return new ProdutoSQLiteRepository(con);
        }

        [Fact]
        public void DeveAdicionarProduto()
        {
            using var con = SqliteTestHelper.CreateInMemoryDataBase();
            var repo = CreateRepository(con);

            var produto = new Produto { Nome = "Café", Preco = 2.5m };

            repo.Adicionar(produto);
            var lista = repo.ObterTodos();

            Assert.Single(lista);
            Assert.Equal("Café", lista[0].Nome);
        }

        [Fact]
        public void DeveObterProdutoPorNome()
        {
            using var con = SqliteTestHelper.CreateInMemoryDataBase();
            var repo = CreateRepository(con);

            var produto = new Produto { Nome = "leite", Preco = 0.99m };

            repo.Adicionar(produto);

            var prodPesquisa = repo.ObterPorNome("leite");

            Assert.NotNull(prodPesquisa);
            Assert.Equal("leite", produto.Nome);
        }

        [Fact]
        public void DeveRemoverProduto()
        {
            using var con = SqliteTestHelper.CreateInMemoryDataBase();
            var repo = CreateRepository(con);

            var produto = new Produto { Nome = "leite", Preco = 0.99m };

            repo.Adicionar(produto);

            var ProdBD = repo.ObterPorNome("leite");
            Assert.NotNull(ProdBD);
            bool removido = repo.Remover(ProdBD.Id);

            Assert.True(removido);
            Assert.Empty(repo.ObterTodos());
        }

        [Fact]
        public void DeveVerificarExistenciaPorNome()
        {
            using var con = SqliteTestHelper.CreateInMemoryDataBase();
            var repo = CreateRepository(con);

            var produto = new Produto { Nome = "leite", Preco = 0.99m };

            repo.Adicionar(produto);
            Assert.True(repo.ExistePorNome("leite"));
            Assert.False(repo.ExistePorNome("bolo"));

        }
    }
}
