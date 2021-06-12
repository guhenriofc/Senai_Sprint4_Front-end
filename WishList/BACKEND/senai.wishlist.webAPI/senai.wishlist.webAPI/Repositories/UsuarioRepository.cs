using senai.wishlist.webAPI.Contexts;
using senai.wishlist.webAPI.Domains;
using senai.wishlist.webAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.wishlist.webAPI.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        WishListContext ctx = new WishListContext();

        public List<Usuario> ListaUsuarios()
        {
            return ctx.Usuarios.ToList();
        }

        public Usuario Login(string email, string senha)
        {
            return ctx.Usuarios.FirstOrDefault(l => l.Email == email && l.Senha == senha);
        }
    }
}
