using API_BookStore.Model;
using API_BookStoreTest.Model;
using API_BookStoreTest.ModelTest;
using API_BookStoreTest.ServicesTest;
using Microsoft.AspNetCore.Mvc;

namespace API_BookStoreTest.ControllersTest
{
    public class AutorControllerTest : ControllerBase
    {
        private readonly IAutorInterfaceTest _autorInterfaceTest;

        public AutorControllerTest(IAutorInterfaceTest autorInterfaceTest)
        {
            _autorInterfaceTest = autorInterfaceTest;
        }

        [HttpGet("ListarAutores")]
        public async Task<ActionResult<ResponseModelTest<List<AutorModelTest>>>> ListarAutores()
        {
            var autores = await _autorInterfaceTest.ListarAutores();
            return new OkObjectResult(new ResponseModelTest<List<AutorModelTest>> { Data = autores });
        }

        [HttpPost("CriarAutor")]
        public async Task<ActionResult<ResponseModelTest<List<AutorModelTest>>>> CriarAutor(AutorModelTest autorModelTest)
        {
            var autor = await _autorInterfaceTest.CriarAutor(autorModelTest);
            return new OkObjectResult(autor);
        }

        [HttpDelete("ExcluirAutor")]
        public async Task<ActionResult<ResponseModelTest<List<AutorModel>>>> ExcluirAutor(int idAutor)
        {
            var autor = await _autorInterfaceTest.ExcluirAutor(idAutor);
            return Ok(autor);
        }
    }
}
