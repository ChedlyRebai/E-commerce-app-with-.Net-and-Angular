using System;
using Core.DTO;

namespace Core.Interfaces;

public interface IAuth
{

     Task<string> RegisterAsync(RegisterDTO registerDTO);
     Task SendEMail(string email, string code, string component, string subject, string message);
     Task<string> LoginAsync(LoginDTO loginDTO);

     Task<bool> SendEailForgetPassword(string email);

     Task<string> ConfirmEmailAsync(string email, string code);

     Task<string> ResetPassword(ResetPasswordDTO resetPasswordDTO);
    

     Task<bool> ActiveAccount(ActiveAccountDTO activeAccountDTO);
}
