using System;
using System.Collections.Generic;

#nullable disable

namespace u3_efcore_18100241.Models
{
    public partial class Cancione
    {
        public int IdCancion { get; set; }
        public int? IdArtista { get; set; }
        public string NombreCancion { get; set; }

        public virtual Artista IdArtistaNavigation { get; set; }
    }
}
