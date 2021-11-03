using System;
using System.Collections.Generic;

#nullable disable

namespace fixit_API.Domains
{
    public partial class Prestador
    {
        public Prestador()
        {
            Chamada = new HashSet<Chamada>();
        }

        public int IdPrestador { get; set; }
        public int UsuarioFk { get; set; }
        public int SetorPrestFk { get; set; }

        public virtual Setor SetorPrestFkNavigation { get; set; }
        public virtual Usuario UsuarioFkNavigation { get; set; }
        public virtual ICollection<Chamada> Chamada { get; set; }
    }
}
