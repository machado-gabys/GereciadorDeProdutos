using System.Text.Json.Serialization;

namespace GerenciadorDeProdutos.Model
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public decimal Preco { get; set; }
        public string Descricao { get; set; } = string.Empty;
        public int Qtd { get; set; }

        public Produto(int id, string nome, decimal preco, string descricao, int qtd)
        {
            Id = id;
            Nome = nome;
            Preco = preco;
            Descricao = descricao;
            Qtd = qtd;
        }
        public Produto() { }
    }
    
}
