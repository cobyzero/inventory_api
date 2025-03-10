using inventory_api.src.core.model_context;
using inventory_api.src.core.utils;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IConfiguration _configuration;
    private readonly InventoryManagementContext _context;
    private readonly UserManager<User> _userManager;

    public AuthController(
        IConfiguration configuration,
        InventoryManagementContext context,
        UserManager<User> userManager
    )
    {
        _configuration = configuration;
        _context = context;
        _userManager = userManager;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequestModel model)
    {
        try
        {
            var user = _userManager.FindByEmailAsync(model.Username).Result;
            if (user == null)
            {
                return Ok(ResponseUtil.Error(null, "User not found"));
            }

            if (!await _userManager.CheckPasswordAsync(user, model.Password))
            {
                return Ok(ResponseUtil.Error(null, "Invalid user or password"));
            }

            var jwtUtil = new JwtUtil(_configuration);
            return Ok(
                ResponseUtil.Success(jwtUtil.GenerateToken(user.Email ?? ""), "Login successful")
            );
        }
        catch (System.Exception e)
        {
            return Ok(ResponseUtil.Error(null, "Error: " + e.Message));
        }
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequestModel model)
    {
        try
        {
            var user = new User
            {
                Email = model.Username,
                UserName = model.Username,
                Name = model.Name,
                DocumentNumber = model.DocumentNumber,
            };
            var userProtected = await _userManager.CreateAsync(user, model.Password);

            if (!userProtected.Succeeded)
            {
                return Ok(
                    ResponseUtil.Error(
                        null,
                        userProtected.Errors.FirstOrDefault()?.Description ?? "Something went wrong"
                    )
                );
            }

            return Ok(ResponseUtil.Success(userProtected, "Register successful"));
        }
        catch (System.Exception e)
        {
            return Ok(ResponseUtil.Error(null, "Error: " + e.Message));
        }
    }
}
