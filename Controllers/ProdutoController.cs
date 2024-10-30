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
        public async Task<IActionResult> ObterPorId([FromRoute] int id)
        {
            var produto = await _produtoService.ObterPorId(id);
            if (produto == null)
                return NotFound("Produto não encontrado");
            return Ok(produto);
        }

        [HttpPut]
        public async Task<IActionResult> AtualizarProduto([FromBody] ProdutoDTO produto)
        {
            try
            {
                var produtoAtualizado = await _produtoService.AtualizarProduto(produto);
                return Ok(produtoAtualizado);
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Erro ao atualizar produto.", detalhes = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> ExcluirProduto([FromRoute] int id)
        {
            if (await _produtoService.ExcluirProduto(id))
                return NoContent();
            return NotFound("Produto não encontrado");
        }
    }
}
