using inventory_api.src.core.model_context;
using inventory_api.src.core.utils;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IConfiguration _configuration;
    private readonly InventoryManagementContext _context;
    public AuthController(IConfiguration configuration, InventoryManagementContext context)
    {
        _configuration = configuration;
        _context = context;
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginRequestModel model)
    {
        try
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == model.Email && u.Password == model.Password);
            if (user == null)
                return Ok(ResponseUtil.Error(null, "Invalid email or password"));


            var jwtUtil = new JwtUtil(_configuration);
            return Ok(ResponseUtil.Success(jwtUtil.GenerateToken(user.Email), "Login successful"));
        }
        catch (System.Exception)
        {
            return Ok(ResponseUtil.Error(null, "Something went wrong"));
        }
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequestModel model)
    {
        try
        {
            var user = new User
            {
                Email = model.Email,
                Password = model.Password,
                Name = model.Name
            };
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return Ok(ResponseUtil.Success(user, "Register successful"));
        }
        catch (System.Exception)
        {
            return Ok(ResponseUtil.Error(null, "Something went wrong"));
        }
    }
}