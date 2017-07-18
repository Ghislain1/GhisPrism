namespace GhisPrism.Core.Models
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Text;
  using System.Threading.Tasks;

  /// <summary>
  /// Information about a file item such as a drive, a file or a folder
  /// </summary>
  public class FileItem
  {
    /// <summary>
    /// The absolute path to this item
    /// </summary>
    public string FullPath { get; set; }

    /// <summary>
    /// The name of this directory item
    /// </summary>
    public string Name
    {
      get
      {
        return this.Type == FileItemType.Drive ? this.FullPath : this.GetFileFolderName(this.FullPath);
      }
    }

    /// <summary>
    /// The type of this item
    /// </summary>
    public FileItemType Type { get; set; }

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
  }
}