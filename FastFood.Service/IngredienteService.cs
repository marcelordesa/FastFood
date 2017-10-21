using FastFood.Domain.Contracts.Repositories;
using FastFood.Domain.Contracts.Services;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using FastFood.Domain.Entities;

namespace FastFood.Service
{
    public class IngredienteService : IIngredienteService
    {
        private IRepository repository;

        public IngredienteService(IRepository _repository)
        {
            this.repository = _repository;
        }

        public void AlterarIngrediente(Ingrediente ingrediente)
        {
            this.repository.AlterarIngrediente(ingrediente);
        }

        public Ingrediente RetornaIndedientePorId(int id)
        {
            return this.repository.RetornaIndedientePorId(id);
        }

        public IEnumerable<Ingrediente> RetornaIngredientes()
        {
            return this.repository.RetornaIngredientes();
        }

        //public IEnumerable<Ingrediente> RetornaIngredientesPorArrayId(int[] ingredientes)
        //{
        //    var lstIngredintes = RetornaIngredientes();
        //    lstIngredintes = lstIngredintes.Where(i => ingredientes.Contains(i.Id)).ToList();

        //    return lstIngredintes;
        //}
    }
}