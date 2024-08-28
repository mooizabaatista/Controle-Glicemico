using Microsoft.AspNetCore.Mvc;
using Application.Interfaces;
using Ui.Models;

namespace GliceControl.Ui.Controllers;

public class HomeController : Controller
{
    private ControleGlicemicoVM _controleGlicemicoVM;
    private readonly IControleGlicemicoService _service;

    public HomeController(IControleGlicemicoService service)
    {
        _service = service;
        _controleGlicemicoVM = new ControleGlicemicoVM();
    }

    public async Task<IActionResult> Index(long? id)
    {
        if (id.HasValue)
        {
            var dado = await _service.GetById(id.Value);
            if (dado != null)
            {
                _controleGlicemicoVM.ControleGlicemicoDto = dado;
                return Json(_controleGlicemicoVM.ControleGlicemicoDto);
            }
        }
        else
        {
            var dados = await _service.GetAll();
            _controleGlicemicoVM.ControleGlicemicoList = dados.OrderBy(x => x.Data).ToList();
            return View(_controleGlicemicoVM);
        }

        return View(_controleGlicemicoVM);
    }

    [HttpPost]
    public async Task<IActionResult> CreateOrUpdate(ControleGlicemicoVM controleGlicemicoVM)
    {

        if (controleGlicemicoVM.ControleGlicemicoDto != null)
        {
            // Edição
            if (controleGlicemicoVM.ControleGlicemicoDto.Id != 0)
            {
                await _service.Update(controleGlicemicoVM.ControleGlicemicoDto);
                return RedirectToAction("Index");
            }
            // Cadastro
            else
            {
                await _service.Create(controleGlicemicoVM.ControleGlicemicoDto);
                return RedirectToAction("Index");
            }
        }

        return View("Index", controleGlicemicoVM);
    }

    [HttpPost]
    public async Task<IActionResult> Delete(long id)
    {
        await _service.Delete(id);
        return RedirectToAction("Index");
    }
}
