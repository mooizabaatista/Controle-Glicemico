using Application.Interfaces;
using Domain.Enums;
using Microsoft.AspNetCore.Mvc;

namespace Ui.Controllers;
public class RelatoriosController : Controller
{
    private readonly IControleGlicemicoService _service;

    public RelatoriosController(IControleGlicemicoService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    // [HttpGet]
    // public async Task<JsonResult> GetDadosPorDataChart()
    // {
    //     var dados = await _service.GetAll();
    //     return Json(dados.OrderBy(x => x.Data).ToList());
    // }

    [HttpGet]
    public async Task<JsonResult> GetDadosPorDataChart(int? dias)
    {
        var dados = await _service.GetAll();

        // Agrupar dados por data e calcular os valores mínimo e máximo
        var dadosAgrupados = dados
            .GroupBy(x => x.Data)
            .Select(g => new
            {
                Data = g.Key.ToShortDateString(), // Convertendo a data para formato curto
                ValorGlicemiaManha = g.Where(x => x.Periodo == Periodo.Manha).Select(x => x.ValorGlicemico).DefaultIfEmpty(0).First(),
                ValorGlicemiaTarde = g.Where(x => x.Periodo == Periodo.Tarde).Select(x => x.ValorGlicemico).DefaultIfEmpty(0).First(),
                ValorGlicemiaNoite = g.Where(x => x.Periodo == Periodo.Noite).Select(x => x.ValorGlicemico).DefaultIfEmpty(0).First(),
            })
            .OrderBy(x => x.Data)
            .ToList();

        if (dias != null)
            dadosAgrupados = dadosAgrupados.Take((int)dias).ToList();

        var resultado = new
        {
            Dados = dadosAgrupados
        };

        return Json(resultado);
    }
}