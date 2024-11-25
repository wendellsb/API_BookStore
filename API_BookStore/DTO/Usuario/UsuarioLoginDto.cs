﻿using System.ComponentModel.DataAnnotations;

namespace API_BookStore.DTO.Usuario
{
    public class UsuarioLoginDto
    {
        [Required(ErrorMessage = "O campo email é obrigatório!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo senha é obrigatório!")]
        public string Senha { get; set; }
    }
}
