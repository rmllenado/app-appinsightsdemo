using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class DemoController : ControllerBase
{
    private readonly string url = "https://func-appinsightsdemo-dev-001.azurewebsites.net/api/HttpTrigger1?code=UkqWK_JhJEBn51Q9jSq3ax83xMPhDihdMwyLZjVr4GO_AzFuMHODdA==";

    public DemoController(){}

    [HttpGet]
    public async Task<ActionResult<string>> Get()
    {
        HttpClient client = new HttpClient();
        var response = await client.GetAsync(url);
        var text = await response.Content.ReadAsStringAsync();

        return new OkObjectResult(text);
    }

    // [HttpGet]
    // public ActionResult<string> Get()
    // {
    //     return new OkObjectResult("Hello World");
    // }
}