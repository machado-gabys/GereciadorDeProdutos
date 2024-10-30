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
            ValidaDTO(dto);
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

        public async Task<ProdutoDTO> AtualizarProduto(ProdutoDTO dto)
        {
            var produtoAux = await ObterPorId(dto.Id);
            if (produtoAux == null)
            {
                throw new KeyNotFoundException("Produto não encontrado para o ID especificado.");
            }
            ValidaDTO(dto);
            var produto = new Produto
            {
                Id = dto.Id,
                Nome = dto.Nome,
                Descricao = dto.Descricao,
                Preco = dto.Preco,
                Qtd = dto.Qtd
            };

            await _produtoRepository.AtualizarProduto(produto);
            return await ObterPorId(dto.Id);
        }

        public async Task<bool> ExcluirProduto(int id)
        {
            return await _produtoRepository.ExcluirProduto(id);
        }

        private ProdutoDTO ConverterParaDTO(Produto produto)
        {
            return new ProdutoDTO
            {
                Id = produto.Id,
                Nome = produto.Nome,
                Preco = produto.Preco,
                Descricao = produto.Descricao,
                Qtd = produto.Qtd
            };
        }
        private void ValidaDTO(ProdutoDTO dto)
        {
            if (string.IsNullOrEmpty(dto.Nome))
            {
                throw new Exception("Nome inválido.");
            }
            if (dto.Preco < 0)
            {
                throw new Exception("Preço inválido.");
            }
            if (string.IsNullOrEmpty(dto.Descricao))
            {
                throw new Exception("Descrição inválida.");
            }
            if (dto.Qtd < 0)
            {
                throw new Exception("Quantidade inválida.");
            }
        }
    }
}
