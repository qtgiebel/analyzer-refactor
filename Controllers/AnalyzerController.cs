using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using analyzer_refactor.Models;

namespace analyzer_refactor.Controllers;

public class AnalyzerController : Controller
{

    private readonly ILogger<AnalyzerController> _logger;

    public AnalyzerController(ILogger<AnalyzerController> logger)
    {
        _logger = logger;
        _logger.LogInformation("Initialized AnalyzerController");
    }
    public IActionResult Index()
    {
        _logger.LogInformation("Inside Analyzer/Index action");
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}