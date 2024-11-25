using API_BookStoreTest.Model;
using API_BookStoreTest.ModelTest;

namespace API_BookStoreTest.ServicesTest
{
    public interface IAutorInterfaceTest
    {
        Task<List<AutorModelTest>> ListarAutores();
        Task<ResponseModelTest<List<AutorModelTest>>> CriarAutor(AutorModelTest autorModelTest);
        Task<ResponseModelTest<List<AutorModelTest>>> ExcluirAutor(int idAutor);
    }
}
