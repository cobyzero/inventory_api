using inventory_api.src.core.utils;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IConfiguration _configuration;

    public AuthController(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginRequestModel model)
    {
        var jwtUtil = new JwtUtil(_configuration);
        return Ok(ResponseUtil.Success(jwtUtil.GenerateToken(model.Email), "Login successful"));
    }
}