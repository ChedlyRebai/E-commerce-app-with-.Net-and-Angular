using System;

namespace Core.DTO;


public record LoginDTO
{
    public string Email { get; set; }
    public string Password { get; set; }
}

public record ResetPasswordDTO:LoginDTO
{
    public string token { get; set; }
}
public record RegisterDTO : LoginDTO
{
    public string Username { get; set; }
    public string DisplayName { get; set; }

}

public record ActiveAccountDTO
{
    public string Email { get; set; }
    public string Token { get; set; }
}
