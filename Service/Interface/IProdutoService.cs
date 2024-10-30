using GerenciadorDeProdutos.DTO;

namespace GerenciadorDeProdutos.Service.Interface
{
    public interface IProdutoService
    {
        Task<ProdutoDTO> CriarProduto(ProdutoDTO produto);
        Task<IEnumerable<ProdutoDTO>> ObterTodos();
        Task<ProdutoDTO> ObterPorId(int id);
        Task<ProdutoDTO> AtualizarProduto(ProdutoDTO produto);
        Task<bool> ExcluirProduto(int id);
    }
}
