using FastFood.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FastFood.Domain.Contracts.Services
{
    public interface IIngredienteService
    {
        IEnumerable<Ingrediente> RetornaIngredientes();
        Ingrediente RetornaIndedientePorId(int id);
        void AlterarIngrediente(Ingrediente ingrediente);
        //IEnumerable<Ingrediente> RetornaIngredientesPorArrayId(int[] ingredientes);
    }
}