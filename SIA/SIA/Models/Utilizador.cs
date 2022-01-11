using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SIA.Models
{
    public class Utilizador
    {
//Não sei se uso este ou o AspNetUsers (é presizo add Estado)
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool Estado { get; set; }
        public string Funcao { get; set; }
    }
}
