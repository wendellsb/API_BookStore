using API_BookStore.Data;
using API_BookStore.DTO.Usuario;
using API_BookStore.Model;
using API_BookStore.Services.Senha;
using Microsoft.EntityFrameworkCore;

namespace API_BookStore.Services.Usuario
{
    public class UsuarioService : IUsuarioInterface
    {
        private readonly AppDbContext _context;
        private readonly ISenhaInterface _senhaInterface;

        public UsuarioService(AppDbContext context, ISenhaInterface senhaInterface)
        {
            _context = context;
            _senhaInterface = senhaInterface;
        }

        public async Task<ResponseModel<UsuarioCriacaoDto>> Registrar(UsuarioCriacaoDto usuarioCriacao)
        {
            ResponseModel<UsuarioCriacaoDto> resposta = new ResponseModel<UsuarioCriacaoDto>();
            try
            {
                if (!VerificaExistencia(usuarioCriacao))
                {
                    resposta.Dados = null;
                    resposta.Status = false;
                    resposta.Mensagem = "Email/Usuario já está cadastrado!";
                    return resposta;
                }

                // criando a senha Hash
                _senhaInterface.CriarSenhaHash(usuarioCriacao.Senha, out byte[] senhaHash, out byte[] senhaSalt);

                UsuarioModel usuario = new UsuarioModel()
                {
                    Nome = usuarioCriacao.Nome,
                    Email = usuarioCriacao.Email,
                    SenhaHash = senhaHash,
                    SenhaSalt = senhaSalt,
                    DataCriacao = DateTime.Now,
                    Cargo = usuarioCriacao.Cargo
                };

                _context.Add(usuario);
                await _context.SaveChangesAsync();
                resposta.Mensagem = "Usuario criado com sucesso!";
            }
            catch (Exception ex)
            {
                resposta.Dados = null;
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
            }
            return resposta;
        }

        public async Task<ResponseModel<string>> Login(UsuarioLoginDto usuarioLogin)
        {
            ResponseModel<string> resposta = new ResponseModel<string>();
            try
            {
                var usuario = await _context.Usuarios.FirstOrDefaultAsync(usuarioBanco => usuarioBanco.Email == usuarioLogin.Email);

                if (usuario == null)
                {
                    resposta.Mensagem = "Credenciais inválidas!";
                    resposta.Status = false;
                    return resposta;
                }

                if (!_senhaInterface.VerificaSenhaHash(usuarioLogin.Senha, usuario.SenhaHash, usuario.SenhaSalt))
                {
                    resposta.Mensagem = "Credenciais inválidas!";
                    resposta.Status = false;
                    return resposta;
                }

                var token = _senhaInterface.CriarToken(usuario);

                resposta.Dados = token;
                resposta.Mensagem = "Usuário logado com sucesso!";

            }
            catch (Exception ex)
            {
                resposta.Dados = null;
                resposta.Mensagem = ex.Message;
                resposta.Status = false;

            }

            return resposta;
        }

        public bool VerificaExistencia(UsuarioCriacaoDto usuarioCriacaoDto)
        {
            var usuario = _context.Usuarios
                .FirstOrDefault(userBanco => userBanco.Email == usuarioCriacaoDto.Email || userBanco.Nome == usuarioCriacaoDto.Nome);

            if (usuario != null)
            {
                return false;
            }

            return true;
        }
    }
}
