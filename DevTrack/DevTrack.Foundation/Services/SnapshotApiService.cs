using DevTrack.Foundation.Entities;
using System;
using System.IO;
using System.Net.Http;

namespace DevTrack.Foundation.Services
{
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