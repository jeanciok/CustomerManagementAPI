using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Transfer;
using CustomerManagement.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagament.Infrastructure.CloudServices
{
    public class FileStorageService : IFileStorageService
    {
        private readonly string _bucketName;
        private readonly AmazonS3Client _s3client;

        public FileStorageService(IConfiguration configuration)
        {
            AmazonS3Config config = new();
            config.ServiceURL = configuration["Storage:ServiceURL"];
            _bucketName = configuration["Storage:BucketName"];

            _s3client = new AmazonS3Client(configuration["Storage:AccessKeyId"], configuration["Storage:SecretAcessKey"], config);
        }

        public Dictionary<string, IFormFile> UploadFiles(List<IFormFile> files, string folder)
        {
            try
            {
                TransferUtility transferUtility = new(_s3client);

                Dictionary<string, IFormFile> filesUploaded = new();

                foreach (var file in files)
                {
                    var fileTransferUtilityRequest = new TransferUtilityUploadRequest
                    {
                        BucketName = _bucketName,
                        InputStream = file.OpenReadStream(),
                        Key = $"{folder}/{Guid.NewGuid()}.{MimeTypes.GetMimeTypeExtensions(file.ContentType).First()}",
                        CannedACL = S3CannedACL.PublicRead,
                    };

                    transferUtility.Upload(fileTransferUtilityRequest);

                    filesUploaded.Add(fileTransferUtilityRequest.Key, file);
                }


                return filesUploaded;
            }
            catch (AmazonS3Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task DeleteFileAsync(string filePath) 
        {
            DeleteObjectRequest request = new()
            {
                BucketName = _bucketName,
                Key = filePath
            };

            await _s3client.DeleteObjectAsync(request);
        }
    }
}
