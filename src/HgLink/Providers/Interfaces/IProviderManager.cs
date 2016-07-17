// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IProviderManager.cs" company="CatenaLogic">
//   Copyright (c) 2014 - 2014 CatenaLogic. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace HgLink.Providers
{
    public interface IProviderManager
    {
        ProviderBase GetProvider(string url);
    }
}