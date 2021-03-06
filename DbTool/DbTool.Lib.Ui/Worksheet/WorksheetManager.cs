﻿using System.IO;
using DbTool.Lib.Configuration;
using DbTool.Lib.ExtensionMethods;
using DbTool.Lib.FileSystem;

namespace DbTool.Lib.Ui.Worksheet
{
    public class WorksheetManager : IWorksheetManager
    {
        private readonly IDbToolSettings _settings;
        private readonly IPathResolver _pathResolver;

        public WorksheetManager(IDbToolSettings settings, IPathResolver pathResolver)
        {
            _settings = settings;
            _pathResolver = pathResolver;
        }

        public void Save(string worksheetText)
        {
            using (var stream = TruncateOrCreateWorkSheetFile())
            {
                using (var writer = new StreamWriter(stream))
                {
                    writer.Write(worksheetText);
                    writer.Flush();
                }
            }
        }

        private FileStream TruncateOrCreateWorkSheetFile()
        {
            var worksheetPath = _pathResolver.GetFullPathOf(_settings.WorksheetFile);
            var fileMode = worksheetPath.Exists() ? FileMode.Truncate : FileMode.Create;
            return File.Open(worksheetPath, fileMode, FileAccess.Write);
        }

        public string Load()
        {
            var worksheetFile = _settings.WorksheetFile;
            if (!worksheetFile.Exists())
            {
                return string.Empty;
            }
            var worksheetPath = _pathResolver.GetFullPathOf(_settings.WorksheetFile);
            if (!worksheetPath.Exists())
            {
                return string.Empty;
            }
            using (var stream = File.OpenRead(worksheetPath))
            {
                using (var reader = new StreamReader(stream))
                {
                    return reader.ReadToEnd();
                }
            }
        }
    }
}