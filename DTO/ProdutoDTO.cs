using System.Text.Json.Serialization;

namespace GerenciadorDeProdutos.DTO
{
    public class ProdutoDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public decimal Preco { get; set; }
        public string Descricao { get; set; } = string.Empty;
        public int Qtd { get; set; }

        public ProdutoDTO() { }
    }
}
