using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace fixit_API.Domains
{
    public partial class Chamada
    {

        public int PrestadorFk { get; set; }
        public int ColaboradorFk { get; set; }
        public int StatusChamadaFk { get; set; }
        public DateTime DataChamada { get; set; }

        public virtual Colaborador ColaboradorFkNavigation { get; set; }
        public virtual Prestador PrestadorFkNavigation { get; set; }
        public virtual Statuschamada StatusChamadaFkNavigation { get; set; }

        public Chamada()
        {
            Chamados = new HashSet<Chamada>();
        }

        public int IdChamada { get; set; }

        // Define que o campo é obrigatório
        [Required(ErrorMessage = "O título do chamado é obrigatório!")]
        public string NomeChamado { get; set; }

        public virtual ICollection<Chamada> Chamados { get; set; }
    }
}
