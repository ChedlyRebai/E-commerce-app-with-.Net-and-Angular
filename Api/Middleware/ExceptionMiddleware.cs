using System;
using System.Net;
using System.Text.Json;
using Api.Helper;
using Org.BouncyCastle.Ocsp;

namespace Api.Middleware;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    public ExceptionMiddleware(RequestDelegate next){
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context){
        try
        {
            
        }
        catch (Exception ex)
        {
            context.Response.StatusCode=(int)HttpStatusCode.InternalServerError;
            context.Response.ContentType="application/json";
            var response=new ApiException((int)HttpStatusCode.InternalServerError,ex.Message,ex.StackTrace);
            var json = JsonSerializer.Serialize(response);
            await context.Response.WriteAsync(json);
        }
    }

}   
