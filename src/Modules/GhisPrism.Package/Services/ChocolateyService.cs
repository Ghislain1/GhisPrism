namespace GhisPrism.Package.Services
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using GhisPrism.Core;
    using GhisPrism.Core.Models;

    // using IFileSystem = chocolatey.infrastructure.filesystem.IFileSystem;

    public class ChocolateyService : IChocolateyService
    {
        private IChocolateyConfigSettingsService chocolateyConfigSettingsService;
        private IProgressService progressService;

        // IMapper mapper,
        public ChocolateyService(IProgressService progressService, IChocolateyConfigSettingsService chocolateyConfigSettingsService)
        {
            // TODO: Ghislae  this hsoukd be inject ion constructor. IXmlService xmlService,
            // IFileSystem fileSystem, IConfigService configService
            this.progressService = progressService ?? throw new ArgumentNullException(nameof(progressService));
            this.chocolateyConfigSettingsService = chocolateyConfigSettingsService ?? throw new ArgumentNullException(nameof(chocolateyConfigSettingsService));
        }

        public Task AddSource(ChocolateySource source)
        {
            throw new NotImplementedException();
        }

        public Task<Package> GetByVersionAndIdAsync(string id, string version, bool isPrerelease)
        {
            throw new NotImplementedException();
        }

        public Task<ChocolateyFeature[]> GetFeatures()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Package>> GetInstalledPackages()
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<Tuple<string, SemanticVersion>>> GetOutdatedPackages(bool includePrerelease = false, string packageName = null)
        {
            throw new NotImplementedException();
        }

        public Task<ChocolateySetting[]> GetSettings()
        {
            throw new NotImplementedException();
        }

        public Task<ChocolateySource[]> GetSources()
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

        public Task<PackageOperationResult> PinPackage(string id, string version)
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

        public Task SetFeature(ChocolateyFeature feature)
        {
            throw new NotImplementedException();
        }

        public Task SetSetting(ChocolateySetting setting)
        {
            throw new NotImplementedException();
        }

        public Task<PackageOperationResult> UninstallPackage(string id, string version, bool force = false)
        {
            throw new NotImplementedException();
        }

        public Task<PackageOperationResult> UnpinPackage(string id, string version)
        {
            throw new NotImplementedException();
        }

        public Task<PackageOperationResult> UpdatePackage(string id, Uri source = null)
        {
            throw new NotImplementedException();
        }

        public Task UpdateSource(string id, ChocolateySource source)
        {
            throw new NotImplementedException();
        }
    }
}