using API_BookStore.Model.Enum;

namespace API_BookStore.Model
{
    public class UsuarioModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public byte[] SenhaHash { get; set; }
        public byte[] SenhaSalt { get; set; }
        public DateTime DataCriacao { get; set; }
        public CargoEnum Cargo { get; set; }
    }
}
