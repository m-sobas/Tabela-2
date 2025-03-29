using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Tabela.Models.Domains;
using Tabela.Models.ViewModels;
using Tabela.Repositories;

namespace Tabela.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ITemplateRepository _template;

    public HomeController(ILogger<HomeController> logger,
        ITemplateRepository template)
    {
        _logger = logger;
        _template = template;
    }

    public IActionResult Index()
    {
        var vm = _template.GetTemplateById(1);
     
        return View(vm);
    }

    [HttpPost]
    public IActionResult SendForm(Template temp)
    {
        var templateToUpdate = _template.GetTemplateById(temp.Id);

        templateToUpdate.Name = temp.Name;
        templateToUpdate.DateTime = temp.DateTime;
        templateToUpdate.Queries = temp.Queries;

        _template.AddTemplate(templateToUpdate);

        return Json(new { success = true, message = "Dane zosta³y zapisane", data = temp });
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
