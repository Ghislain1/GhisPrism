namespace GhisPrism.Core.Services
{
  using System;
  using System.Collections.Generic;
  using GhisPrism.Core.Models;
  using System.IO;
  using System.Linq;

  public class FileItemService : IFileItemService
  {
    public List<FileItem> GetDirectoryContents(string fullPath)
    {
      // Create empty list
      var items = new List<FileItem>();

      // Try and get directories from the folder ignoring any issues doing so
      try
      {
        var dirs = Directory.GetDirectories(fullPath);

        if (dirs.Length > 0)
          items.AddRange(dirs.Select(dir => new FileItem { FullPath = dir, Type = FileItemType.Folder }));
      }
      catch { }

      // Try and get files from the folder ignoring any issues doing so
      try
      {
        var fs = Directory.GetFiles(fullPath);

        if (fs.Length > 0)
          items.AddRange(fs.Select(file => new FileItem { FullPath = file, Type = FileItemType.File }));
      }
      catch { }

      return items;
    }

    /// <summary>
    /// Find the file or folder name from a full path
    /// </summary>
    /// <param name="path">The full path</param>
    /// <returns></returns>
    public string GetFileFolderName(string path)
    {
      // If we have no path, return empty
      if (string.IsNullOrEmpty(path))
        return string.Empty;

      // Make all slashes back slashes
      var normalizedPath = path.Replace('/', '\\');

      // Find the last backslash in the path
      var lastIndex = normalizedPath.LastIndexOf('\\');

      // If we don't find a backslash, return the path itself
      if (lastIndex <= 0)
        return path;

      // Return the name after the last back slash
      return path.Substring(lastIndex + 1);
    }

    /// <summary>
    /// </summary>
    /// <returns></returns>
    public List<FileItem> GetLogicalDrives()
    {
      var drivers = Directory.GetLogicalDrives();
      return drivers.Select(drive => new FileItem
      {
        FullPath = drive,
        Type = FileItemType.Drive
      }).ToList();
    }
  }
}