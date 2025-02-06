using Amazon;
using Amazon.Runtime;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Transfer;
using CustomerManagement.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace CustomerManagament.Infrastructure.CloudServices
{
    public class FileStorageService : IFileStorageService
    {
        private readonly string _bucketName;
        private readonly AmazonS3Client _s3client;

        public FileStorageService(IConfiguration configuration)
        {
            AmazonS3Config config = new AmazonS3Config
            {
                ServiceURL = configuration["Storage:ServiceURL"],
                ForcePathStyle = true,
                SignatureVersion = "4",
                RequestChecksumCalculation = RequestChecksumCalculation.WHEN_REQUIRED,
                ResponseChecksumValidation = ResponseChecksumValidation.WHEN_REQUIRED
            };

            _bucketName = configuration["Storage:BucketName"];

            _s3client = new AmazonS3Client(
                configuration["Storage:AccessKeyId"],
                configuration["Storage:SecretAccessKey"],
                config
            );
        }

        public async Task<Dictionary<string, IFormFile>> UploadFilesAsync(List<IFormFile> files, string folder)
        {
            try
            {
                var filesUploaded = new Dictionary<string, IFormFile>();

                foreach (var file in files)
                {
                    using var stream = file.OpenReadStream();

                    var request = new PutObjectRequest
                    {
                        DisablePayloadSigning = true,
                        UseChunkEncoding = false,    
                        BucketName = _bucketName,
                        Key = $"{folder}/{Guid.NewGuid()}{Path.GetExtension(file.FileName)}",
                        InputStream = stream,
                        ContentType = file.ContentType,
                        Headers = { ContentLength = stream.Length }
                    };

                    await _s3client.PutObjectAsync(request);
                    filesUploaded.Add(request.Key, file);
                }

                return filesUploaded;
            }
            catch (AmazonS3Exception ex)
            {
                throw new Exception($"Erro S3: {ex.Message}");
            }
        }

        public async Task DeleteFileAsync(string filePath)
        {
            var request = new DeleteObjectRequest
            {
                BucketName = _bucketName,
                Key = filePath
            };

            await _s3client.DeleteObjectAsync(request);
        }
    }
}
