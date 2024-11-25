using API_BookStoreTest.ModelTest;

namespace API_BookStoreTest.ServicesTest
{
    public interface ILivroInterfaceTest
    {
        Task<List<LivroModelTest>> ListarLivros();
        Task<ResponseModelTest<List<LivroModelTest>>> CriarLivro(LivroModelTest livroModelTest);
        Task<ResponseModelTest<List<LivroModelTest>>> ExcluirLivro(int idLivro);
        Task<ResponseModelTest<LivroModelTest>> BuscarLivrosTitulo(string titulo);
        Task<ResponseModelTest<LivroModelTest>> CompraLivros(int idLivro, int quantidade);
    }
}
