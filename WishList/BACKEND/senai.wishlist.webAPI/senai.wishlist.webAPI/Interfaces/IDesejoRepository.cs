using senai.wishlist.webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.wishlist.webAPI.Interfaces
{
    interface IDesejoRepository
    {
        List<Desejo> Listar();

        Desejo BuscarPorId(int id);

        void Cadastrar(Desejo novoDesejo);

        List<Desejo> ListarMinhas(int id);
    }
}
