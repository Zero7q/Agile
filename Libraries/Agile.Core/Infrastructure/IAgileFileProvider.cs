using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agile.Core.Infrastructure
{
    public interface IAgileFileProvider : IFileProvider
    {
        bool DirectoryExists(string path);

        string[] GetFiles(string directoryPath, string searchPattern = "", bool topDirectoryOnly = true);

        string MapPath(string path);

        void CreateDirectory(string path);

        void DeleteFile(string filePath);

        string[] GetDirectories(string path, string searchPattern = "", bool topDirectoryOnly = true);

        void DeleteDirectory(string path);

        string GetDirectoryName(string path);

        string GetParentDirectory(string directoryPath);

        string GetDirectoryNameOnly(string path);

        string ReadAllText(string path, Encoding encoding);

        string GetFileName(string path);

        string Combine(params string[] paths);

        bool FileExists(string filePath);

        DateTime GetCreationTime(string path);

        void FileCopy(string sourceFileName, string destFileName, bool overwrite = false);

        void FileMove(string sourceFileName, string destFileName);

        string GetFileNameWithoutExtension(string filePath);

        void WriteAllText(string path, string contents, Encoding encoding);

        void SetLastWriteTimeUtc(string path, DateTime lastWriteTimeUtc);

        void CreateFile(string path);
    }
}
