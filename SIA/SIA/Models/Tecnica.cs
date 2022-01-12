using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SIA.Models
{
    public class Tecnica
    {
        
        [Key]
        public int Id { get; set; }
        public String Nome { get; set; }
        public IList<Quadrante> QuadrantesL { get; set; }
        public int UtilizadorId { get; set; }
        public Utilizador Utilizador { get; set; }
    }
}
