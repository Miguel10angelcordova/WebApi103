namespace WebApi103.Controllers
{
    internal class Usuario
    {
        public string Nombre { get; internal set; }
        public string UserName { get; internal set; }
        public string PasswordHasher { get; internal set; }
        public string Password { get; internal set; }
        public int Fkrol { get; internal set; }
    }
}