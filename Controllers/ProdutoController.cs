using GerenciadorDeProdutos.DTO;
using GerenciadorDeProdutos.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorDeProdutos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService _produtoService;

        public ProdutoController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        [HttpPost]
        public async Task<IActionResult> CriarProduto([FromBody] ProdutoDTO produto)
        {
            try
            {
                var produtoCriado = await _produtoService.CriarProduto(produto);
                return CreatedAtAction(nameof(ObterPorId), new { id = produtoCriado.Id }, produtoCriado);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao criar o produto: {ex.Message}");
            }
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodos()
        {
            return Ok(await _produtoService.ObterTodos());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterPorId(int id)
        {
            var produto = await _produtoService.ObterPorId(id);
            if (produto == null)
                return NotFound("Produto não encontrado");
            return Ok(produto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarProduto(int id, [FromBody] ProdutoDTO produto)
        {
            if (await _produtoService.AtualizarProduto(id, produto))
                return NoContent();
            return NotFound("Produto não encontrado");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> ExcluirProduto(int id)
        {
            if (await _produtoService.ExcluirProduto(id))
                return NoContent();
            return NotFound("Produto não encontrado");
        }
    }
}
