using System.IO;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;

namespace FileServer.Service
{
    public class AzureFileService : IFileService
    {
        // Retrieve storage account from connection string.
        CloudStorageAccount storageAccount;

        // Create the blob client.
        CloudBlobClient blobClient;

        // Retrieve reference to a previously created container.
        CloudBlobContainer container;

        public AzureFileService()
        {
            var storageString = "DefaultEndpointsProtocol=https;AccountName=prabastorage;AccountKey=+r4M9ty/rhr87+/ENIM68h+kYAARKt79P00P/KnScsluo/ANgHb9oB96XQlPqHuX/mi6oQVggKwQq2Wp2vmqAg==";
            storageAccount = CloudStorageAccount.Parse(storageString);
            blobClient = storageAccount.CreateCloudBlobClient();
            container = blobClient.GetContainerReference("tekionuploads");
            container.CreateIfNotExists();
            container.SetPermissions(new BlobContainerPermissions { PublicAccess = BlobContainerPublicAccessType.Container });
        }

        public void Upload(string fileName, Stream stream)
        {
            CloudBlockBlob blockBlob = container.GetBlockBlobReference(fileName);
            blockBlob.UploadFromStream(stream);
        }
    }
}