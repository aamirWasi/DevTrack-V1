using System.Threading.Tasks;

namespace DevTrack.Foundation.Services.Interfaces
{
    public interface IS3FileUploaderService
    {
        Task UploadFile(string keyName, string filePath);
    }
}