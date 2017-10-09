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
            service.RetornaIndedientePorId(1);
        }

        [TestMethod]
        public void AlterarIngrediente()
        {
            Ingrediente ingrediente = new Ingrediente {
                Id = 1,
                Nome = "Alface",
                Valor = 3.00M
            };

            service.AlterarIngrediente(ingrediente);
        }
    }
}