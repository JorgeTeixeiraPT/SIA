using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SIA.Models
{
    public class Quadrante
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; } = "Escreva neste quadrante";
        public int Pontuacao { get; set; } = 0;
        public string Cor { get; set; } = "Branco";
    }
}
