using API_BookStoreTest.ModelTest;
using API_BookStoreTest.ServicesTest;
using Microsoft.AspNetCore.Mvc;

namespace API_BookStoreTest.ControllersTest
{
    public class LivroControllerTest : ControllerBase
    {
        private readonly ILivroInterfaceTest _livroInterfaceTest;

        public LivroControllerTest(ILivroInterfaceTest livroInterfaceTest)
        {
            _livroInterfaceTest = livroInterfaceTest;
        }

        [HttpGet("ListarLivros")]
        public async Task<ActionResult<ResponseModelTest<List<LivroModelTest>>>> ListarLivros()
        {
            var livros = await _livroInterfaceTest.ListarLivros();
            return new OkObjectResult(new ResponseModelTest<List<LivroModelTest>> { Data = livros });
        }

        [HttpPost("CriarLivro")]
        public async Task<ActionResult<ResponseModelTest<List<LivroModelTest>>>> CriarLivro(LivroModelTest livroModelTest)
        {
            var livro = await _livroInterfaceTest.CriarLivro(livroModelTest);
            return new OkObjectResult(livro);
        }

        [HttpDelete("ExcluirLivro")]
        public async Task<ActionResult<ResponseModelTest<List<LivroModelTest>>>> ExcluirLivro(int idLivro)
        {
            var livro = await _livroInterfaceTest.ExcluirLivro(idLivro);
            return Ok(livro);
        }

        [HttpPost("BuscarLivrosTitulo")]
        public async Task<ActionResult<ResponseModelTest<LivroModelTest>>> BuscarLivrosTitulo(string titulo)
        {
            var livro = await _livroInterfaceTest.BuscarLivrosTitulo(titulo);
            return Ok(livro);
        }

        [HttpPost("CompraLivros")]
        public async Task<ActionResult<ResponseModelTest<LivroModelTest>>> CompraLivros(int idLivro, int quantidade)
        {
            var livro = await _livroInterfaceTest.CompraLivros(idLivro, quantidade);
            return Ok(livro);
        }

    }
}
