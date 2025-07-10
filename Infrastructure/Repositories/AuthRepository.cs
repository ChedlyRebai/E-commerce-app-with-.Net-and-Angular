using System;
using Core.DTO;
using Core.Entities;
using Core.Interfaces;
using Core.Services;
using Core.Shared;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity; // Ensure this using is present for SignInManager

namespace Infrastructure.Repositories;

public class AuthRepository : IAuth
{
    private readonly UserManager<AppUser> _userManager;
    private readonly IEmailService _emailService;
    private readonly SignInManager<AppUser> _signInManager;
    private readonly IGenerateToken generateToken;
    public AuthRepository(UserManager<AppUser> userManager, IEmailService emailService, SignInManager<AppUser> signInManager, IGenerateToken token)
    {
        _userManager = userManager;
        _emailService = emailService;
        _signInManager = signInManager;
        generateToken = token;
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
        string code = _userManager.GenerateEmailConfirmationTokenAsync(user).Result;

        await SendEMail(user.Email, code, "ACTIVE", "Active Email", "active your email");
        return "done";
    }
    // Implement methods for authentication, registration, etc. using _userManager
    // Example:
    // public async Task<IdentityResult> RegisterAsync(AppUser user, string password)
    // {
    //     return await _userManager.CreateAsync(user, password);
    // }

    public async Task SendEMail(string email, string code, string component, string subject, string message)
    {
        var result = new EmailDTO(email, "chedly.rebai123@gmail.com",
        subject, EmailBody.send(email, code, component));
        await _emailService.SendEmail(result);

    }

    public async Task<string> LoginAsync(LoginDTO loginDTO)
    {
        if (loginDTO == null)
        {
            return null;

        }

        var findUser = await _userManager.FindByEmailAsync(loginDTO.Email);
        if (!findUser.EmailConfirmed)
        {
            string token = await _userManager.GenerateEmailConfirmationTokenAsync(findUser);
            await SendEMail(findUser.Email, token, "ACTIVE", "Active Email", "active your email");
            return "Please confirm your email first";
        }

        var result = await _signInManager.CheckPasswordSignInAsync(findUser, loginDTO.Password, false);

        if (!result.Succeeded)
        {
            return "Invalid email or password";
        }
        else
        {
            return generateToken.GetAndCreateToken(findUser).Result;
        }
    }

    public async Task<bool> SendEailForgetPassword(string email)
    {
        var user = await _userManager.FindByEmailAsync(email);
        if (user is null)
        {
            return false;
        }
        var token = await _userManager.GeneratePasswordResetTokenAsync(user);
        await SendEMail(user.Email, token, "FORGET_PASSWORD", "Reset Password", "Click here to reset your password");
        return true;
    }

    public async Task<string> ConfirmEmailAsync(string email, string code)
    {
        var user = await _userManager.FindByEmailAsync(email);
        if (user == null)
        {
            return "User not found";
        }

        var result = await _userManager.ConfirmEmailAsync(user, code);
        if (result.Succeeded)
        {
            return "Email confirmed successfully";
        }
        else
        {
            return "Error confirming email: " + string.Join(", ", result.Errors.Select(e => e.Description));
        }
    }

    public async Task<string> ResetPassword(ResetPasswordDTO resetPasswordDTO)
    {
        var findUser = await _userManager.FindByEmailAsync(resetPasswordDTO.Email);
        if (findUser == null)
        {
            return "User not found";
        }

        var result = await _userManager.ResetPasswordAsync(findUser, resetPasswordDTO.token, resetPasswordDTO.Password);

        if (result.Succeeded)
        {
            return "Password reset successfully";
        }
        else
        {
            return "error resetting password: " + string.Join(", ", result.Errors.Select(e => e.Description));
        }
    }

    public async Task<bool> ActiveAccount(ActiveAccountDTO activeAccountDTO)
    {
        var user = await _userManager.FindByEmailAsync(activeAccountDTO.Email);
        Console.WriteLine("user: " + activeAccountDTO);
        if (user is null)
        {
            return false;
        }

        var result = await _userManager.ConfirmEmailAsync(user, activeAccountDTO.Token);
        if (result.Succeeded)
        {
            return true;
        }
        var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
        Console.WriteLine("Is confirmed: " + user.EmailConfirmed);
        Console.WriteLine("Token: " + token);
        if (!string.IsNullOrEmpty(user.Email))
        {
            Console.WriteLine("Sending email to: " + user.Email);
            await SendEMail(user.Email, token, "ACTIVE", "Active Email", "active your email");
        }
        return false;
    }
}