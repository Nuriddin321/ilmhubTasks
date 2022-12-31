using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using mvc.Data;
using mvc.Models;
using mvc.Servives;

namespace mvc.Controllers;

public class HomeController : Controller
{
    private readonly NumberService _service;
 
    public HomeController( NumberService service)
    {
        _service = service;
    }

    public IActionResult Index()
    {
        return View(new Number());
    }


    [HttpPost]
    public IActionResult Index(Number number)
    {
        @ViewBag.Word = "";

        var num = number.Raqam.ToString(); 
        

        if (num.Length == 2)
        {
            @ViewBag.Word =  _service.GetNum2(number.Raqam);
        }
        else if (num.Length == 3)
        {
            @ViewBag.Word = _service.GetNum3(number.Raqam);
        }
        else if (num.Length == 4)
        {
            @ViewBag.Word = _service.GetNum4(number.Raqam);
        }
        else if (num.Length == 5)
        {
            @ViewBag.Word = _service.GetNum5(number.Raqam);
        }
        else if (num.Length == 6)
        {
            @ViewBag.Word = _service.GetNum6(number.Raqam);
        }
        else if (num.Length == 7)
        {
            @ViewBag.Word = _service.GetNum7(number.Raqam);
        }

        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

 
}
