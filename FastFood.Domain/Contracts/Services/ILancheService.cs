using FastFood.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FastFood.Domain.Contracts.Services
{
    public interface ILancheService
    {
        IEnumerable<Lanche> RetornaLanches();
        Lanche RetornaLanchePorId(int id);
        Lanche RetornaLancheCalculado(Lanche lanche);
    }
}