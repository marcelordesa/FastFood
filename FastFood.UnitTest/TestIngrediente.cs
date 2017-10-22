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
    public class TestIngrediente
    {
        IIngredienteService service = ServiceFactory.GetServiceInstance(EnumServices.Ingrediente) as IIngredienteService;

        [TestMethod]
        public void RetornaIngedientes()
        {
            service.RetornaIngredientes();
        }

        [TestMethod]
        public void RetornaIngedientePorId()
        {
            //1 = Alface; 2 = Bacon; 3 = Hamburguer; 4 = Ovo; 5 = Queijo;
            service.RetornaIndedientePorId(1);
        }

        [TestMethod]
        public void AlterarIngrediente()
        {
            //1 = Alface; 2 = Bacon; 3 = Hamburguer; 4 = Ovo; 5 = Queijo;
            Ingrediente ingrediente = new Ingrediente {
                Id = 1,
                Nome = "Alface",
                Valor = 3.00f
            };

            service.AlterarIngrediente(ingrediente);
        }
    }
}