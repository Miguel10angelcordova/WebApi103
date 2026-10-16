using Domain.Entities;
using WebApi103.dto;
using WebApi103.Helpers;

namespace WebApi103.Services.Interfaces
{
    public interface IUsuarioservice
    {
        Task<Response<List<usuarioDto>>> ObtenerUsuario();

        Task<Response<usuarioDto>> ById(int id);

        Task<Response<usuarioDto>> Create(usuarioDto request);
        Task Create(UsuarioDto usuarioDtoParaServicio);

        Task<Response<usuarioDto>> Update(int id, usuarioDto request);
        Task<Response<bool>> Delete(int id);
    }
}