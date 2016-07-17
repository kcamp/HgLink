// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Authentication.cs" company="CatenaLogic">
//   Copyright (c) 2014 - 2014 CatenaLogic. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace HgLink
{
    using System;

    public class Authentication
    {
        public Authentication()
        {
            Username = Environment.GetEnvironmentVariable("HGLINK_REMOTE_USERNAME");
            Password = Environment.GetEnvironmentVariable("HGLINK_REMOTE_PASSWORD");
        }

        public string Password { get; set; }
        public string Username { get; set; }
    }
}