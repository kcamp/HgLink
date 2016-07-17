// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Context.cs" company="CatenaLogic">
//   Copyright (c) 2014 - 2014 CatenaLogic. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace HgLink
{
    using System;
    using System.Collections.Generic;
    using Catel;
    using Catel.IO;
    using Catel.Logging;
    using Providers;
    
    public class Context
    {
        private static readonly ILog Log = LogManager.GetCurrentClassLogger();

        private readonly IProviderManager _providerManager;
        private IProvider _provider;

        public Context(IProviderManager providerManager)
        {
            Argument.IsNotNull(() => providerManager);

            _providerManager = providerManager;

            Authentication = new Authentication();
            ConfigurationName = "Release";
            PlatformName = "AnyCPU";
            IncludedProjects = new List<string>();
            IgnoredProjects = new List<string>();
        }

		public bool DownloadWithPowershell { get; set; }

        public bool IsHelp { get; set; }

        public bool IsDebug { get; set; }

        public bool ErrorsAsWarnings { get; set; }

        public bool SkipVerify { get; set; }

        public string LogFile { get; set; }
        
        public string SolutionDirectory { get; set; }

        public string ConfigurationName { get; set; }

        public string PlatformName { get; set; }

        public Authentication Authentication { get; private set; }

        public IProvider Provider
        {
            get
            {
                if (_provider == null)
                {
                    _provider = _providerManager.GetProvider(TargetUrl);
                }

                return _provider;
            }
            set
            {
                _provider = value;
            }
        }

        public string TargetUrl { get; set; }

        public string TargetBranch { get; set; }

        public string ShaHash { get; set; }

        public string SolutionFile { get; set; }

        public List<string> IncludedProjects { get; private set; }

        public List<string> IgnoredProjects { get; private set; }

        public string PdbFilesDirectory { get; set; }

        public void ValidateContext()
        {
            if (!string.IsNullOrWhiteSpace(SolutionDirectory))
            {
                SolutionDirectory = Path.GetFullPath(SolutionDirectory, Environment.CurrentDirectory);
            }

            if (string.IsNullOrEmpty(SolutionDirectory))
            {
                throw Log.ErrorAndCreateException<HgLinkException>("Solution directory is missing");
            }

            if (string.IsNullOrEmpty(ConfigurationName))
            {
                throw Log.ErrorAndCreateException<HgLinkException>("Configuration name is missing");
            }

            if (string.IsNullOrEmpty(PlatformName))
            {
                throw Log.ErrorAndCreateException<HgLinkException>("Platform name is missing");
            }

            if (string.IsNullOrEmpty(TargetUrl))
            {
                throw Log.ErrorAndCreateException<HgLinkException>("Target url is missing");
            }

            if (Provider == null)
            {
                throw Log.ErrorAndCreateException<HgLinkException>("Cannot determine git provider");
            }
        }
    }
}