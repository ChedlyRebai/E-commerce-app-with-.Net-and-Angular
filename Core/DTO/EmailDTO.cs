using System;

namespace Core.DTO;

public class EmailDTO
{


    public string To { get; set; }
    public string From { get; set; }
    public string Subject { get; set; }

    public string Content { get; set; }
    public EmailDTO(string to, string from, string subject, string content)
    {
        this.To = to;
        this.From = from;
        this.Subject = subject;
        this.Content = content;
    }
    
}
