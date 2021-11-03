using System;
using System.Collections.Generic;

#nullable disable

namespace fixit_API.Domains
{
    public partial class Colaborador
    {
        public Colaborador()
        {
            Chamada = new HashSet<Chamada>();
        }

        public int IdColaborador { get; set; }
        public int UsuarioFk { get; set; }
        public int SetorColabFk { get; set; }

        public virtual Setor SetorColabFkNavigation { get; set; }
        public virtual Usuario UsuarioFkNavigation { get; set; }
        public virtual ICollection<Chamada> Chamada { get; set; }
    }
}
