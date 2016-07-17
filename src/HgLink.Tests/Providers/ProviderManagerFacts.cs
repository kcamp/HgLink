﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProviderManagerFacts.cs" company="CatenaLogic">
//   Copyright (c) 2014 - 2014 CatenaLogic. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace HgLink.Tests.Providers
{
    using System;
    using HgLink.Providers;
    using NUnit.Framework;

    public class ProviderManagerFacts
    {
        [TestFixture]
        public class TheProviderGetProviderMethod
        {
            [TestCase("https://bitbucket.org/CatenaLogic/GitLink", typeof(BitBucketProvider))]
            [TestCase("https://github.com/CatenaLogic/GitLink", typeof(GitHubProvider))]
            [TestCase("https://example.com/repo", typeof(CustomRawUrlProvider))]
            [TestCase("", null)]
            public void ReturnsRightProvider(string url, Type expectedType)
            {
                var providerManager = new ProviderManager();
                var provider = providerManager.GetProvider(url);

                if (expectedType == null)
                {
                    Assert.IsNull(provider);
                }
                else
                {
                    Assert.IsInstanceOf(expectedType, provider);
                }
            }
        }
    }
}