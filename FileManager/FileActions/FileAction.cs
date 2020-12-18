using System;
using System.IO;
using System.Threading;
using ConfigurationManager.Options;

namespace FileManager.FileActions
{
    public class FileAction
    {        
        FileSystemWatcher watcher;
        object obj = new object();
        bool enabled = true;
        FileActionOptions faOp = new FileActionOptions();
        public FileAction()
        {
            string sourcePath = faOp.sourceDirectoryPath;
            if (!Directory.Exists(sourcePath))
            {
                Directory.CreateDirectory(sourcePath);
            }
            // Create a new FileSystemWatcher and set its properties.
            watcher = new FileSystemWatcher(sourcePath, "*.xml");

            // Add event handlers
            watcher.Created += Watcher_Created;
            watcher.Renamed += Watcher_Created;
        }

        public void Start()
        {
            watcher.EnableRaisingEvents = true;
            while (enabled)
            {
                Thread.Sleep(1000);
            }
        }
        public void Stop()
        {
            watcher.EnableRaisingEvents = false;
            enabled = false;
        }

        // создание файлов
        private void Watcher_Created(object sender, FileSystemEventArgs e)
        {
            string sourcePath = faOp.sourceDirectoryPath;
            string targetPath = faOp.targetDirectoryPath;
            string tarArchivePath = faOp.targetArchivePath;

            string path = e.FullPath;

            try
            {
                // определения времени создания файла, создание поддиректории archive\YYYY\MM\DD\ 
                DateTime date = File.GetCreationTime(path);
                string subPath = "";
                subPath = subPath + date.Year + '\\' + date.Month + '\\' + date.Day + '\\';
                DirectoryInfo directory = new DirectoryInfo(tarArchivePath);
                if (!directory.Exists)
                {
                    directory.Create();
                }
                directory.CreateSubdirectory(subPath);
                // зашифровка файла, архивирование, перемещение в TargetDirectory, удаление из SourceDirectory
                Encoder.Encrypt(path);
                string tarPath = path.Replace(sourcePath, targetPath);
                tarPath = tarPath.Replace(".xml", ".gz");
                Archiver.Compress(path, tarPath);
                File.Delete(path);
                // разархивация файла, расшифровывание
                string archivePath = tarPath.Replace(".gz", ".xml");
                archivePath = archivePath.Replace(targetPath, tarArchivePath + "\\" + subPath);
                Archiver.Decompress(tarPath, archivePath);
                Encoder.Decrypt(archivePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
