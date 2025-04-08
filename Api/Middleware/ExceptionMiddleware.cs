using System;
using System.Net;
using System.Text.Json;
using Api.Helper;
using Org.BouncyCastle.Ocsp;

namespace Api.Middleware;

public class ExceptionMiddleware
{
    private readonly IHostEnvironment _environment;
    private readonly RequestDelegate _next;
    public ExceptionMiddleware(RequestDelegate next,IHostEnvironment environment){
        _next = next;
        _environment=environment;
    }

    public async Task InvokeAsync(HttpContext context){
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            context.Response.StatusCode=(int)HttpStatusCode.InternalServerError;
            context.Response.ContentType="application/json";
            
            var response = _environment.IsDevelopment() ?
             new ApiException((int)HttpStatusCode.InternalServerError,ex.Message,ex.StackTrace)
             : new ApiException((int)HttpStatusCode.InternalServerError);
            var json = JsonSerializer.Serialize(response);
            await context.Response.WriteAsync(json);
        }
    }

}   
