using System;
using System.Collections.Generic;

#nullable disable

namespace u3_efcore_18100241.Models
{
    public partial class Artista
    {
        public Artista()
        {
            Canciones = new HashSet<Cancione>();
        }

        public int IdArtista { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Cancione> Canciones { get; set; }
    }
}
