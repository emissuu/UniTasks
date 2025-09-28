using System.IO;
using System.Windows;
using SharpCompress.Archives;
using SharpCompress.Archives.Zip;
using SharpCompress.Common;
using SharpCompress.Compressors.Deflate;
using SharpCompress.Readers;

namespace FileCompressor.Data
{
    public class ManageZip : ArchiveManage
    {
        public void Archive(string pathFrom, string pathTo, CompressionLevel compressionLevel)
        {
            try
            {
                using (var archive = ZipArchive.Create())
                {
                    archive.DeflateCompressionLevel = compressionLevel;
                    if (File.Exists(pathFrom))
                    {
                        using (var fileStream = File.Open(pathFrom, FileMode.Open))
                        {
                            archive.AddEntry(Path.GetFileName(pathFrom), fileStream);
                            archive.SaveTo(pathTo + '\\' + Path.GetFileName(pathFrom) + ".zip", CompressionType.Deflate);
                        }
                    }
                }
                MessageBox.Show("Archive created successfully!", "Archivator", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception e)
            {
                MessageBox.Show("Error occured:\n" + e.ToString());
            }
        }

        public void Extract(string pathFrom, string pathTo)
        {
            try {
                using (var archive = ZipArchive.Open(pathFrom))
                using (var reader = archive.ExtractAllEntries())
                {
                    reader.WriteAllToDirectory(pathTo, new ExtractionOptions()
                    {
                        ExtractFullPath = true,
                        Overwrite = true
                    });
                }
                MessageBox.Show("Archive extracted successfully!", "Archivator", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception e)
            {
                MessageBox.Show("Error occured:\n" + e.ToString());
            }
        }
    }
}
