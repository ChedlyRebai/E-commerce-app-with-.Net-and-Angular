using System;

namespace Core.Shared;

public class EmailBody
{
    public static string send(string email, string token,string message)
    {
        string encodedToken =Uri.EscapeDataString(token);
        return $@"
            <html>
                <body>
                    <h1>{message}</h1>
                    <a href='http://localhost:4200/verify?email={email}&token={encodedToken}'>Verify Email</a>
                    <p>If you did not register, please ignore this email.</p>
                </body>
            </html>";
    }
}
