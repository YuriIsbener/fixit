using System;
using System.Collections.Generic;

#nullable disable

namespace fixit_API.Domains
{
    public partial class Usuario
    {
        public Usuario()
        {
            Colaboradors = new HashSet<Colaborador>();
            Prestadors = new HashSet<Prestador>();
        }

        public int IdUsuario { get; set; }
        public string Nome { get; set; }
        public bool? TipoUser { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        public virtual ICollection<Colaborador> Colaboradors { get; set; }
        public virtual ICollection<Prestador> Prestadors { get; set; }
    }
}
