using System; 
using System.ComponentModel.DataAnnotations;

namespace Locadora.Models
{
    public class Cliente
    {
        [Key]
        public int CPF  { get; set; } 
        public String Nome { get; set; }
        public String Tel { get; set; }
        

    }
}