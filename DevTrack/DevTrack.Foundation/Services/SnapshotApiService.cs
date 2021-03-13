using Amazon.S3;
using Amazon.S3.Model;
using DevTrack.Foundation.Entities;
using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace DevTrack.Foundation.Services
{
    public class S3FileUploaderService : IS3FileUploaderService
    {
        private readonly string bucketName = "aamir-bucket1";

        public async Task UploadFile(string keyName, string filePath)
        {
            try
            {
                using (var client = new AmazonS3Client(Amazon.RegionEndpoint.USEast1))
                {
                    var putRequest = new PutObjectRequest
                    {
                        BucketName = bucketName,
                        Key = keyName,
                        FilePath = filePath,
                        ContentType = "text/plain"
                    };

                    var response = await client.PutObjectAsync(putRequest);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
    public class SnapshotApiService : ISnapshotApiService
    {
        public string SaveSnapshotInSql(SnapshotImage imageEntity)
        {
            var finalResult = string.Empty;
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri("https://localhost:44332/");

                var file_bytes = File.ReadAllBytes(imageEntity.FilePath);

                var form = new MultipartFormDataContent();
                form.Add(new StringContent(imageEntity.CaptureTime.ToString("yyyy-MM-dd h:mm tt")), "CaptureTime");
                form.Add(new ByteArrayContent(file_bytes, 0, file_bytes.Length), "FilePath", "file.jpeg");
                using (var response = httpClient.PostAsync("api/Snapshot", form).Result)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        using var content = response.Content;
                        var result = content.ReadAsStringAsync();
                        finalResult = result.Result;
                    }
                }
            }
            return finalResult;
        }
    }
}