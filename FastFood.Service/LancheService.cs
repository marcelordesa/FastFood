﻿using FastFood.Domain.Contracts.Repositories;
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
            lanche.Valor = 0;
            //Calcula preço do lanche
            lanche.Valor = CalculaPreco(lanche);

            //Arrendoda valor e mantem duas casas decimais
            lanche.Valor = float.Parse(Math.Round(lanche.Valor, 2).ToString());

            //Verificar e retorna a promoção muita carne e se caso for uma promocao muita carne
            lanche = PromocaoMuitaCarne(lanche);
            //Verificar e retorna a promoção muito queijo e se caso for uma promocao muito queijos
            lanche = PromocaoMuitoQueijo(lanche);
            //Verificar e retorna a promoção do lanche ligth e se caso for um lanche ligth
            lanche = PromocaoLigth(lanche);

            return lanche;
        }

        public float CalculaPreco(Lanche lanche)
        {
            foreach (var ingrediente in lanche.IngredienteIds)
            {
                lanche.Valor = lanche.Valor + this.repository.RetornaIndedientePorId(ingrediente).Valor;
            }

            return lanche.Valor;
        }

        private Lanche PromocaoLigth(Lanche lanche)
        {
            bool temAlface = false;
            bool temBacon = false;

            foreach (var item in lanche.IngredienteIds)
            {
                //Verifica se tem alface
                if (item == 1)
                    temAlface = true;

                //Verifica se tem bacon
                if (item == 2)
                    temBacon = true;
            }

            // 10%
            float percentual = 10.0f / 100.0f;

            //Se tiver alface e nao tiver bacon, e uma lanche ligth e recebe o desconto
            if (temAlface && !temBacon)
                lanche.Valor = lanche.Valor - (percentual * lanche.Valor);

            //Arrendoda valor e mantem duas casas decimais
            lanche.Valor = float.Parse(Math.Round(lanche.Valor, 2).ToString());

            return lanche;
        }

        private Lanche PromocaoMuitaCarne(Lanche lanche)
        {
            int carne = 0;

            float valorCarne = this.repository.RetornaIndedientePorId(3).Valor;

            foreach (var item in lanche.IngredienteIds)
            {
                //Verifica se o ingrediente é carne
                if (item == 3)
                    carne++;

                //Se já tiver 3 escolhas de carne, e descontado o valor de uma das carnes
                if (carne == 3)
                {
                    lanche.Valor = lanche.Valor - valorCarne;
                    carne = 0;  
                }
            }

            //Arrendoda valor e mantem duas casas decimais
            lanche.Valor = float.Parse(Math.Round(lanche.Valor, 2).ToString());

            return lanche;
        }

        private Lanche PromocaoMuitoQueijo(Lanche lanche)
        {
            int queijo = 0;

            float valorQueijo = this.repository.RetornaIndedientePorId(5).Valor;

            foreach (var item in lanche.IngredienteIds)
            {
                //Verifica se o ingrediente é queijo
                if (item == 5)
                    queijo++;

                //Se já tiver 3 escolhas de queijo, e descontado o valor um dos queijo
                if (queijo == 3)
                {
                    lanche.Valor = lanche.Valor - valorQueijo;
                    queijo = 0;
                }
            }

            //Arrendoda valor e mantem duas casas decimais
            lanche.Valor = float.Parse(Math.Round(lanche.Valor, 2).ToString());

            return lanche;
        }
    }
}