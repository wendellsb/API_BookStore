namespace API_BookStoreTest.ModelTest
{
    public class ResponseModelTest<T>
    {
        public T Data { get; set; }
        public string Mensagem { get; set; }
        public bool Sucesso { get; set; } = true;
    }
}
