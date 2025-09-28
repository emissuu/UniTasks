using SharpCompress.Common;
using System.IO;
using System.Windows;
using SharpCompress.Archives;
using SharpCompress.Archives.Tar;
using SharpCompress.Compressors.Deflate;
using SharpCompress.Readers;

namespace FileCompressor.Data
{
    public class ManageTar : ArchiveManage
    {
        public void Archive(string pathFrom, string pathTo, CompressionLevel compressionLevel)
        {
            try
            {
                using (var archive = TarArchive.Create())
                {
                    if (File.Exists(pathFrom))
                    {
                        using (var fileStream = File.Open(pathFrom, FileMode.Open))
                        {
                            archive.AddEntry(Path.GetFileName(pathFrom), fileStream);
                            archive.SaveTo(pathTo + '\\' + Path.GetFileName(pathFrom) + ".tar", new(CompressionType.None));
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
            try
            {
                using (var archive = TarArchive.Open(pathFrom))
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
