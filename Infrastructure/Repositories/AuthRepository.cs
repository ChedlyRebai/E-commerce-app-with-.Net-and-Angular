using System;
using Core.DTO;
using Core.Entities;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Repositories;

public class AuthRepository
{
    private readonly UserManager<AppUser> _userManager;

    public AuthRepository(UserManager<AppUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<string> RegisterAsync(RegisterDTO registerDTO)
    {
        if (registerDTO == null)
        {
            return null;
        }
        if (await _userManager.FindByNameAsync(registerDTO.Username) is not null)
        {
            return "this username is already exist";
        }

        if (await _userManager.FindByEmailAsync(registerDTO.Email) is not null)
        {
            return "This Email is already exist";
        }

        AppUser user = new AppUser()
        {
            UserName = registerDTO.Username,
            Email = registerDTO.Email,
            DisplayName = registerDTO.Username // Assuming DisplayName is the same as Username
        };

        var result = await _userManager.CreateAsync(user, registerDTO.Password);


        if (result.Errors.Any())
        {
            return string.Join(", ", result.Errors.Select(e => e.Description));
        }

        
        return "User registered successfully";
    }
    // Implement methods for authentication, registration, etc. using _userManager
    // Example:
    // public async Task<IdentityResult> RegisterAsync(AppUser user, string password)
    // {
    //     return await _userManager.CreateAsync(user, password);
    // }
}
