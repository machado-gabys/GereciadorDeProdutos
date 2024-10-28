using GerenciadorDeProdutos.DTO;
using GerenciadorDeProdutos.Model;
using GerenciadorDeProdutos.Repository.Interface;
using GerenciadorDeProdutos.Service.Interface;

namespace GerenciadorDeProdutos.Service
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoService(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task<ProdutoDTO> CriarProduto(ProdutoDTO dto)
        {
            var produto = new Produto
            {
                Nome = dto.Nome,
                Descricao = dto.Descricao,
                Preco = dto.Preco,
                Qtd = dto.Qtd,
            };

            var novoProduto = await _produtoRepository.CriarProduto(produto);
            return ConverterParaDTO(novoProduto);
        }

        public async Task<IEnumerable<ProdutoDTO>> ObterTodos()
        {
            var produtos = await _produtoRepository.ObterTodos();
            return produtos.Select(ConverterParaDTO);
        }

        public async Task<ProdutoDTO> ObterPorId(int id)
        {
            var produto = await _produtoRepository.ObterPorId(id);
            return produto == null ? null : ConverterParaDTO(produto);
        }

        public async Task<bool> AtualizarProduto(int id, ProdutoDTO dto)
        {
            var produto = new Produto
            {
                Id = id,
                Nome = dto.Nome,
                Descricao = dto.Descricao,
                Preco = dto.Preco,
                Qtd = dto.Qtd
            };

            return await _produtoRepository.AtualizarProduto(produto);
        }

        public async Task<bool> ExcluirProduto(int id)
        {
            return await _produtoRepository.ExcluirProduto(id);
        }

        private ProdutoDTO ConverterParaDTO(Produto produto)
        {
            return new ProdutoDTO
            {
                Nome = produto.Nome,
                Preco = produto.Preco,
                Descricao = produto.Descricao,
                Qtd = produto.Qtd,
            };
        }
    }
}
