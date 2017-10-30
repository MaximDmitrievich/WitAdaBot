using System.IO;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System.Configuration;

namespace TestBot
{
    public class StorageConnecting
    {
        private CloudStorageAccount _storageAccount;
        private CloudBlobClient _blobClient;
        private CloudBlobContainer _blobContainer;
        private CloudBlockBlob _blockBlobBlob;
        private MemoryStream _file;

        public CloudStorageAccount StorageAccount
        {
            private set
            {
                _storageAccount = value;
            }
            get
            {
                return _storageAccount;
            }
        }
        public CloudBlobClient BlobClient
        {
            private set
            {
                _blobClient = value;
            }
            get
            {
                return _blobClient;
            }
        }
        public CloudBlobContainer BlobContainer
        {
            private set
            {
                _blobContainer = value;
            }
            get
            {
                return _blobContainer;
            }
        }
        public CloudBlockBlob BlockBlobBlob
        {
            private set
            {
                _blockBlobBlob = value;
            }
            get
            {
                return _blockBlobBlob;
            }
        }

        public MemoryStream File
        {
            private set
            {
                _file = value;
            }
            get
            {
                return _file;
                
            }
        }

        public StorageConnecting() : this(null, null)
        {
            
        }

        public StorageConnecting(string container) : this(container, null)
        {

        }


        public StorageConnecting(string container, string file)
        {
            _storageAccount = CloudStorageAccount.Parse(ConfigurationManager.AppSettings["StorageConnectionString"]);
            _blobClient = _storageAccount.CreateCloudBlobClient();
            _blobContainer = _blobClient.GetContainerReference(container);
            //_blobContainer.SetPermissions(new BlobContainerPermissions { PublicAccess = BlobContainerPublicAccessType.Blob });
            _blockBlobBlob = _blobContainer.GetBlockBlobReference(file);
            _file = new MemoryStream();
            _blockBlobBlob.DownloadToStream(_file);
        }

        public string GetJSon()
        {
            string output = null;
            if (_file != null)
            {
                output = System.Text.Encoding.UTF8.GetString(_file.ToArray()); 
            }
            return output;
        }
    }
}