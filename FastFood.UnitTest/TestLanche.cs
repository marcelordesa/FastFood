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
            service.RetornaLanchePorId(1);
        }

        [TestMethod]
        public void RetornarLanches()
        {
            service.RetornaLanches();
        }
    }
}