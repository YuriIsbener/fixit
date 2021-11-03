using System;
using System.Collections.Generic;

#nullable disable

namespace fixit_API.Domains
{
    public partial class Chamater
    {
        public int MaterialFk { get; set; }
        public int ChamadaFk { get; set; }

        public virtual Chamada ChamadaFkNavigation { get; set; }
        public virtual Material MaterialFkNavigation { get; set; }
    }
}
