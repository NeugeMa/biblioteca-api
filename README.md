# Biblioteca API

API REST desenvolvida em **ASP.NET Core (.NET 10)** para gerenciamento do acervo de livros de uma biblioteca. Permite cadastrar, consultar, atualizar e remover livros através de operações CRUD, com persistência simulada em memória.

## Integrantes do Grupo

| Nome Completo | RM |
|---|---|
| Abner de Paiva Barbosa | RM558468 |
| Beatriz Vieira de Novais | RM554746 |
| Eduardo Dallabella Lima | RM556803 |
| Heloísa Real | RM554535 |
| Mariana Neugebauer Dourado | RM550494 |

## Tecnologias Utilizadas

- ASP.NET Core Web API (.NET 10)
- Swashbuckle (Swagger/OpenAPI)
- Persistência em memória (Singleton)

## Estrutura do Projeto

```
biblioteca-api/
├── Controllers/    -> Endpoints da API (LivrosController)
├── Models/         -> Entidade de domínio (Livro)
├── DTOs/           -> Objetos de transferência de dados (LivroRequestDto)
├── Data/           -> Contexto de dados em memória (AppDbContext)
└── Program.cs      -> Configuração da aplicação e injeção de dependências
```

## Entidade: Livro

| Campo | Tipo | Descrição |
|---|---|---|
| Id | int | Identificador único, gerado automaticamente |
| Titulo | string | Título do livro |
| Autor | string | Autor do livro |
| Genero | string | Gênero literário |
| Descricao | string | Descrição/sinopse do livro |
| AnoPublicacao | int | Ano de publicação |
| Disponivel | bool | Indica se o livro está disponível para empréstimo |

## Como Executar

### Pré-requisitos
- [.NET 10 SDK](https://dotnet.microsoft.com/download)

### Passos

1. Clone o repositório:
   ```bash
   git clone https://github.com/NeugeMa/biblioteca-api.git
   cd biblioteca-api/biblioteca-api
   ```

2. Restaure as dependências e execute:
   ```bash
   dotnet restore
   dotnet run
   ```

3. Acesse a interface do Swagger no navegador:
   ```
   http://localhost:5072/
   ```

   O Swagger UI é aberto diretamente na raiz da aplicação, com todos os endpoints disponíveis para teste.

## Endpoints Disponíveis

| Método | Rota | Descrição | Status de Sucesso | Status de Erro |
|---|---|---|---|---|
| GET | `/api/v1/livros` | Lista todos os livros | 200 OK | - |
| GET | `/api/v1/livros/{id}` | Busca um livro por Id | 200 OK | 404 Not Found |
| POST | `/api/v1/livros` | Cria um novo livro | 201 Created | - |
| PUT | `/api/v1/livros/{id}` | Atualiza um livro existente | 204 No Content | 404 Not Found |
| DELETE | `/api/v1/livros/{id}` | Remove um livro | 204 No Content | 404 Not Found |

## Exemplos de Chamadas

### Criar um livro (POST /api/v1/livros)

Requisição:
```json
{
  "titulo": "O Acordo (Nova Edição)",
  "autor": "Ellen Kennedy",
  "genero": "Romance",
  "descricao": "Hannah Wells finalmente encontrou alguém que a interessasse. Mas, embora seja autoconfiante em vários outros aspectos da vida, carrega nas costas uma bagagem e tanto quando o assunto é sexo e sedução. Não vai ter jeito: ela vai ter que sair da zona de conforto… Mesmo que isso signifique dar aulas particulares para o infantil, irritante e convencido capitão do time de hóquei, em troca de um encontro de mentirinha.",
  "anoPublicacao": 2026,
  "disponivel": true
}
```

Resposta (201 Created):
```json
{
  "titulo": "O Acordo (Nova Edição)",
  "autor": "Ellen Kennedy",
  "genero": "Romance",
  "descricao": "Hannah Wells finalmente encontrou alguém que a interessasse. Mas, embora seja autoconfiante em vários outros aspectos da vida, carrega nas costas uma bagagem e tanto quando o assunto é sexo e sedução. Não vai ter jeito: ela vai ter que sair da zona de conforto… Mesmo que isso signifique dar aulas particulares para o infantil, irritante e convencido capitão do time de hóquei, em troca de um encontro de mentirinha.",
  "anoPublicacao": 2026,
  "disponivel": true
}
```

### Atualizar um livro (PUT /api/v1/livros/1)

Requisição:
```json
{
  "titulo": "O Acordo (Nova Edição)",
  "autor": "Ellen Kennedy",
  "genero": "Romance",
  "descricao": "Hannah Wells finalmente encontrou alguém que a interessasse. Mas, embora seja autoconfiante em vários outros aspectos da vida, carrega nas costas uma bagagem e tanto quando o assunto é sexo e sedução. Não vai ter jeito: ela vai ter que sair da zona de conforto… Mesmo que isso signifique dar aulas particulares para o infantil, irritante e convencido capitão do time de hóquei, em troca de um encontro de mentirinha.",
  "anoPublicacao": 2026,
  "disponivel": true
}
```

Resposta: `204 No Content`

### Buscar livro inexistente (GET /api/v1/livros/999)

Resposta: `404 Not Found`

## Testes Realizados no Swagger

### 1. GET /api/v1/livros — lista vazia
![Lista vazia](assets/01-get-lista-vazia.png)

### 2. POST /api/v1/livros — criar livro
![Criar livro](assets/02-post-criar-livro.png)

### 3. GET /api/v1/livros — listar após criação
![Listar livros](assets/03-get-lista-com-livros.png)

### 4. GET /api/v1/livros/{id} — buscar por id existente
![Buscar por id](assets/04-get-por-id.png)

### 5. GET /api/v1/livros/{id} — buscar por id inexistente
![Id inexistente](assets/05-get-id-inexistente-404.png)

### 6. PUT /api/v1/livros/{id} — atualizar livro
![Atualizar livro](assets/06-put-atualizar.png)

### 7. PUT /api/v1/livros/{id} — atualizar id inexistente
![Atualizar id inexistente](assets/07-put-id-inexistente-404.png)

### 8. DELETE /api/v1/livros/{id} — remover livro
![Remover livro](assets/08-delete-remover.png)

### 9. DELETE /api/v1/livros/{id} — remover id inexistente
![Remover id inexistente](assets/09-delete-id-inexistente-404.png)

### 10. GET /api/v1/livros — lista final
![Lista final](assets/10-get-lista-final.png)
