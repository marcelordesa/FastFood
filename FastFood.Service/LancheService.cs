using FastFood.Domain.Contracts.Repositories;
using FastFood.Domain.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Text;
using FastFood.Domain.Entities;

namespace FastFood.Service
{
    public class LancheService : ILancheService
    {
        private IRepository repository;

        public LancheService(IRepository _repository)
        {
            this.repository = _repository;
        }

        public Lanche RetornaLanchePorId(int id)
        {
            return this.repository.RetornaLanchePorId(id);
        }

        public IEnumerable<Lanche> RetornaLanches()
        {
            return this.repository.RetornaLanches();
        }

        public Lanche RetornaLancheCalculado(Lanche lanche)
        {
            var lancheAtual = this.repository.RetornaLanchePorId(lanche.Id);
            List<int> ingredientes = new List<int>();

            ingredientes.AddRange(lancheAtual.IngredienteIds);
            ingredientes.AddRange(lanche.IngredienteIds);

            lancheAtual.IngredienteIds = ingredientes.ToArray();

            foreach (var ingrediente in lanche.IngredienteIds)
            {
                lancheAtual.Valor = lancheAtual.Valor + this.repository.RetornaIndedientePorId(ingrediente).Valor;
            }

            PromocaoLigth(lancheAtual);
            PromocaoMuitaCarne(lancheAtual);
            PromocaoMuitoQueijo(lancheAtual);

            return lancheAtual;
        }

        private Lanche PromocaoLigth(Lanche lanche)
        {
            bool temAlface = false;
            bool temBacon = false;

            foreach (var item in lanche.IngredienteIds)
            {
                if (item == 1)
                    temAlface = true;

                if (item == 2)
                    temBacon = false;
            }

            if (temAlface && !temBacon)
                lanche.Valor = lanche.Valor - 0.10f;

            return lanche;
        }

        private Lanche PromocaoMuitaCarne(Lanche lanche)
        {
            int carne = 0;

            float valorCarne = this.repository.RetornaIndedientePorId(3).Valor;

            foreach (var item in lanche.IngredienteIds)
            {
                if (item == 3)
                    carne++;

                if (carne == 3)
                {
                    lanche.Valor = lanche.Valor - valorCarne;
                    carne = 0;  
                }
            }

            return lanche;
        }

        private Lanche PromocaoMuitoQueijo(Lanche lanche)
        {
            int queijo = 0;

            float valorQueijo = this.repository.RetornaIndedientePorId(5).Valor;

            foreach (var item in lanche.IngredienteIds)
            {
                if (item == 5)
                    queijo++;

                if (queijo == 5)
                {
                    lanche.Valor = lanche.Valor - valorQueijo;
                    queijo = 0;
                }
            }

            return lanche;
        }
    }
}