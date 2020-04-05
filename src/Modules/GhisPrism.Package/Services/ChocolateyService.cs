namespace GhisPrism.Package.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using chocolatey;
    using chocolatey.infrastructure.app.domain;
    using chocolatey.infrastructure.app.services;
    using chocolatey.infrastructure.results;
    using GhisPrism.Core;
    using GhisPrism.Core.Models;

    public class ChocolateyService : IChocolateyService
    {
        private readonly GetChocolatey chocolatey;

        public ChocolateyService()
        {
            this.chocolatey = Lets.GetChocolatey();
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

        public async Task<IEnumerable<Package>> GetInstalledPackages()
        {
            IEnumerable<Package> result = null;
            this.chocolatey.Set(
                 configuraion =>
                 {
                     configuraion.CommandName = CommandNameType.list.ToString();
                     configuraion.ListCommand.LocalOnly = true;
                 });

            var chocoConfig = this.chocolatey.GetConfiguration();

            if (chocoConfig.Sources != null)
            {
                var packages = await Task.Run(() => this.chocolatey.List<PackageResult>());
                return packages.Select(package => this.CreatePackage(package)).ToArray();
            }
            else
            {
                return result;
            }
        }

        public Task<IReadOnlyList<Tuple<string, string>>> GetOutdatedPackages(bool includePrerelease = false, string packageName = null)
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

        private Package CreatePackage(PackageResult packageResult)
        {
            if (packageResult == null)
            {
                return null;
            }
            var packageInfoService = this.chocolatey.Container().GetInstance<IChocolateyPackageInformationService>();
            var result = new Package()
            {
                Summary = packageResult.Package.Summary,
                Title = packageResult.Package.Title,
                // ReportAbuseUrl = packageResult.Package.ReportAbuseUrl.AbsoluteUri
                Tags = packageResult.Package.Tags,
                Language = packageResult.Package.Language,
                PackageSize = packageResult.Package.PackageSize,
                Authors = packageResult.Package.Authors.ToArray(),
                Copyright = packageResult.Package.Copyright,
                Dependencies = packageResult.ToString(),
                // IconUrl = packageResult.Package.IconUrl.AbsoluteUri,
                IsLatestVersion = packageResult.Package.IsLatestVersion,
                Description = packageResult.Package.Description,
                ReleaseNotes = packageResult.Package.ReleaseNotes,
                // Source = new Uri(packageResult.SourceUri),
                Id = packageResult.Package.Id,
                Version = packageResult.Version,
                VersionDownloadCount = packageResult.Package.VersionDownloadCount
            };
            var defauluIcon = "https://cdn.rawgit.com/digitaldrummerj/ChocolateyPackages/master/AndroidStudio/androidstudio_logo.png";
            if (packageResult.Package.IconUrl == null)
            {
                result.IconUrl = defauluIcon;
            }
            else
            {
                result.IconUrl = packageResult.Package.IconUrl.AbsoluteUri;
            }
            return result;
        }
    }
}
