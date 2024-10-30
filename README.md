# Gerenciador de Produtos

Um sistema de gerenciamento de produtos desenvolvido com ASP.NET Core, que permite realizar operações CRUD (Criar, Ler, Atualizar e Remover) em produtos. Este projeto utiliza Dapper para mapeamento de dados e injeção de dependência para maior modularidade.

## Índice
- [Funcionalidades](#funcionalidades)
- [Tecnologias Utilizadas](#tecnologias-utilizadas)
- [Estrutura do Projeto](#estrutura-do-projeto)
- [Configuração do Ambiente](#configuração-do-ambiente)
- [Como Executar o Projeto](#como-executar-o-projeto)
- [Endpoints](#endpoints)
- [Contribuição](#contribuição)
- [Licença](#licença)

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

```plaintext
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

