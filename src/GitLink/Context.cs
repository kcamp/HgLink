﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Context.cs" company="CatenaLogic">
//   Copyright (c) 2014 - 2014 CatenaLogic. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace GitLink
{
    using System;
    using System.IO;
    using Catel;
    using Catel.Logging;
    using Providers;

    public class Context
    {
        private static readonly ILog Log = LogManager.GetCurrentClassLogger();

        private readonly Lazy<string> _tempDirectory = new Lazy<string>(() =>
        {
            var tempDirectory = Path.Combine(Path.GetTempPath(), "SourceLink", Guid.NewGuid().ToString());
            Directory.CreateDirectory(tempDirectory);

            return tempDirectory;
        });

        public Context()
        {
            ConfigurationName = "Release";
        }

        public bool IsHelp { get; set; }
        public string LogFile { get; set; }

        public string SolutionDirectory { get; set; }
        public string ConfigurationName { get; set; }

        public ProviderBase Provider { get; set; }

        public string TempDirectory
        {
            get { return _tempDirectory.Value; }
        }

        public string TargetUrl { get; set; }
        public string TargetBranch { get; set; }

        public void ValidateContext()
        {
            if (string.IsNullOrEmpty(SolutionDirectory))
            {
                Log.ErrorAndThrowException<GitLinkException>("Solution directory is missing");
            }

            if (string.IsNullOrEmpty(ConfigurationName))
            {
                Log.ErrorAndThrowException<GitLinkException>("Configuration name is missing");
            }

            if (string.IsNullOrEmpty(TargetUrl))
            {
                Log.ErrorAndThrowException<GitLinkException>("Target url is missing");
            }

            if (Provider == null)
            {
                Log.ErrorAndThrowException<GitLinkException>("Cannot determine git provider");
            }
        }
    }
}