using System;

namespace Api.Helper;

public class ResponseAPI
{
    public ResponseAPI(int statusCode,string message=null)
    {
        this.StatusCode=statusCode;
        this.Message=message ?? GetMessageFormStatusCode(statusCode);
    }

    private string GetMessageFormStatusCode(int statuscode){
        return statuscode switch{
            200 => "Success",
            201 => "Created",
            204 => "No content",
            400 => "Bad request",
            401 => "Unauthorized",
            403 => "Forbidden",
            404 => "Not found",
            500 => "Internal server error",
            _ => "Unknown error"
        };
    }
    public int StatusCode { get; set; } 
    public string? Message { get; set; } 
}

