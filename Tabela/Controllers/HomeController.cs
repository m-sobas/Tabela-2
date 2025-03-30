using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Threading.Tasks;
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
        var vm = _template.GetById(1);
     
        return View(vm);
    }

    public IActionResult Template()
    {
        var model = new Template();

        return View(model);
    }

    [HttpPost]
    public IActionResult Template(Template temp)
    {
        var templateToAdd = new Template
        {
            Name = temp.Name,
            DateTime = temp.DateTime,
            Queries = temp.Queries
        };

        // To nie dzia³a... warunek IsValid zawsze = false
        if (!ModelState.IsValid)
        {
            return View(templateToAdd);
        }

        _template.Add(templateToAdd);

        foreach (var query in temp.Queries)
        {
            if (query.File == null) continue;

            templateToAdd.Queries
                .FirstOrDefault(x => x.Id == query.Id)
                .ImageFileName = query.File.FileName;
        }

        _template.Update(templateToAdd);

        return Json(new { success = true, message = "Dane zosta³y zapisane", data = templateToAdd });
    }

    [HttpPost]
    public IActionResult SendForm(Template temp)
    {
        try
        {
            if (temp == null)
                throw new Exception();

            var templateToUpdate = _template.GetById(temp.Id);

            templateToUpdate.Name = temp.Name;
            templateToUpdate.DateTime = temp.DateTime;
            templateToUpdate.Queries = temp.Queries;

            foreach (var query in temp.Queries)
            {
                if (query.File == null) continue;

                templateToUpdate.Queries
                    .FirstOrDefault(x => x.Id == query.Id)
                    .ImageFileName = query.File.FileName;
            }

            _template.Update(templateToUpdate);
        }
        catch (Exception ex)
        {
            return RedirectToAction("Error", new { Message = "B³¹d... " + ex.Message });
        }

        return Json(new { success = true, message = "Dane zosta³y zapisane", data = temp });
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error(string message)
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier, Message = message });
    }
}
