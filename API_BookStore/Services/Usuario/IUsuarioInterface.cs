using API_BookStore.DTO.Usuario;
using API_BookStore.Model;

namespace API_BookStore.Services.Usuario
{
    public interface IUsuarioInterface
    {
        Task<ResponseModel<UsuarioCriacaoDto>> Registrar(UsuarioCriacaoDto usuarioCriacaoDto);
        Task<ResponseModel<string>> Login(UsuarioLoginDto usuarioLogin);
    }
}
