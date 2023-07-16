using Microsoft.AspNetCore.Mvc;

namespace CommandApi.Controllers;

[Route("api/[controller]")]
public class CommandsController : ControllerBase
{
    [HttpGet]
    public IEnumerable<string> Get()
    {
        return new string[] { "this", "is", "hard", "coded" };
    }
}
