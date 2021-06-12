using Microsoft.EntityFrameworkCore;
using senai.wishlist.webAPI.Contexts;
using senai.wishlist.webAPI.Domains;
using senai.wishlist.webAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.wishlist.webAPI.Repositories
{
    public class DesejoRepository : IDesejoRepository
    {
        WishListContext ctx = new WishListContext();

        public Desejo BuscarPorId(int id)
        {
            return ctx.Desejos.FirstOrDefault(x => x.IdDesejos == id);
        }

        public void Cadastrar(Desejo novoDesejo)
        {
            ctx.Desejos.Add(novoDesejo);

            ctx.SaveChanges();
        }

        public List<Desejo> Listar()
        {
            return ctx.Desejos.ToList();
        }

        public List<Desejo> ListarMinhas(int id)
        {
            // Retorna uma lista com todas as informações das presenças
            return ctx.Desejos
                // Adiciona na busca as informações do evento que o usuário participa
                .Include(p => p.IdUsuarioNavigation)
                // Estabelece como parâmetro de consulta o ID do usuário recebido
                .Where(p => p.IdUsuario == id)
                .ToList();
        }
    }
}
