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
        float CalculaPreco(Lanche lanche);
        float PromocaoLigth(Lanche lanche);
        float PromocaoMuitaCarne(Lanche lanche);
        float PromocaoMuitoQueijo(Lanche lanche);
    }
}