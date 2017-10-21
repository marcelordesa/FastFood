using FastFood.Domain.Contracts.Repositories;
using FastFood.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace FastFood.Infrastructures.Repositories
{
    public class Repository : IRepository
    {
        private string path = System.AppDomain.CurrentDomain.BaseDirectory.ToString().Replace("FastFood.UnitTest\\bin\\Debug\\netcoreapp2.0\\", "").Replace("FastFood.UI\\bin\\Debug\\netcoreapp2.0\\", "");

        public IEnumerable<Ingrediente> RetornaIngredientes()
        {
            var json = System.IO.File.ReadAllText(path + "\\Ingredientes.json");
            return JsonConvert.DeserializeObject<IEnumerable<Ingrediente>>(json);
        }

        public Ingrediente RetornaIndedientePorId(int id)
        {
            return RetornaIngredientes().Where(i => i.Id == id).FirstOrDefault();
        }

        public IEnumerable<Lanche> RetornaLanches()
        {
            var json = System.IO.File.ReadAllText(path + "\\Lanches.json");
            var lanches = JsonConvert.DeserializeObject<IEnumerable<Lanche>>(json);

            foreach (var itemLanche in lanches)
            {
                float valorLanche = 0;

                foreach (var ingredienteId in itemLanche.IngredienteIds)
                {
                    valorLanche = valorLanche + RetornaIndedientePorId(ingredienteId).Valor;
                }

                itemLanche.Ingredientes = RetornaIngredientes().Where(i => itemLanche.IngredienteIds.Contains(i.Id));

                itemLanche.Valor = valorLanche;
            }

            return lanches;
        }

        public Lanche RetornaLanchePorId(int id)
        {
            var lanche = RetornaLanches().Where(i => i.Id == id).FirstOrDefault();
            float valorLanche = 0;

            foreach (var ingredienteId in lanche.IngredienteIds)
            {
                valorLanche = valorLanche + RetornaIndedientePorId(ingredienteId).Valor;
            }

            lanche.Valor = valorLanche;

            return lanche;
        }

        public void AlterarIngrediente(Ingrediente ingrediente)
        {
            var ingredientesAlterados = RetornaIngredientes();

            foreach(var item in ingredientesAlterados)
            {
                if (item.Id == ingrediente.Id)
                {
                    item.Valor = ingrediente.Valor;
                    break;
                }
            }

            var arquivo = System.IO.File.ReadAllText(path + "\\Ingredientes.json");

            using (var stream = new StreamWriter(path + "\\Ingredientes.json"))
            {
                var json = JsonConvert.SerializeObject(ingredientesAlterados);
                stream.Write(json);
            }
        }
    }
}