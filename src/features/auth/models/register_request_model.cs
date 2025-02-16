public class RegisterRequestModel
{
    public required string Username { get; set; }
    public required string Password { get; set; }
    public required string Name { get; set; }
    public required string DocumentNumber { get; set; }
    public int PermissionId { get; set; }
}
