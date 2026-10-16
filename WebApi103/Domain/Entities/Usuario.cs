using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Usuario
    {
        [Key]
        public int PkUsuario { get; set; }

        public string Nombre { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public int FkRol { get; set; }
        [ForeignKey("FkRol")]
        public Rol Roles { get; set; }
    }
}
