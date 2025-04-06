using System;
using Microsoft.AspNetCore.Http;


namespace Core.Services;

public interface IImageMangeService
{
    Task<List<string>> AddImageAsync(IFormFileCollection files, string src);
    void DeleteImageAsync(string src, string fileName=null);
}
