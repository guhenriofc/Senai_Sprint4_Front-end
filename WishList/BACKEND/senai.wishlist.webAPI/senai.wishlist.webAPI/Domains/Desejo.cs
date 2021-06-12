using System;
using System.Collections.Generic;

#nullable disable

namespace senai.wishlist.webAPI.Domains
{
    public partial class Desejo
    {
        public int IdDesejos { get; set; }
        public int? IdUsuario { get; set; }
        public string Descricao { get; set; }
        public DateTime? DataCriacao { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
