
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Domain.Entities
{
    public class UsuarioDto
    {
        [Key]
        [JsonIgnore]
        public int PkUsuario { get; set; }

        public string Nombre { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        [ForeignKey("Roles")]
        public int FkRol { get; set; }

        [ValidateNever]
        [JsonIgnore]

        public Rol Roles { get; set; }
    }
}