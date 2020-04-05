namespace GhisPrism.Core
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using GhisPrism.Core.Models;

    /// <summary>
    /// Interface that defines operation for getting package information data and store the source
    /// of each package.
    /// </summary>
    public interface IChocolateyService
    {
        Task AddSource(ChocolateySource source);

        Task<Package> GetByVersionAndIdAsync(string id, string version, bool isPrerelease);

        Task<ChocolateyFeature[]> GetFeatures();

        /// <summary>
        /// Provide all installed package from the existing source e.g. nuget.org(INugetService),
        /// chocolatey.org(GetChocolatey):only from your PC.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Package>> GetInstalledPackages();

        Task<IReadOnlyList<Tuple<string, string>>> GetOutdatedPackages(bool includePrerelease = false, string packageName = null);

        Task<ChocolateySetting[]> GetSettings();

        Task<ChocolateySource[]> GetSources();

        Task<PackageOperationResult> InstallPackage(
            string id,
            string version = null,
            Uri source = null,
            bool force = false);

        Task<bool> IsElevated();

        Task<PackageOperationResult> PinPackage(string id, string version);

        /// <summary>
        /// Remove source by the given id
        /// </summary>
        /// <param name="id">identifier of the package source</param>
        /// <returns>
        /// <see langword="true"/> if the package source is removed; otherwise <see langword="false"/>
        /// </returns>
        Task<bool> RemoveSource(string id);

        /// <summary>
        /// </summary>
        /// <param name="query">the query information for search process</param>
        /// <param name="options">option setting for search process</param>
        /// <returns></returns>
        Task<PackageResults> Search(string query, PackageSearchOptions options);

        /// <summary>
        /// </summary>
        /// <param name="feature"></param>
        /// <returns></returns>
        Task SetFeature(ChocolateyFeature feature);

        /// <summary>
        /// </summary>
        /// <param name="setting"></param>
        /// <returns></returns>
        Task SetSetting(ChocolateySetting setting);

        /// <summary>
        /// </summary>
        /// <param name="id"></param>
        /// <param name="version"></param>
        /// <param name="force"></param>
        /// <returns></returns>
        Task<PackageOperationResult> UninstallPackage(string id, string version, bool force = false);

        /// <summary>
        /// </summary>
        /// <param name="id"></param>
        /// <param name="version"></param>
        /// <returns></returns>
        Task<PackageOperationResult> UnpinPackage(string id, string version);

        /// <summary>
        /// </summary>
        /// <param name="id"></param>
        /// <param name="source"></param>
        /// <returns></returns>
        Task<PackageOperationResult> UpdatePackage(string id, Uri source = null);

        Task UpdateSource(string id, ChocolateySource source);
    }
}
