using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FastFood.Domain.Contracts.Services;
using FastFood.Factory;
using FastFood.Factory.Enum;
using FastFood.Domain.Entities;

namespace FastFood.UI.Controllers
{
    [Route("[controller]"), Route("/")]
    public class LancheController : Controller
    {
        ILancheService serviceLanche = ServiceFactory.GetServiceInstance(EnumServices.Lanche) as ILancheService;
        IIngredienteService serviceIngrediente = ServiceFactory.GetServiceInstance(EnumServices.Ingrediente) as IIngredienteService;

        public IActionResult Index()
        {
            var lanches = serviceLanche.RetornaLanches();

            return View(lanches);
        }

        [Route("Lanche/LancheSelecionado")]
        public IActionResult LancheSelecionado(int id)
        {
            var lanche = serviceLanche.RetornaLanchePorId(id);
            return View(lanche);
        }

        [Route("Lanche/RetornaIngedientes")]
        public JsonResult RetornaIngedientes()
        {
            var ingrediente = serviceIngrediente.RetornaIngredientes();

            return Json(ingrediente);
        }

        [HttpPost]
        [Route("Lanche/PostRetornaLancheCalculado")]
        public JsonResult PostRetornaLancheCalculado(Lanche lanche)
        {
            var lancheAtual = serviceLanche.RetornaLancheCalculado(lanche);

            return Json(lancheAtual);
        }
    }
}