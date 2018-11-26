using System;
using System.ComponentModel.DataAnnotations;

namespace Locadora.Models
{
    public class Ator
    {
        [Key]
        public int ID { get; set; }
        public Video Video { get; set; }
        public String AtorPrincipal { get; set; }
    }
}