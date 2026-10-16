using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace WebApi103.Context
{
    public class ApplicationDbContext : DbContext
    {
        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Rol> Roles { get; set; }
        public DbSet<Domain.Entities.Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

           
            modelBuilder.Entity<UsuarioDto>().HasData(
                new UsuarioDto
                {
                    PkUsuario = 1,
                    Nombre = "Miguel",
                    UserName = "Mike",
                    Password = "Password1",
                    FkRol = 1
                }



                );

            
            modelBuilder.Entity<Rol>().HasData(
                new Rol
                {
                    PkRol =1,
                    Nombre = "sa",
                    Estatus = true
                },
                new Rol
                {
                    PkRol = 2,
                    Nombre = "admin",
                    Estatus=false

                }
                );

            base.OnModelCreating(modelBuilder);

            
        }
    }
}