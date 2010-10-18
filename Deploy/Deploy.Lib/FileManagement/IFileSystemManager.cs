using System.Collections.Generic;
using System.IO;

namespace Deploy.Lib.FileManagement
{
    public interface IFileSystemManager
    {
        bool FileExists(string path);
        bool DirectoryExists(string path);
        IEnumerable<string> FileAndFolderNamesIn(string path, string searchPattern = null);
        IEnumerable<string> FilenamesIn(string path, string searchPattern = null);
        IEnumerable<string> FoldernamesIn(string path, string searchPattern = null);
        DirectoryInfo CreateNewDirectory(string path);
        FileInfo CreateNewFile(string path);
        DirectoryInfo CreateTempDirectory();
        DirectoryMover MoveContentsOf(DirectoryInfo directory);
        DirectoryCopier CopyContentsOf(DirectoryInfo directory);
        void DeleteDirectory(DirectoryInfo directory);
    }
}