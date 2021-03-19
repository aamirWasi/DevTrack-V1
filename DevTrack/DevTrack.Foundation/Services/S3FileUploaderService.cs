using Amazon.S3;
using Amazon.S3.Model;
using System;
using System.Threading.Tasks;
using DevTrack.Foundation.Services.Interfaces;

namespace DevTrack.Foundation.Services
{
    public class S3FileUploaderService : IS3FileUploaderService
    {
        const string bucketName = "aspnet-b4team2";

        public async Task UploadFile(string keyName, string filePath)
        {
            try
            {
                using var client = new AmazonS3Client(Amazon.RegionEndpoint.USEast1);
                var putRequest = new PutObjectRequest
                {
                    BucketName = bucketName,
                    Key = keyName,
                    FilePath = filePath
                };

                var response = await client.PutObjectAsync(putRequest);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Could not upload file in bucket properly",ex.InnerException);
            }
        }
    }
}