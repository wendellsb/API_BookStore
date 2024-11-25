using API_BookStore.DTO.Livro;
using API_BookStore.Model;
using API_BookStore.Services.Livro;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API_BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivroController : ControllerBase
    {
        private readonly ILivroInterface _livroInterface;
        public LivroController(ILivroInterface livroInterface)
        {
            _livroInterface = livroInterface;
        }

        [HttpGet("ListarLivros")]
        public async Task<ActionResult<ResponseModel<List<AutorModel>>>> ListarLivros()
        {
            var livros = await _livroInterface.ListarLivros();
            return Ok(livros);
        }

        [Authorize(Roles = "Administrador")]
        [HttpPost("CriarLivro")]
        public async Task<ActionResult<ResponseModel<List<LivroModel>>>> CriarLivro(LivroCriacaoDto livroCriacaoDto)
        {
            var livro = await _livroInterface.CriarLivro(livroCriacaoDto);
            return Ok(livro);
        }

        [Authorize(Roles = "Administrador")]
        [HttpPost("EditarLivro")]
        public async Task<ActionResult<ResponseModel<List<LivroModel>>>> EditarLivro(LivroEdicaoDto livroEdicaoDto)
        {
            var livro = await _livroInterface.EditarLivro(livroEdicaoDto);
            return Ok(livro);
        }

        [Authorize(Roles = "Administrador")]
        [HttpDelete("ExcluirLivro")]
        public async Task<ActionResult<ResponseModel<List<LivroModel>>>> ExcluirLivro(int idLivro)
        {
            var livro = await _livroInterface.ExcluirLivro(idLivro);
            return Ok(livro);
        }

        [HttpGet("BuscarLivrosTitulo/{titulo}")]
        public async Task<ActionResult<ResponseModel<LivroModel>>> BuscarLivrosTitulo(string titulo)
        {
            var livro = await _livroInterface.BuscarLivrosTitulo(titulo);
            return Ok(livro);
        }

        [HttpGet("BuscarLivroCategoria/{categoria}")]
        public async Task<ActionResult<ResponseModel<LivroModel>>> BuscarLivroCategoria(string categoria)
        {
            var livro = await _livroInterface.BuscarLivroCategoria(categoria);
            return Ok(livro);
        }

        [HttpGet("CompraLivros")]
        public async Task<ActionResult<ResponseModel<LivroModel>>> CompraLivros(int idLivro, int quantidade)
        {
            var livro = await _livroInterface.CompraLivros(idLivro, quantidade);
            return Ok(livro);
        }
    }
}
