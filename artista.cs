using System;
using System.Collections.Generic;

namespace dotnetAspExample
{
    public class Artista
    {
        public long id { get; set; }
        public string nombre { get; set; }
        public DateTime fechaNacimiento {get; set; }
        public List<Disco> discos { get; set; }
    }
}