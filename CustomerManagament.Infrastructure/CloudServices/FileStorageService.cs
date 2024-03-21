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

        public string UploadFile(IFormFile file, string filePath)
        {
            try
            {
                TransferUtility transferUtility = new(_s3client);

                var fileTransferUtilityRequest = new TransferUtilityUploadRequest
                {
                    BucketName = _bucketName,
                    InputStream = file.OpenReadStream(),
                    Key = $"{filePath}/{file.FileName}",
                    CannedACL = S3CannedACL.PublicRead,
                };

                transferUtility.Upload(fileTransferUtilityRequest);

            }
            catch (AmazonS3Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return file.FileName;
        }
    }
}
