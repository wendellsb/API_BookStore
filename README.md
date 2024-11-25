<h1 align="center" style="font-weight: bold;"># API_BookStore 💻</h1>
 
<p align="center">
    <b>O projeto consiste no desenvolvimento de uma API RESTful em .NET 8.</b>
</p>
<h2>Funcionalidades</h3>
<p>Gerenciamento de Usuários como criação, autenticação e autorização utilizando o JWT. </p>
<p>Gerenciamento de CRUD (Create, Read, Update, Delete) de Livros e Autores.</p>
<p>Gerenciamento de busca de livros pelo titulo, filtro por categoria, estoque e compras.</p>
<p>Centralização de error com Middleware.</p>
<p>Testes unitários com xUnit utilizando Moq.</p>

<br /><br />
<h2>Autenticação e Autorização</h2>
<p>Autenticação por JWT (JSON Web Token).</p>
<p>Apenas usuários autenticados podem acessar endpoints de CRUD de livros e autores.</p>

<h2>Papéis de usuários:</h2>
<p>Admin   | Id = 2: CRUD completo em todos os recursos.</p>
<p>Usuário | Id = 1: acesso apenas a consultas de todos os livros e autores, filtro por categoria de livros e busca livro pelo titulo.</p>
<br />

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
  "dataNascimento": "1980-11-23",
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
https://localhost:7196/api/Livro/CriarLivros
```

**REQUEST**
```json
{
 "titulo": "NADA PODE ME FERIR",
  "autor": {
    "id": 1
  },
  "categoria": "Mentalidade",
  "dataPublicacao": "2013-04-11",
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
    }
  ],
  "mensagem": "",
  "status": true
}
```
