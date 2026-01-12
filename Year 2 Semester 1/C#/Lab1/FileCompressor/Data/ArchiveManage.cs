using SharpCompress.Compressors.Deflate;

namespace FileCompressor.Data
{
    interface ArchiveManage
    {
        void Archive(string pathFrom, string pathTo, CompressionLevel compressionLevel);
        void Extract(string pathFrom, string pathTo);
    }
}
