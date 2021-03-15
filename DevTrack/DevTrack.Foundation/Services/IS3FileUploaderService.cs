using System.Threading.Tasks;

namespace DevTrack.Foundation.Services
{
    public interface IS3FileUploaderService
    {
        Task UploadFile(string keyName, string filePath);
    }
}