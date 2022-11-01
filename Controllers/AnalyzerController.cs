using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc;
using analyzer_refactor.Models;

namespace analyzer_refactor.Controllers;

public class AnalyzerController : Controller
{

    private readonly ILogger<AnalyzerController> _logger;
    private readonly string[] _fileFormats = { "txt" };

    private List<ITokenAnalyzer> analyzers;

    public AnalyzerController(ILogger<AnalyzerController> logger)
    {
        _logger = logger;
        analyzers = new List<ITokenAnalyzer> {
            new DistinctTokenAnalyzer(),
            new FileSummaryAnalyzer()
        };

    }
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Analyze(IFormFile uploadFile)
    {
        if (!ModelState.IsValid)
            return Error();

        if (!_fileFormats.Contains(System.IO.Path.GetExtension(uploadFile.FileName).Substring(1)))
            return View("Index");

        List<string> tokens = CreateTokenList(uploadFile);
        foreach (ITokenAnalyzer analyzer in analyzers)
            foreach (string token in tokens)
                analyzer.process(token);

        return View("Index");
        // return View();
    }

    private List<string> CreateTokenList(IFormFile file)
    {
        Stream fileStream = file.OpenReadStream();
        List<string> tokens = new List<string>();
        string pattern = "\\W";
        Regex rgx = new Regex(pattern);

        using (StreamReader reader = new StreamReader(fileStream))
        {
            string? line = "";
            while ((line = reader.ReadLine()) != null)
            {
                string[] splitLine = rgx.Split(line);
                foreach (var word in splitLine)
                    if (!String.IsNullOrWhiteSpace(word))
                        tokens.Add(word);
            }
            reader.Close();
        }

        return tokens;
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View("Index", new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}