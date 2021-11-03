using System;
using System.Collections.Generic;

#nullable disable

namespace fixit_API.Domains
{
    public partial class Setor
    {
        public Setor()
        {
            Colaboradors = new HashSet<Colaborador>();
            Prestadors = new HashSet<Prestador>();
        }

        public int IdSetor { get; set; }
        public string NomeSetor { get; set; }

        public virtual ICollection<Colaborador> Colaboradors { get; set; }
        public virtual ICollection<Prestador> Prestadors { get; set; }
    }
}
