using DevTrack.Foundation.UnitOfWorks;
using System;
using DevTrack.Foundation.Entities;
using System.Net.Http;
using System.IO;

namespace DevTrack.Foundation.Services
{
    public class SnapShotWebService : ISnapShotWebService
    {
        private readonly ISnapshotWebUnitOfWork _snapshotWebUnitOfWork;

        public SnapShotWebService(ISnapshotWebUnitOfWork snapshotWebUnitOfWork)
        {
            _snapshotWebUnitOfWork = snapshotWebUnitOfWork;
        }

        public void SaveSnapShotWebDb(SnapshotImage image)
        {
            if (image == null)
            {
                throw new InvalidOperationException("Image information is  missing");
            }
            else
            {
                _snapshotWebUnitOfWork.SnapshotWebRepository.Add(image);
                _snapshotWebUnitOfWork.Save();
            }
        }

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