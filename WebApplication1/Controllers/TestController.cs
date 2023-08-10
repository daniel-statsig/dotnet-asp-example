using Microsoft.AspNetCore.Mvc;
using Statsig;

namespace WebApplication1.Controllers;

[ApiController]
[Route("[controller]")]
public class TestController : ControllerBase
{
    private readonly StatsigWrapper _statsig;

    public TestController(StatsigWrapper statsig)
    {
        _statsig = statsig;
    }

    [HttpPost(Name = "PostData")]
    public async Task<ActionResult<string>> Post([FromBody] string email)
    {
        var user = new StatsigUser
        {
            UserID = "a-user",
            Email = email,
        };
        var result = await _statsig.CheckGate(user, "has_email");

        return $"Result for {email}: {(result ? "Pass" : "Fail")}";
    }
}