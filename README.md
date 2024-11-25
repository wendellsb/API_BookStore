<h1 align="center" style="font-weight: bold;"># API_BookStore 💻</h1>
 **************************************************************************************************************************************************************
<p align="center">
    <b>O projeto consiste no desenvolvimento de uma API RESTful em .NET 8.</b>
</p>
<h2>Funcionalidades</h3>
<p>Gerenciamento de Usuários como criação, autenticação e autorização utilizando o JWT. </p>
<p>Gerenciamento de CRUD (Create, Read, Update, Delete) de Livros e Autores.</p>
<p>Gerenciamento de busca de livros pelo titulo, filtro por categoria, estoque e compras.</p>
<p>Centralização de error com Middleware.</p>
<p>Testes unitários com xUnit utilizando Moq.</p>
**************************************************************************************************************************************************************
<br />

<h2>Tecnologias</h2>
<p>.Net 8</p>
<p>ASP.NET Core</p>
<p>Entity Framework Core</p>
<p>JWT - JSON Web Token</p>
<p>Swagger UI</p>
<p>xUnit</p>
<p>Moq</p>
<p>SQL Server</p>
**************************************************************************************************************************************************************
<br />

<h2>Boas Praticas</h2>
<p>Desing Patterns - Repository</p>
<p>SOLID</p>
<p>Middleware</p>
**************************************************************************************************************************************************************
<br />

<h2>Configuração do ambiente</h2>
<p>Para testar</p> 
<p>1 - Clonar o repositorio em uma pasta local. </p> 
<p>2 - Iniciar o Projeto. </p> 
<p>3 - Abrir o arquivo appsettings.json</p>
<p>4 - Editar a ConnectionStrings de acordo com a sua máquina. </p> 

```bash
,
  "ConnectionStrings": {
    "DefaultConnection": "server= COLOQUE_SEU_SERVIDOR_AQUI; database= Livraria; trusted_connection=true; trustservercertificate=true"
  },
```


<p>5 - Abrir o "Console de Gerenciador de Pacotes"</p> 

```bash
Executar: Update-Database
```




<br /><br />
**************************************************************************************************************************************************************
<h2>Autenticação e Autorização</h2>                                                                                                                       
<p>Autenticação por JWT (JSON Web Token).</p>
<p>Apenas usuários autenticados podem acessar endpoints de CRUD de livros e autores.</p>

<h2>Papéis de usuários:</h2>
<p>Admin   | Id = 2: CRUD completo em todos os recursos.</p>
<p>Usuário | Id = 1: acesso apenas a consultas de todos os livros e autores, filtro por categoria de livros e busca livro pelo titulo.</p>

**************************************************************************************************************************************************************

<h2 id="routes">📍 API Endpoints - Usuários</h2>
<h3>Cadastro de Usuário/Administrador</h3>

```bash
https://localhost:7196/api/Usuario/Registrar
```

**REQUEST**
```json
{
  "nome": "wendell",
  "email": "wendell@example.com",
  "senha": "wendell",
  "cargo": 2
}
```

**RESPONSE**
```json
{
  "dados": null,
  "mensagem": "Usuario criado com sucesso!",
  "status": true
}
```
<br /><br />
<h3>Login de Usuários</h3>

```bash
https://localhost:7196/api/Usuario/Login
```

**REQUEST**
```json
{
  "email": "string",
  "senha": "string"
}
```

**RESPONSE**
```json
{
  "dados": "eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTUxMiIsInR5cCI6IkpXVCJ9.eyJOb21lIjoiSnVsaWFueSBBbHZpbSIsIkVtYWlsIjoianVsaWFueUBnbWFpbC5jb20iLCJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL3dzLzIwMDgvMDYvaWRlbnRpdHkvY2xhaW1zL3JvbGUiOiJBZG1pbmlzdHJhZG9yIiwiZXhwIjoxNzMyNTUzMDgxfQ.wpPm7hHCoS3JIy1JJvashOm8vbscwcUL_GFaQQlUwUSQfPwS_gwpQeZG9WXvkgpG85ktGws_v4zDZRt8rgnbKA",
  "mensagem": "Usuário logado com sucesso!",
  "status": true
}
```
**************************************************************************************************************************************************************
<br /><br /><br />
<h2 id="routes">📍 API Endpoints - Autor</h2>
<h3>Listar Autores</h3>

```bash
https://localhost:7196/api/Autor/ListarAutores
```

**REQUEST**
```json
{
  Não precisa de um parametro para busca!
}
```

**RESPONSE**
```json
{
  "dados": [
    {
      "id": 1,
      "nome": "David Goggins",
      "dataNascimento": "1980-11-23T10:46:40.191",
      "pais": "EUA"
    },
    {
      "id": 2,
      "nome": "George R. R. Martin",
      "dataNascimento": "1948-11-23T11:37:20.144",
      "pais": "EUA"
    }
  ],
  "mensagem": "Todos os autores foram listados!",
  "status": true
}
```

<br /><br />
<h3>Cadastro de Autor</h3>

```bash
https://localhost:7196/api/Autor/CriarAutor
```

**REQUEST**
```json
{
  "nome": "David Goggins",
  "dataNascimento": "2024-11-25",
  "pais": "EUA"
}
```

**RESPONSE**
```json
{
  "dados": [    
    {
      "id": 1,
      "nome": "David Goggins",
      "dataNascimento": "2024-11-25T00:00:00",
      "pais": "EUA"
    }
  ],
  "mensagem": "Autor criado com sucesso!",
  "status": true
}
```

<br /><br />
<h3>Edição de Autor</h3>

```bash
https://localhost:7196/api/Autor/EditarAutor
```

**REQUEST**
```json
{
   "id": 1,
   "nome": "David Goggins",
   "dataNascimento": "2000-01-05",
   "pais": "Brasil"
}
```

**RESPONSE**
```json
{
  "dados": [    
    {
      "id": 1,
      "nome": "David Goggins",
      "dataNascimento": "2000-01-05T00:00:00",
      "pais": "Brasil"
    }
  ],
  "mensagem": "Autor criado com sucesso!",
  "status": true
}
```

<br /><br />
<h3>Exclusão de Autor</h3>

```bash
https://localhost:7196/api/Autor/ExcluirAutor{idAutor}
```

**REQUEST**
```json
{
   "id": 2
}
```

**RESPONSE**
```json
{
  "dados": [    
    {
      "id": 1,
      "nome": "David Goggins",
      "dataNascimento": "2000-01-05T00:00:00",
      "pais": "Brasil"
    }
  ],
  "mensagem": "Autor criado com sucesso!",
  "status": true
}
```
**************************************************************************************************************************************************************
<br /><br /><br />
<h2 id="routes">📍 API Endpoints - Livros</h2>
<h3>Listar Livros</h3>

```bash
https://localhost:7196/api/Livro/ListarLivros
```

**REQUEST**
```json
{
  Não precisa de um parametro para busca!
}
```

**RESPONSE**
```json
{
  "dados": [
    {
      "id": 1,
      "titulo": "NADA PODE ME FERIR",
      "autor": {
        "id": 1,
        "nome": "David Goggins",
        "dataNascimento": "2000-01-05T00:00:00",
        "pais": "Brasil"
      },
      "categoria": "Mentalidade",
      "dataPublicacao": "2013-04-11T13:04:28.93",
      "preco": 45,
      "quantidadeEstoque": 8
    }
  ],
  "mensagem": "Todos os autores foram listados!",
  "status": true
}
```
<br /><br />
<h3>Criar Livros</h3>

```bash
https://localhost:7196/api/Livro/CriarLivro
```

**REQUEST**
```json
{
 "titulo": "NADA PODE ME FERIR",
  "autor": {
    "id": 1
  },
  "categoria": "Mentalidade",
  "dataPublicacao": "2024-11-25",
  "preco": 50,
  "quantidadeEstoque": 10
}
```

**RESPONSE**
```json
{
  "dados": [
    {      
      "id": 1,
      "titulo": "NADA PODE ME FERIR",
      "autor": {
        "id": 1,
        "nome": "David Goggins",
        "dataNascimento": "2000-01-05T00:00:00",
        "pais": "Brasil"
      },
      "categoria": "Mentalidade",
      "dataPublicacao": "2024-11-25T16:41:11.756Z",
      "preco": 50,
      "quantidadeEstoque": 10
    }
  ],
  "mensagem": "",
  "status": true
}
```

<br /><br />
<h3>Editar Livros</h3>

```bash
https://localhost:7196/api/Livro/EditarLivro
```

**REQUEST**
```json
{
  "id": 1,
  "titulo": "NADA PODE ME FERIR",
  "autor": {
    "id": 1
  },
  "categoria": "Mindset",
  "dataPublicacao": "2024-11-25T16:56:38.957Z",
  "preco": 40,
  "quantidadeEstoque": 10
}
```

**RESPONSE**
```json
{
  "dados": [
    {
      "id": 1,
      "titulo": "NADA PODE ME FERIR",
      "autor": {
        "id": 1,
        "nome": "David Goggins",
        "dataNascimento": "2000-01-05T00:00:00",
        "pais": "Brasil"
      },
      "categoria": "Mindset",
      "dataPublicacao": "2024-11-25T16:56:38.957Z",
      "preco": 40,
      "quantidadeEstoque": 10
    }
  ],
  "mensagem": "",
  "status": true
}
```

<br /><br />
<h3>Exclusão de Livro</h3>

```bash
https://localhost:7196/api/Livro/ExcluirLivro{idLivro}
```

**REQUEST**
```json
{
   "id": 1
}
```

**RESPONSE**
```json
{
  "dados": [
   {
      "id": 2,
      "titulo": "As cronicas de Gelo e Fogo",
      "autor": {
        "id": 2,
        "nome": "George R. R. Martin",
        "dataNascimento": "1948-11-23T11:37:20.144",
        "pais": "EUA"
      },
      "categoria": "Fantasia",
      "dataPublicacao": "1948-11-23T11:37:20.144",
      "preco": 70,
      "quantidadeEstoque": 8
    }
  ],
  "mensagem": "Livro removido com sucesso!",
  "status": true
}
```


<br /><br />
<h3>Busca de Livro por título</h3>

```bash
https://localhost:7196/api/Livro/BuscarLivrosTitulo/{titulo}
```

**REQUEST**
```json
{
   "titulo": "As cronicas de Gelo e Fogo"
}
```

**RESPONSE**
```json
{
  "dados": {
    "id": 2,
    "titulo": "As cronicas de Gelo e Fogo",
    "autor": {
      "id": 2,
      "nome": "George R. R. Martin",
      "dataNascimento": "1948-11-23T11:37:20.144",
      "pais": "EUA"
    },
    "categoria": "Fantasia",
    "dataPublicacao": "1948-11-23T11:37:20.144",
    "preco": 70,
    "quantidadeEstoque": 8
  },
  "mensagem": "Livro localizado!",
  "status": true
}
```

<br /><br />
<h3>Busca de Livros por categoria</h3>

```bash
https://localhost:7196/api/Livro/BuscarLivroCategoria/{categoria}
```

**REQUEST**
```json
{
   "categoria": "Fantasia"
}
```

**RESPONSE**
```json
{
  "dados": [
    {
      "id": 2,
      "titulo": "As cronicas de Gelo e Fogo",
      "autor": {
        "id": 2,
        "nome": "George R. R. Martin",
        "dataNascimento": "1948-11-23T11:37:20.144",
        "pais": "EUA"
      },
      "categoria": "Fantasia",
      "dataPublicacao": "1948-11-23T11:37:20.144",
      "preco": 70,
      "quantidadeEstoque": 8
    },
    {
      "id": 3,
      "titulo": "A Tormenta das Espadas",
      "autor": {
        "id": 2,
        "nome": "George R. R. Martin",
        "dataNascimento": "1948-11-23T11:37:20.144",
        "pais": "EUA"
      },
      "categoria": "Fantasia",
      "dataPublicacao": "2000-08-08T13:19:55.852",
      "preco": 50,
      "quantidadeEstoque": 5
    }
  ],
  "mensagem": "Categoria encontrada!",
  "status": true
}
```

<br /><br />
<h3>Compra de Livros</h3>

```bash
https://localhost:7196/api/Livro/CompraLivros/{idLivro}{quantidade}
```

**REQUEST**
```json
{
   "id": "3",
   "quantidade": "4"
}
```

**RESPONSE**
```json
{
  "dados": [    
    {
      "id": 3,
      "titulo": "A Tormenta das Espadas",
      "autor": {
        "id": 2,
        "nome": "George R. R. Martin",
        "dataNascimento": "1948-11-23T11:37:20.144",
        "pais": "EUA"
      },
      "categoria": "Fantasia",
      "dataPublicacao": "2000-08-08T13:19:55.852",
      "preco": 50,
      "quantidadeEstoque": 1
    }
  ],
  "mensagem": "Livro comprado com sucesso!",
  "status": true
}
```
