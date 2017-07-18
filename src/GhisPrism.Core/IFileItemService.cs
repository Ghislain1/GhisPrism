using GhisPrism.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhisPrism.Core
{
  /// <summary>
  /// A Service class to query information about file such as folder driver , or file.
  /// </summary>
  public interface IFileItemService
  {
    /// <summary>
    /// </summary>
    /// <param name="fullPath"></param>
    /// <returns></returns>
    List<FileItem> GetDirectoryContents(string fullPath);

    /// <summary>
    /// Find the file or folder name from a full path
    /// </summary>
    /// <param name="path">The full path</param>
    /// <returns></returns>
    string GetFileFolderName(string path);

    /// <summary>
    /// Gets all logical drives on the computer
    /// </summary>
    /// <returns></returns>
    List<FileItem> GetLogicalDrives();
  }
}