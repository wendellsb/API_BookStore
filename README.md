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


<h3>Usuário</h3>
Autenticação e Autorização
Autenticação por JWT (JSON Web Token).
Apenas usuários autenticados podem acessar endpoints de CRUD de livros e autores.

<p>Papéis de usuário:</p>
Admin - Id = 2: CRUD completo em todos os recursos.
Usuário comum - Id = 1: acesso apenas a consultas de todos os livros e autores, filtro por categoria de livros e busca livro pelo titulo.

Cadastro de Usuários
Dados do usuário:
Id (int)
Nome (string)
Email (string)
Senha (hash - string)
Data de Criação (datetime)

Login de Usuários
Dados do login:
Email (string)
Senha (hash - string)
