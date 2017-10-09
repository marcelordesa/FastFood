using FastFood.Domain.Contracts.Repositories;
using FastFood.Domain.Contracts.Services;
using FastFood.Factory.Enum;
using FastFood.Infrastructures.Repositories;
using FastFood.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace FastFood.Factory
{
    public class ServiceFactory
    {
        public ServiceFactory()
        {

        }

        public static object GetServiceInstance(EnumServices opcao)
        {
            IRepository repository = RepositoryFactory.GetRepositoryInstance<Repository>();

            if (opcao == EnumServices.Lanche)
            {
                ILancheService service = new LancheService(repository);

                return service;
            }

            if (opcao == EnumServices.Ingrediente)
            {
                IIngredienteService service = new IngredienteService(repository);

                return service;
            }

            return null;
        }
    }
}