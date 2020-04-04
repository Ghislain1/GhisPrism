using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using GhisPrism.Core;
using GhisPrism.Core.Models;
using GhisPrism.Core.Services;
using static System.Environment;

namespace GhisPrism.Package.Services
{
    public class GhisSpecialFolderService : IGhisSpecialFolderService
    {
        private List<SpecialFolder> sources = new List<SpecialFolder>();

        public Task AddSource(Environment.SpecialFolder source)
        {
            sources.Add(source);
            return Task.CompletedTask;
        }

        public Task<Core.Models.Package> GetByVersionAndIdAsync(string id, string version, bool isPrerelease)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Core.Models.Package>> GetInstalledPackages()
        {
            if (!sources.Any())
            {
                sources.Add(SpecialFolder.Desktop);
            }

            var result = new List<Core.Models.Package>();
            var fileItemService = new FileItemService();
            var collection = await Task.Run(() =>
            {
                Console.WriteLine("Task runnin");
                try
                {
                    var list = new List<FileItem>();
                    sources.ForEach(item =>
                    {
                        var fullPath = Environment.GetFolderPath(item);
                        list.AddRange(fileItemService.GetDirectoryContents(fullPath));
                    });

                    return list;
                }
                catch (Exception)
                {
                    throw;
                }
            });

            collection.ForEach(item => result.Add(this.CreatePackage(item)));

            return result;
        }

        public Task<IReadOnlyList<Tuple<string, SemanticVersion>>> GetOutdatedPackages(bool includePrerelease = false, string packageName = null)
        {
            throw new NotImplementedException();
        }

        public Task<Environment.SpecialFolder[]> GetSources()
        {
            throw new NotImplementedException();
        }

        public Task<PackageOperationResult> InstallPackage(string id, string version = null, Uri source = null, bool force = false)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsElevated()
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveSource(string id)
        {
            throw new NotImplementedException();
        }

        public Task<PackageResults> Search(string query, PackageSearchOptions options)
        {
            throw new NotImplementedException();
        }

        public Task<PackageOperationResult> UninstallPackage(string id, string version, bool force = false)
        {
            throw new NotImplementedException();
        }

        public Task<PackageOperationResult> UpdatePackage(string id, Uri source = null)
        {
            throw new NotImplementedException();
        }

        public Task UpdateSource(string id, Environment.SpecialFolder source)
        {
            throw new NotImplementedException();
        }

        private Core.Models.Package CreatePackage(FileItem item)
        {
            var result = new Core.Models.Package();
            result.Id = item.FullPath;
            var fileInfo = new FileInfo(item.FullPath);
            result.IsLatestVersion = fileInfo.IsReadOnly;
            return result;
        }
    }
}