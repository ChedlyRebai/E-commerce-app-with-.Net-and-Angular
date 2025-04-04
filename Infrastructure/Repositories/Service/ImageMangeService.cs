using System;
using Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.FileProviders;

namespace Infrastructure.Repositories.Service;

public class ImageMangeService : IImageMangeService
{
    private readonly IFileProvider _fileProvider;
    public ImageMangeService(IFileProvider fileProvider)
    {
        this._fileProvider=fileProvider;
    }
    public async Task<List<string>> AddImageAsync(IFormFileCollection files, string src)
    {
        var SaveImageSrc= new List<string>();
        var ImageDirectory = Path.Combine("wwwroot","Images", src);
        if(Directory.Exists(ImageDirectory) is not true ){
            Directory.CreateDirectory(ImageDirectory);
        }
        foreach (var item in files)
        {
            if(item.Length > 0){
                //getImage NAme
                var ImageName = item.FileName;
                var ImagePath =$"Images/{src}/{ImageName}";
                var root =Path.Combine(ImageDirectory, ImageName);
                using(FileStream strem=new FileStream(root, FileMode.Create)){
                    await item.CopyToAsync(strem);
                }
                SaveImageSrc.Add(ImagePath);
            }
        }
        return SaveImageSrc;
    }

    public void DeleteImageAsync(string src, string fileName)
    {
        var info=_fileProvider.GetFileInfo(src);
        var root=info.PhysicalPath;
        File.Delete(root);
    }
}
