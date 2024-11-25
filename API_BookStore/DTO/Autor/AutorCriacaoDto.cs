using System.ComponentModel.DataAnnotations;

namespace API_BookStore.DTO.Autor
{
    public class AutorCriacaoDto
    {

        [Required(ErrorMessage = "O campo nome é obrigatório!")]
        [MaxLength(100, ErrorMessage = "Máximo de 100 caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo data de nascimento é obrigatório!")]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "O campo país de origem é obrigatório!")]
        public string Pais { get; set; }
    }
}
