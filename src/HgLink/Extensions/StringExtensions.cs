﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StringExtensions.cs" company="CatenaLogic">
//   Copyright (c) 2014 - 2014 CatenaLogic. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace HgLink
{
    using Catel;

    public static class StringExtensions
    {
        public static string OptimizeUrl(this string url)
        {
            Argument.IsNotNullOrWhitespace(() => url);

            url = url.EndsWith(".git") ? url.Substring(0, url.Length - 4) : url;
            return url;
        }
    }
}