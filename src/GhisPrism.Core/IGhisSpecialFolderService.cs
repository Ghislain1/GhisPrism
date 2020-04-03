using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GhisPrism.Core.Models;
using static System.Environment;

namespace GhisPrism.Core
{
    /// <summary>
    /// Provide list of items in eg. Environment.SpecialFolder.ProgramFilesX86
    /// </summary>
    public interface IGhisSpecialFolderService
    {
        Task AddSource(Environment.SpecialFolder source);

        Task<Package> GetByVersionAndIdAsync(string id, string version, bool isPrerelease);

        /// <summary>
        /// Provide all installed package in your PC.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Package>> GetInstalledPackages();

        Task<IReadOnlyList<Tuple<string, SemanticVersion>>> GetOutdatedPackages(bool includePrerelease = false, string packageName = null);

        Task<SpecialFolder[]> GetSources();

        Task<PackageOperationResult> InstallPackage(
            string id,
            string version = null,
            Uri source = null,
            bool force = false);

        Task<bool> IsElevated();

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
        /// <param name="id"></param>
        /// <param name="version"></param>
        /// <param name="force"></param>
        /// <returns></returns>
        Task<PackageOperationResult> UninstallPackage(string id, string version, bool force = false);

        /// <summary>
        /// </summary>
        /// <param name="id"></param>
        /// <param name="source"></param>
        /// <returns></returns>
        Task<PackageOperationResult> UpdatePackage(string id, Uri source = null);

        Task UpdateSource(string id, SpecialFolder source);
    }
}