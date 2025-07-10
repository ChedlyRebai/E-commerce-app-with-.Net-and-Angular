using System;
using Core.DTO;

namespace Core.Services;

public interface IEmailService
{
    Task SendEmail(EmailDTO emailDTO);
}
