using API_BookStore.Model.Enum;
using System.ComponentModel.DataAnnotations;

namespace API_BookStore.DTO.Usuario
{
    public class UsuarioCriacaoDto
    {
        [Required(ErrorMessage = "O campo usuário é obrigatório!")]
        [MaxLength(100, ErrorMessage = "Máximo de 100 caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo email é obrigatório"), EmailAddress(ErrorMessage = "Email inválido!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo senha é obrigatório!")]
        public string Senha { get; set; }

        [Required(ErrorMessage = "O campo cargo é obrigatório!")]
        public CargoEnum Cargo { get; set; }
    }
}
