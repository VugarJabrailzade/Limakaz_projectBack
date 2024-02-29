using Limakaz.Database.DomainModels;
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

    //[HttpGet("currency")]
    //public IActionResult Currency()
    //{
    //    var url = "https://www.cbar.az/currencies/08.02.2024.xml";

    //    // XML verisini yükle
    //    XmlDocument doc = new XmlDocument();
    //    doc.Load(url);

    //    // XML verisini JObject'e dönüştür
    //    string xmlString = doc.InnerXml;
    //    XDocument xDoc = XDocument.Parse(xmlString);
    //    string value = JsonConvert.SerializeXNode(xDoc);
    //    var jsonObject = JsonConvert.DeserializeXmlNode(value);

    //    // Şimdi JSON verisini kullanabilirsiniz
    //    var currencyList = new List<Valute>();

    //    foreach (var valute in jsonObject)
    //    {
    //        var currency = new Valute
    //        {
    //            Code = (string)valute,
    //            Nominal = (int)valute,
    //            Name = (string)valute,
    //            Value = (decimal)valute
    //        };
    //        currencyList.Add(currency);
    //    }

    //    // İşlemlerin devamı...



    //    return View();
    //}
}
