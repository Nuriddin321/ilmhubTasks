using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LogsController : ControllerBase
{
    private string AddFolder = "LogData";
    private string SaveFolder = "LogData/log.json";
    [HttpPost]
    public IActionResult CreateLog(string input)
    {
        try
        {
            var digits = input.Split(' ').Select(int.Parse).ToArray();
            if (digits[0] >= digits[1])
                return BadRequest();

            int output = 0;
            for (int i = digits[0]; i <= digits[1]; i++)
            {
                output += i;
            }

            var logfile = new Log();
            logfile.Input = input;
            logfile.Output = output.ToString();
            logfile.Date = DateTime.Now;


            if (!Directory.Exists(AddFolder))
            {
                Directory.CreateDirectory(AddFolder);
            }

            var readData = System.IO.File.ReadAllText(SaveFolder);

            var jsonList = JsonConvert.DeserializeObject<List<Log>>(readData);

            var jsonData = JsonConvert.SerializeObject(logfile);
            jsonList.Add(logfile);

            var data = JsonConvert.SerializeObject(jsonList);
            
            System.IO.File.WriteAllText(SaveFolder, data);

            return Ok(output);
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }
}

 