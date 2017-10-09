using FastFood.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FastFood.Domain.Contracts.Repositories
{
    public interface IRepository
    {
        IEnumerable<Ingrediente> RetornaIngredientes();
        Ingrediente RetornaIndedientePorId(int id);
        IEnumerable<Lanche> RetornaLanches();
        Lanche RetornaLanchePorId(int id);
        void AlterarIngrediente(Ingrediente ingrediente);
    }
}