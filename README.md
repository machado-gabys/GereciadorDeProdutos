# Gerenciador de Produtos

Um sistema de gerenciamento de produtos desenvolvido com ASP.NET Core, que permite realizar operações CRUD (Criar, Ler, Atualizar e Remover) em produtos. Este projeto utiliza Dapper para mapeamento de dados e injeção de dependência para maior modularidade.

## Índice
- [Funcionalidades](#funcionalidades)
- [Tecnologias Utilizadas](#tecnologias-utilizadas)
- [Estrutura do Projeto](#estrutura-do-projeto)
- [Configuração do Ambiente](#configuração-do-ambiente)
- [Como Executar o Projeto](#como-executar-o-projeto)
- 
## Funcionalidades

- **Criar Produto**: Adicione um novo produto ao sistema.
- **Listar Produtos**: Visualize todos os produtos cadastrados.
- **Atualizar Produto**: Altere as informações de um produto existente.
- **Remover Produto**: Exclua um produto do sistema.

## Tecnologias Utilizadas

- **ASP.NET Core**
- **Dapper** para acesso e mapeamento de dados
- **Banco de Dados Relacional** (SQL Server ou compatível)
- **Dependency Injection**

## Coleção do postman está na pasta para executar

## Estrutura do Projeto

GerenciadorDeProdutos/
├── Controllers/
│   └── ProdutoController.cs         # Controlador para gerenciar os endpoints de Produto
├── DTO/
│   └── ProdutoDTO.cs                # DTO para transferência de dados do Produto
├── Model/
│   └── Produto.cs                   # Modelo de dados do Produto
├── Repository/
│   ├── Interface/
│   │   └── IProdutoRepository.cs    # Interface para o repositório de Produto
│   └── ProdutoRepository.cs         # Implementação do repositório de Produto
├── Service/
│   ├── Interface/
│   │   └── IProdutoService.cs       # Interface para o serviço de Produto
│   └── ProdutoService.cs            # Implementação do serviço de Produto
└── ConexãoDB/
    └── InicializadorDB.cs           # Classe para inicializar a conexão com o banco de dados

Clone o repositório:

bash
Copiar código
git clone <URL_DO_REPOSITORIO>

Navegue até o diretório do projeto:
bash
Copiar código
cd GerenciadorDeProdutos

Restaure as dependências:
bash
Copiar código
dotnet restore

Configuração do Banco de Dados:
Configure a conexão no arquivo InicializadorDB.cs, garantindo que o banco de dados e a tabela de produtos estão configurados.

Execute o projeto:
bash
Copiar código
dotnet run
Acesse a API:

A API estará disponível em https://localhost:5001/api/produto

