using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SIA.Models
{
    public class Utilizador
    {
      
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool Estado { get; set; }
        public string Funcao { get; set; }

        [ForeignKey("Tecnica")]
        public int TecnicaId { get; set; }
        public Tecnica Tecnica { get; set; }

    }
}
