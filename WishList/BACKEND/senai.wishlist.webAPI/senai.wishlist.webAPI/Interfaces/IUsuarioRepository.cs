using senai.wishlist.webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.wishlist.webAPI.Interfaces
{
    interface IUsuarioRepository
    {
        /// <summary>
        /// valida o usuário 
        /// </summary>
        /// <param name="email">email que será passado</param>
        /// <param name="senha">senha do usuário</param>
        /// <returns>um objeto de usuário</returns>
        Usuario Login(string email, string senha);

        /// <summary>
        /// faz uma lista de todos os usuários
        /// </summary>
        /// <returns>uma lista de usuários</returns>
        List<Usuario> ListaUsuarios();

    }
}
