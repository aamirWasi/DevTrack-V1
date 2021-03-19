using System;
using DevTrack.Foundation.Entities;
using System.Net.Http;
using System.IO;

namespace DevTrack.Foundation.Adapters
{
    public class SnapShotWebAdapterService : ISnapShotWebAdapterService
    {
        public string WebHttpResponse(SnapshotImage imageEntity)
        {
            var finalResult = string.Empty;
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri("https://localhost:44332/");

                var file_bytes = File.ReadAllBytes(imageEntity.FilePath);

                var form = new MultipartFormDataContent
                {
                    { new StringContent(imageEntity.CaptureTime.ToString("yyyy-MM-dd h:mm tt")), "CaptureTime" },
                    { new ByteArrayContent(file_bytes, 0, file_bytes.Length), "FilePath", "file.jpeg" }
                };

                using var response = httpClient.PostAsync("api/Snapshot", form).Result;
                if (response.IsSuccessStatusCode)
                {
                    using var content = response.Content;
                    var result = content.ReadAsStringAsync();
                    finalResult = result.Result;
                }
            }

            return finalResult;
        }
    }
}