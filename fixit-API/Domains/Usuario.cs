using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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

        [Required(ErrorMessage = "O campo e-mail deve ser preenchido para cadastrar um usuário!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "O campo senha deve ser preenchido para cadastrar um usuário!")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Ao cadastrar um usuário, a senha deverá ter de 5 a 50 caracteres!")]
        public string Senha { get; set; }

        public virtual ICollection<Colaborador> Colaboradors { get; set; }
        public virtual ICollection<Prestador> Prestadors { get; set; }
    }
}
