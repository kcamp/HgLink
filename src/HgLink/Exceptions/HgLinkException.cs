// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HgLinkException.cs" company="CatenaLogic">
//   Copyright (c) 2014 - 2014 CatenaLogic. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace HgLink
{
    using System;

    public class HgLinkException : Exception
    {
        public HgLinkException(string message)
            : base(message)
        {
        }
    }
}