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

<h2 id="routes">📍 API Endpoints</h2>

<h3>Usuários</h3>
Autenticação e Autorização
Autenticação por JWT (JSON Web Token).
Apenas usuários autenticados podem acessar endpoints de CRUD de livros e autores.

<p>Papéis de usuários:</p>
Admin   | Id = 2: CRUD completo em todos os recursos.
Usuário | Id = 1: acesso apenas a consultas de todos os livros e autores, filtro por categoria de livros e busca livro pelo titulo.

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
<p>Login de Usuários</p>

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
