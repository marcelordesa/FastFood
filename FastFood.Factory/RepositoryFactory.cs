using FastFood.Domain.Contracts.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace FastFood.Factory
{
    public class RepositoryFactory
    {
        public RepositoryFactory()
        {

        }

        public static IRepository GetRepositoryInstance<T>() where T : IRepository, new()
        {
            return new T();
        }
    }
}