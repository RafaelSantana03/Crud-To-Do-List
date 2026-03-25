# 📝 To-Do List API

API REST para gerenciamento de tarefas, desenvolvida com **ASP.NET Core** e **Entity Framework Core**, seguindo boas práticas de desenvolvimento como Repository Pattern, DTOs e validações com Data Annotations.

---

## 🚀 Tecnologias Utilizadas

- [.NET 8](https://dotnet.microsoft.com/)
- [ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/)
- [Entity Framework Core](https://learn.microsoft.com/en-us/ef/core/)
- [SQL Server](https://www.microsoft.com/en-us/sql-server)
- [Swagger / OpenAPI](https://swagger.io/)

---

## 📋 Pré-requisitos

Antes de rodar o projeto, certifique-se de ter instalado:

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) ou [VS Code](https://code.visualstudio.com/)

---

## ⚙️ Como Rodar o Projeto

### 1. Clone o repositório

```bash
git clone https://github.com/RafaelSantana03/Crud_To_Do_List.git
cd Crud_To_Do_List
```

### 2. Configure a Connection String

No arquivo `appsettings.json`, ajuste a connection string de acordo com sua instância do SQL Server:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost\\SUA_INSTANCIA;Database=TodoListDb;Trusted_Connection=true;TrustServerCertificate=true;"
  }
}
```

### 3. Execute as Migrations

```bash
dotnet ef database update
```

> Isso irá criar o banco de dados e a tabela automaticamente.

### 4. Rode o projeto

```bash
dotnet run
```

### 5. Acesse o Swagger

```
https://localhost:{porta}/swagger
```

---

## 🛣️ Endpoints da API

Base URL: `/api/tarefas`

| Método | Rota | Descrição | Status de Sucesso |
|--------|------|-----------|-------------------|
| `GET` | `/api/tarefas` | Lista todas as tarefas | `200 OK` |
| `GET` | `/api/tarefas/{id}` | Busca uma tarefa por ID | `200 OK` |
| `POST` | `/api/tarefas` | Cria uma nova tarefa | `201 Created` |
| `PUT` | `/api/tarefas/{id}` | Atualiza uma tarefa existente | `204 No Content` |
| `DELETE` | `/api/tarefas/{id}` | Remove uma tarefa | `204 No Content` |

### Exemplo de body para POST e PUT

```json
{
  "titulo": "Estudar ASP.NET Core",
  "descricao": "Praticar Repository Pattern e DTOs",
  "concluida": false
}
```

### Regras de validação

| Campo | Regra |
|-------|-------|
| `Titulo` | Obrigatório, mínimo 3 e máximo 100 caracteres |
| `Descricao` | Opcional, máximo 500 caracteres |
| `Concluida` | Obrigatório, valor booleano |

---

## 🗂️ Estrutura de Pastas

```
Crud_To_Do_List/
├── Controllers/
│   └── TarefasController.cs   # Rotas e respostas HTTP
├── Data/
│   └── AppDbContext.cs        # Contexto do Entity Framework
├── DTOs/
│   ├── TarefaRequestDto.cs    # Dados recebidos pela API
│   └── TarefaResponseDto.cs   # Dados retornados pela API
├── Models/
│   └── Tarefa.cs              # Modelo da entidade no banco
├── Repositories/
│   ├── ITarefaRepository.cs   # Interface do repositório
│   └── TarefaRepository.cs    # Implementação do repositório
├── appsettings.json
└── Program.cs
```

---

## 📐 Padrões e Boas Práticas Aplicadas

- **Repository Pattern** — separação entre lógica de acesso a dados e regras de negócio
- **DTOs (Data Transfer Objects)** — controle do que entra e sai da API
- **Data Annotations** — validações declarativas no DTO de entrada
- **Injeção de Dependência** — uso nativo do ASP.NET Core
- **REST** — nomenclatura e status HTTP semânticos

---

## 👨‍💻 Autor

**Rafael Santana**  
[![GitHub](https://img.shields.io/badge/GitHub-RafaelSantana03-181717?style=flat&logo=github)](https://github.com/RafaelSantana03)
