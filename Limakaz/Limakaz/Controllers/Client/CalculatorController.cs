using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Xml;
using System.Xml.Linq;
using static System.Net.WebRequestMethods;

namespace Limakaz.Controllers.Client;

[Route("calculator")]
public class CalculatorController : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpGet("currency")]
    public IActionResult Currency()
    {
        var url = "https://www.cbar.az/currencies/08.02.2024.xml";

        XmlDocument doc = new XmlDocument();
        doc.Load(url);

        string json = JsonConvert.SerializeXmlNode(doc);
        

        return View();
    }
}
