using System.Diagnostics;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc;
using analyzer_refactor.Models;

namespace analyzer_refactor.Controllers;

public class AnalyzerController : Controller
{

    private readonly ILogger<AnalyzerController> _logger;
    private readonly string _fileFormat = ".txt";

    private List<ITokenAnalyzer> analyzers;

    public AnalyzerController(ILogger<AnalyzerController> logger)
    {
        _logger = logger;
        analyzers = new List<ITokenAnalyzer> {
            new DistinctTokenAnalyzer()
        };

    }
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Analyze(IFormFile file)
    {
        if (!ModelState.IsValid)
        {
            return Error();
        }

        if (System.IO.Path.GetExtension(file.FileName).Substring(1) != _fileFormat)
        {
            return Error();
        }

        Stream fileStream = file.OpenReadStream();
        List<string> tokens = new List<string>();
        string pattern = "\\W";
        Regex rgx = new Regex(pattern);

        using (StreamReader reader = new StreamReader(fileStream))
        {
            string line = "";
            while ((line = reader.ReadLine()) != null)
            {
                string[] splitLine = rgx.Split(line);
                foreach (var word in splitLine)
                {
                    if (!String.IsNullOrWhiteSpace(word) && !String.IsNullOrEmpty(word))
                    {
                        tokens.Add(word);
                    }
                }
            }
            reader.Close();
        }

        return View(new InputFileModel());
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}