using Dapper;
using Microsoft.Data.Sqlite;
using System.Data;

namespace GerenciadorDeProdutos.ConexãoDB
{
    public class InicializadorDB
    {
        private readonly IDbConnection _connection;

        public InicializadorDB()
        {
            _connection = new SqliteConnection("DataSource=:memory:");
            _connection.Open();
            Initialize();
        }

        public IDbConnection GetConnection() => _connection;

        private void Initialize()
        {
            var createTableQuery = @"
                CREATE TABLE IF NOT EXISTS Produto (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Nome VARCHAR(255) NOT NULL,
                    Preco REAL NOT NULL,
                    Descricao VARCHAR(255) NOT NULL,
                    Qtd INT NOT NULL                    
                )";
            _connection.Execute(createTableQuery);

            var insertDataQuery = @"
                INSERT INTO Produto (Nome, Preco, Descricao, Qtd) VALUES 
                ('Headset', 100.0, 'Headset Razer KRAKEN', 20), 
                ('Mouse', 50.0, 'Mouse Microsoft', 50), 
                ('Monitor', 500.0, 'Monitor Fox Racer', 10),
                ('Mousepad', 80.00, 'Mousepad Razer', 60)";
            _connection.Execute(insertDataQuery);

        }
    }
}
