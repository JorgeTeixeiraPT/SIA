using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIA.Models
{
    public class Tecnica
    {
        public int Id { get; set; }
        public ICollection<Utilizador> Dono { get; set; }
        public String Nome { get; set; }
        public ICollection<Quadrante> Quadrante1 { get; set; }
        public ICollection<Quadrante> Quadrante2 { get; set; }
        public ICollection<Quadrante> Quadrante3 { get; set; }
        public ICollection<Quadrante> Quadrante4 { get; set; }

    }
}
