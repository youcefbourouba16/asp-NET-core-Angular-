using CloudinaryDotNet.Actions;

namespace racing_webApp.Inerfaces
{
    public interface IphotoService
    {
        Task<ImageUploadResult> AddphotoAsync(IFormFile file);
        Task<DeletionResult> DeletephotoAsync(String publicUrl);


    }
}
