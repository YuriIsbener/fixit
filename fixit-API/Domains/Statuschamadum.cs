﻿using System;
using System.Collections.Generic;

#nullable disable

namespace fixit_API.Domains
{
    public partial class Statuschamada
    {
        public Statuschamada()
        {
            Chamada = new HashSet<Chamada>();
        }

        public int IdStatusChamada { get; set; }
        public string NomeStatusChamada { get; set; }

        public virtual ICollection<Chamada> Chamada { get; set; }
    }
}
