using CloudinaryDotNet.Actions;
using CloudinaryDotNet;
using Microsoft.Extensions.Options;
using racing_webApp.Helpers;
using racing_webApp.Inerfaces;

namespace racing_webApp.Servicess
{
    public class PhotoService : IphotoService
    {
        private readonly Cloudinary _cloundinary;

    public PhotoService(IOptions<CloudinarySettings> config)
    {
        var acc = new Account(
            config.Value.CloudName,
            config.Value.ApiKey,
            config.Value.ApiSecret
            );
        _cloundinary = new Cloudinary(acc);
    }

    public async Task<ImageUploadResult> AddphotoAsync(IFormFile file)
    {
        var uploadResult = new ImageUploadResult();
        if (file.Length > 0)
        {
            using var stream = file.OpenReadStream();
            var uploadParams = new ImageUploadParams
            {
                File = new FileDescription(file.FileName, stream),
                Transformation = new Transformation().Height(500).Width(500).Crop("fill").Gravity("face")
            };
            uploadResult = await _cloundinary.UploadAsync(uploadParams);
        }
        return uploadResult;
    }

    public async Task<DeletionResult> DeletephotoAsync(string publicUrl)
    {
        var publicId = publicUrl.Split('/').Last().Split('.')[0];
        var deleteParams = new DeletionParams(publicId);
        return await _cloundinary.DestroyAsync(deleteParams);
    }

    }

 }

