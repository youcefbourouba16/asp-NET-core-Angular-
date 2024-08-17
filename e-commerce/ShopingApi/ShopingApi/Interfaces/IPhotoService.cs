using CloudinaryDotNet.Actions;

namespace ShopingApi.Interfaces
{
    public interface IPhotoService
    {
        Task<ImageUploadResult> AddphotoAsync(IFormFile file);
        Task<DeletionResult> DeletephotoAsync(String publicUrl);
    }
}
