
namespace ConfigurationManager.Options
{
    public class FileActionOptions
    {
        public string sourceDirectoryPath;
        public string targetDirectoryPath;        
        public string targetArchivePath;

        public FileActionOptions()
        {
            DefaultOptions defOp = new DefaultOptions();
            defOp = new Manager().GetOptions();
            sourceDirectoryPath = defOp.sourceDirectoryPath;
            targetDirectoryPath = defOp.targetDirectoryPath;
            targetArchivePath = defOp.targetArchivePath;
        }
    }
}
