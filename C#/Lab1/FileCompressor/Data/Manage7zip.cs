using SharpCompress.Compressors.Deflate;

namespace FileCompressor.Data
{
    public class Manage7zip : ArchiveManage
    {
        // Not supported by SharpCompress and learning new library will take a lot of time... 
        public void Archive(string pathFrom, string pathTo, CompressionLevel compressionLevel)
        {
            throw new NotImplementedException();
        }

        public void Extract(string pathFrom, string pathTo)
        {
            throw new NotImplementedException();
        }
    }
}
