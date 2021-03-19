using System;
using DevTrack.Foundation.Entities;
using System.Net.Http;
using System.IO;

namespace DevTrack.Foundation.Adapters
{
    public class WebCamCaptureAdapterService : IWebCamCaptureAdapterService
    {
        public string WebHttpResponse(WebCamCaptureImage imageEntity)
        {
            var finalResult = string.Empty;
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri("https://localhost:44332/");

                var file_bytes = File.ReadAllBytes(imageEntity.WebCamImagePath);

                var form = new MultipartFormDataContent
                {
                    { new StringContent(imageEntity.WebCamImageDateTime.ToString("yyyy-MM-dd h:mm tt")), "CaptureTime" },
                    { new ByteArrayContent(file_bytes, 0, file_bytes.Length), "FilePath", "file.jpeg" }
                };

                using var response = httpClient.PostAsync("api/WebCamCapture", form).Result;
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