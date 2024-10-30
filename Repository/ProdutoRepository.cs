using System.Data;
using Dapper;
using GerenciadorDeProdutos.Model;
using GerenciadorDeProdutos.Repository.Interface;

namespace GerenciadorDeProdutos.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly IDbConnection _connection;

        public ProdutoRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<Produto> CriarProduto(Produto produto)
        {
            string query = @"INSERT INTO produto (nome, preco, descricao, qtd) 
                             VALUES (@Nome, @Preco, @Descricao, @Qtd);
                             SELECT LAST_INSERT_ROWID();";
            produto.Id = await _connection.QuerySingleAsync<int>(query, produto);
            return produto;
        }

        public async Task<IEnumerable<Produto>> ObterTodos()
        {
            string query = "SELECT * FROM produto;";
            return await _connection.QueryAsync<Produto>(query);
        }

        public async Task<Produto> ObterPorId(int id)
        {
            string query = "SELECT * FROM produto WHERE id = @Id;";
            return await _connection.QueryFirstOrDefaultAsync<Produto>(query, new { Id = id });
        }

        public async Task<bool> AtualizarProduto(Produto produto)
        {
            string query = @"UPDATE produto SET nome = @Nome, preco = @Preco, descricao = @Descricao, qtd = @Qtd
                             WHERE id = @Id;";
            int linhasAfetadas = await _connection.ExecuteAsync(query, produto);
            return linhasAfetadas > 0;
        }

        public async Task<bool> ExcluirProduto(int id)
        {
            string query = "DELETE FROM produto WHERE id = @Id;";
            int linhasAfetadas = await _connection.ExecuteAsync(query, new { Id = id });
            return linhasAfetadas > 0;
        }
    }
}
