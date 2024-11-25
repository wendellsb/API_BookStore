﻿using API_BookStore.Model;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace API_BookStore.Services.Senha
{
    public class SenhaService : ISenhaInterface
    {
        private readonly IConfiguration _config;
        public SenhaService(IConfiguration config)
        {
            _config = config;
        }

        public void CriarSenhaHash(string senha, out byte[] senhaHash, out byte[] senhaSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                senhaSalt = hmac.Key;
                senhaHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(senha));
            }
        }

        public bool VerificaSenhaHash(string senha, byte[] senhaHash, byte[] senhaSalt)
        {
            using (var hmac = new HMACSHA512(senhaSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(senha));
                return computedHash.SequenceEqual(senhaHash);
            }
        }

        public string CriarToken(UsuarioModel usuario)
        {
            // Informações dentro do Token
            List<Claim> claims = new List<Claim>()
            {
                new Claim("Nome", usuario.Nome),
                new Claim("Email", usuario.Email),
                new Claim(ClaimTypes.Role, usuario.Cargo.ToString())
            };

            // Key padrão no appsettings
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Token").Value));

            // Credenciais e tipo de criptografia
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                    claims: claims,
                    expires: DateTime.Now.AddHours(1),
                    signingCredentials: cred
                );

            // Transformando em string
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }
    }
}
