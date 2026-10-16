using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using WebApi103.Context;
using WebApi103.dto;
using WebApi103.Helpers;
using WebApi103.Services.Interfaces;

namespace WebApi103.Services.Services
{
    public class Usuarioservice : IUsuarioservice
    {
        private readonly ApplicationDbContext _context;

        public Usuarioservice(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Response<List<usuarioDto>>> ObtenerUsuario()
        {
            try
            {
                var listaUsuarios = await _context.Usuarios
                    .Include(x => x.Roles)
                    .Select(x => new usuarioDto
                    {
                        PkUsuario = x.PkUsuario,
                        Nombre = x.Nombre,
                        UserName = x.UserName,
                        Password = x.Password,
                        FkRol = x.FkRol,
                        NombreRol = x.Roles != null ? x.Roles.Nombre : string.Empty
                    })
                    .ToListAsync();

                return new Response<List<usuarioDto>>(listaUsuarios);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al obtener los usuarios: " + ex.Message);
            }
        }

        public async Task<Response<usuarioDto>> ById(int id)
        {
            try
            {
                var usuario = await _context.Usuarios
                    .Include(x => x.Roles)
                    .Where(x => x.PkUsuario == id)
                    .Select(x => new usuarioDto
                    {
                        PkUsuario = x.PkUsuario,
                        Nombre = x.Nombre,
                        UserName = x.UserName,
                        Password = x.Password,
                        FkRol = x.FkRol,
                        NombreRol = x.Roles != null ? x.Roles.Nombre : string.Empty
                    })
                    .FirstOrDefaultAsync();

                if (usuario == null)
                {
                    return new Response<usuarioDto>(null, "Usuario no encontrado");
                }

                return new Response<usuarioDto>(usuario);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al buscar el usuario: " + ex.Message);
            }
        }

        public async Task<Response<usuarioDto>> Create(usuarioDto request)
        {
            try
            {
                Domain.Entities.Usuario newUsers = new Domain.Entities.Usuario()
                {
                    Nombre = request.Nombre,
                    UserName = request.UserName,
                    Password = request.Password,
                    FkRol = request.FkRol
                };

                await _context.Usuarios.AddAsync(newUsers);
                await _context.SaveChangesAsync();

                request.PkUsuario = newUsers.PkUsuario;
                return new Response<usuarioDto>(request, "Se creó correctamente :D");
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedió un error: " + ex.Message);
            }
        }

        public Task Create(UsuarioDto usuarioDtoParaServicio)
        {
            throw new NotImplementedException();
        }
    

    public async Task<Response<usuarioDto>> Update(int id, usuarioDto request)
        {
            try
            {
                var usuarioExistente = await _context.Usuarios.FindAsync(id);
                if (usuarioExistente == null)
                {
                    return new Response<usuarioDto>(null, "Usuario no encontrado para actualizar");
                }

                usuarioExistente.Nombre = request.Nombre;
                usuarioExistente.UserName = request.UserName;
                usuarioExistente.Password = request.Password;
                usuarioExistente.FkRol = request.FkRol;

                _context.Usuarios.Update(usuarioExistente);
                await _context.SaveChangesAsync();

                request.PkUsuario = id;
                return new Response<usuarioDto>(request, "Usuario actualizado correctamente");
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al actualizar: " + ex.Message);
            }
        }

        public async Task<Response<bool>> Delete(int id)
        {
            try
            {
                var usuario = await _context.Usuarios.FindAsync(id);
                if (usuario == null)
                {
                    return new Response<bool>(false, "Usuario no encontrado para eliminar");
                }

                _context.Usuarios.Remove(usuario);
                await _context.SaveChangesAsync();

                return new Response<bool>(true, "Usuario eliminado correctamente");
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al eliminar: " + ex.Message);
            }

            } 
        }
    }
