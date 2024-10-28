using GerenciadorDeProdutos.Model;

namespace GerenciadorDeProdutos.Repository.Interface
{
    public interface IProdutoRepository
    {
        Task<Produto> CriarProduto(Produto produto);
        Task<IEnumerable<Produto>> ObterTodos();
        Task<Produto> ObterPorId(int id);
        Task<bool> AtualizarProduto(Produto produto);
        Task<bool> ExcluirProduto(int id);
    }
}
