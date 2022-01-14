using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SIA.Models
{
    public class Tecnica
    {
        
        [Key]
        public int Id { get; set; }
        public String Nome { get; set; }

        public ICollection<Utilizador> Utilizadores { get; set; }

        [ForeignKey("Quadrante")]
        public int QuadranteId { get; set; }
        public Quadrante Quadrante { get; set; }
    }
}
