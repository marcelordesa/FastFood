using FastFood.Domain.Contracts.Services;
using FastFood.Domain.Entities;
using FastFood.Factory;
using FastFood.Factory.Enum;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace FastFood.UnitTest
{
    [TestClass]
    public class TestLanche
    {
        ILancheService service = ServiceFactory.GetServiceInstance(EnumServices.Lanche) as ILancheService;

        [TestMethod]
        public void RetornarLanchePorId()
        {
            //1 = X-Bacon; 2 = X-Burger; 3 = X-Egg; 4 = X-Egg Bacon
            service.RetornaLanchePorId(1);
        }

        [TestMethod]
        public void RetornarLanches()
        {
            service.RetornaLanches();
        }

        [TestMethod]
        public void RetornarLanchesCalculado()
        {
            //1 = X-Bacon; 2 = X-Burger; 3 = X-Egg; 4 = X-Egg Bacon
            var lanche = service.RetornaLanchePorId(1);

            List<int> ingredientes = new List<int>();
            //1 = Alface; 2 = Bacon; 3 = Hamburguer; 4 = Ovo; 5 = Queijo;
            ingredientes.Add(2);
            ingredientes.Add(3);
            ingredientes.Add(5);
            lanche.IngredienteIds = ingredientes.ToArray();

            service.RetornaLancheCalculado(lanche);
        }

        [TestMethod]
        public void RetornarCalcularLanches()
        {
            //1 = X-Bacon; 2 = X-Burger; 3 = X-Egg; 4 = X-Egg Bacon
            var lanche = service.RetornaLanchePorId(1);

            List<int> ingredientes = new List<int>();
            //1 = Alface; 2 = Bacon; 3 = Hamburguer; 4 = Ovo; 5 = Queijo;
            ingredientes.Add(2);
            ingredientes.Add(3);
            ingredientes.Add(5);
            lanche.IngredienteIds = ingredientes.ToArray();

            service.CalculaPreco(lanche);
        }
    }
}