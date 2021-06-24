using System;
using System.Collections.Generic;

namespace dotnetAspExample
{
    public class Artista
    {
        public long Id { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaNacimiento {get; set; }
        public virtual List<Disco> Discos { get; set; }
    }
}