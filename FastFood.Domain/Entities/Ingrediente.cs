using System;
using System.Collections.Generic;
using System.Text;

namespace FastFood.Domain.Entities
{
    public class Ingrediente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public float Valor { get; set; }
    }
}