using API_BookStore.Data;
using API_BookStore.DTO.Livro;
using API_BookStore.Model;
using Microsoft.EntityFrameworkCore;

namespace API_BookStore.Services.Livro
{
    public class LivroService : ILivroInterface
    {
        private readonly AppDbContext _context;
        public LivroService(AppDbContext context)
        {
            this._context = context;
        }
        public async Task<ResponseModel<List<LivroModel>>> ListarLivros()
        {
            ResponseModel<List<LivroModel>> resposta = new ResponseModel<List<LivroModel>>();
            try
            {
                var livros = await _context.Livros.Include(a => a.Autor).ToListAsync();
                resposta.Dados = livros;
                resposta.Mensagem = "Todos os livros foram listados!";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<LivroModel>>> CriarLivro(LivroCriacaoDto livroCriacaoDto)
        {
            ResponseModel<List<LivroModel>> resposta = new ResponseModel<List<LivroModel>>();
            try
            {
                var autor = await _context.Autores
                    .FirstOrDefaultAsync(autorBanco => autorBanco.Id == livroCriacaoDto.Autor.Id);

                if (autor == null)
                {
                    resposta.Mensagem = "Nenhum registro de autor localizado com este ID!";
                    return resposta;
                }
                var livro = new LivroModel()
                {
                    Titulo = livroCriacaoDto.Titulo,
                    Autor = autor,
                    Categoria = livroCriacaoDto.Categoria,
                    DataPublicacao = livroCriacaoDto.DataPublicacao,
                    Preco = livroCriacaoDto.Preco,
                    QuantidadeEstoque = livroCriacaoDto.QuantidadeEstoque
                };

                _context.Add(livro);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Livros.Include(a => a.Autor).ToListAsync();
                return resposta;

            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<LivroModel>>> EditarLivro(LivroEdicaoDto livrosEdicaoDto)
        {
            ResponseModel<List<LivroModel>> resposta = new ResponseModel<List<LivroModel>>();
            try
            {
                var autor = await _context.Autores
                    .FirstOrDefaultAsync(autorBanco => autorBanco.Id == livrosEdicaoDto.Autor.Id);
                if (autor == null)
                {
                    resposta.Mensagem = "Nenhum registro de Autor localizado com este ID!";
                    return resposta;
                }

                var livro = await _context.Livros
                   .Include(a => a.Autor)
                   .FirstOrDefaultAsync(livroBanco => livroBanco.Id == livrosEdicaoDto.Id);

                if (livro == null)
                {
                    resposta.Mensagem = "Nenhum registro de Livro localizado com este ID!";
                    return resposta;
                }

                livro.Titulo = livrosEdicaoDto.Titulo;
                livro.Autor = autor;
                livro.Categoria = livrosEdicaoDto.Categoria;
                livro.DataPublicacao = livrosEdicaoDto.DataPublicacao;
                livro.Preco = livrosEdicaoDto.Preco;
                livro.QuantidadeEstoque = livrosEdicaoDto.QuantidadeEstoque;

                _context.Update(livro);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Livros.ToListAsync();
                return resposta;

            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<LivroModel>>> ExcluirLivro(int idLivro)
        {
            ResponseModel<List<LivroModel>> resposta = new ResponseModel<List<LivroModel>>();
            try
            {
                var livro = await _context.Livros
                    .Include(a => a.Autor)
                    .FirstOrDefaultAsync(livroBanco => livroBanco.Id == idLivro);

                if (livro == null)
                {
                    resposta.Mensagem = "Nenhum livro localizado!";
                    return resposta;
                }

                _context.Remove(livro);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Livros.ToListAsync();
                resposta.Mensagem = "Livro removido com sucesso!";
                return resposta;

            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<LivroModel>> BuscarLivrosTitulo(string titulo)
        {
            ResponseModel<LivroModel> resposta = new ResponseModel<LivroModel>();
            try
            {
                var livro = await _context.Livros
                    .Include(a => a.Autor)
                    .FirstOrDefaultAsync(livroBanco => livroBanco.Titulo == titulo);
                if (livro == null)
                {
                    resposta.Mensagem = "Titulo não encontrado, digite corretamente!";
                    return resposta;
                }
                resposta.Dados = livro;
                resposta.Mensagem = "Livro localizado!";
                return resposta;


            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<LivroModel>>> BuscarLivroCategoria(string categoria)
        {
            ResponseModel<List<LivroModel>> resposta = new ResponseModel<List<LivroModel>>();
            try
            {
                var livro = await _context.Livros
                    .Include(a => a.Autor)
                    .Where(categoriaLivros => categoriaLivros.Categoria == categoria)
                    .ToListAsync();

                if (livro == null)
                {
                    resposta.Mensagem = "Categoria não encontrada!";
                    return resposta;
                }
                resposta.Dados = livro;
                resposta.Mensagem = "Categoria encontrada!";
                return resposta;

            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<LivroModel>>> CompraLivros(int idLivro, int quantidade)
        {
            ResponseModel<List<LivroModel>> resposta = new ResponseModel<List<LivroModel>>();
            try
            {
                var livro = await _context.Livros
                    .Include(a => a.Autor)
                    .FirstOrDefaultAsync(livroBanco => livroBanco.Id == idLivro);

                if (livro == null || livro.QuantidadeEstoque == 0)
                {
                    resposta.Mensagem = "Nenhum livro em estoque!";
                    return resposta;
                }

                livro.QuantidadeEstoque -= quantidade;
                _context.Update(livro);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Livros.ToListAsync();
                resposta.Mensagem = "Livro comprado com sucesso!";
                return resposta;

            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }


    }
}
