using app_appinsightsdemo.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

//[Route("api/[controller]")]
[ApiController]
public class DemoController : ControllerBase
{
    private readonly string urlFx = "https://func-appinsightsdemo-dev-001.azurewebsites.net/api/HttpTrigger1?code=UkqWK_JhJEBn51Q9jSq3ax83xMPhDihdMwyLZjVr4GO_AzFuMHODdA==";
    private readonly string urlFailngFx = "https://func-appinsightsdemo-dev-001.azurewebsites.net/api/HttpTrigger2?code=bHZOEVjQ5s39rihnmYpzAkLUU0a4qJWPZVxT4Dd1x3cNAzFuBPdhVw==";
    private readonly DemoContext demoContext;

    public DemoController(DemoContext demoContext)
    {
        this.demoContext = demoContext;
    }

    //[HttpGet]
    //[Route("api/[controller]/call/fx")]
    //public ActionResult<string> Get()
    //{
    //    return new OkObjectResult("Hello World");
    //}

    [HttpGet]
    [Route("api/[controller]/call/fx")]
    public async Task<ActionResult<string>> Get()
    {
        HttpClient client = new HttpClient();
        var response = await client.GetAsync(urlFx);
        var text = await response.Content.ReadAsStringAsync();

        return new OkObjectResult(text);
    }

    [HttpGet]
    [Route("api/[controller]/call/failingfx")]
    public async Task<ActionResult<string>> GetFailingFx()
    {
        HttpClient client = new HttpClient();
        var response = await client.GetAsync(urlFailngFx);
        var text = await response.Content.ReadAsStringAsync();

        return new OkObjectResult(text);
    }

    [HttpGet]
    [Route("api/[controller]/call/sqldividebyone")]
    public ActionResult<string> GetUdf()
    {
        var integerResult = demoContext.IntegerResult.FromSqlRaw(@"select Value=dbo.fndividebyone()").SingleOrDefault();

        return new OkObjectResult(integerResult.Value);
    }

    [HttpGet]
    [Route("api/[controller]/call/sqldividebyzero")]
    public ActionResult<string> GetFailingUdf()
    {
        var integerResult = demoContext.IntegerResult.FromSqlRaw(@"select Value=dbo.fndividebyzero()").SingleOrDefault();

        return new OkObjectResult(integerResult.Value);
    }

}