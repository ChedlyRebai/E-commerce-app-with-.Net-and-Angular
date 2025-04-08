using System;
using System.Net;
using System.Text.Json;
using Api.Helper;
using Microsoft.Extensions.Caching.Memory;
using Org.BouncyCastle.Ocsp;

namespace Api.Middleware;

public class ExceptionMiddleware
{
    private readonly IHostEnvironment _environment;
    private readonly RequestDelegate _next;
    private readonly IMemoryCache _cache;
    public readonly TimeSpan _rateLimitWindow = TimeSpan.FromSeconds(20);
    public ExceptionMiddleware(RequestDelegate next, IHostEnvironment environment, IMemoryCache cache)
    {
        _next = next;
        _environment = environment;
        _cache = cache;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            
            if(IsRequestAllowed(context) == false){
                context.Response.StatusCode = (int)HttpStatusCode.TooManyRequests;
                context.Response.ContentType = "application/json";
                var response = new ApiException((int)HttpStatusCode.TooManyRequests, "Rate limit exceeded", "You have exceeded the number of requests allowed. Please try again later.");
                await context.Response.WriteAsJsonAsync(response);
            }   
            await _next(context);
        }
        catch (Exception ex)
        {
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Response.ContentType = "application/json";

            var response = _environment.IsDevelopment() ?
             new ApiException((int)HttpStatusCode.InternalServerError, ex.Message, ex.StackTrace)
             : new ApiException((int)HttpStatusCode.InternalServerError);
            var json = JsonSerializer.Serialize(response);
            await context.Response.WriteAsync(json);
        }
    }

    private bool IsRequestAllowed(HttpContext context)
    {
        var ip = context.Connection.RemoteIpAddress;
        var cachKey = $"Rate:{ip}";
        var dateNow = DateTime.Now;
        Console.WriteLine("Request Path: " + context.Request.Path);
        var (timesTamp, count) = _cache.GetOrCreate(cachKey, entry =>
        {

            entry.AbsoluteExpirationRelativeToNow = _rateLimitWindow;
            return (timesTamp: dateNow, count: 0);
        });

        if (dateNow - timesTamp < _rateLimitWindow)
        {
            if (count > 6)
            {
                return false;
            }
            _cache.Set(cachKey, (timesTamp, count += 1), _rateLimitWindow);

        }
        else
        {
            _cache.Set(cachKey, (dateNow, 1), _rateLimitWindow);
        }
        return true; 
    }

}
