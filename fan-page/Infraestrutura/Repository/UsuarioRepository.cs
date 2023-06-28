using fan_page.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.SymbolStore;

namespace fan_page.Infraestrutura.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly Context _context;
        public UsuarioRepository()
        {
            _context = new Context();
        }

        public void CriarUsuario(Usuario usuario)
        {
             _context.Usuario.Add(usuario);
             _context.SaveChanges();
        }


        public Usuario VerificarUsuarioParaLogin(string email, string senha)
        {
            var usuario = _context.Usuario.FirstOrDefault(u => u.Email == email && u.Senha == senha);
            return usuario;
        }

        public Usuario BuscarUsuario(string valor)
        {
           var usuario = _context.Usuario.FirstOrDefault(u => u.NomeDoUsuario == valor || u.Email == valor);
            return usuario;
        }
    }
}
