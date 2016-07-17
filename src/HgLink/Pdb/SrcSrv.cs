﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SrcSrv.cs" company="CatenaLogic">
//   Copyright (c) 2014 - 2014 CatenaLogic. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace HgLink.Pdb
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using Catel;

    public static class SrcSrv
    {
        private static string CreateTarget(string rawUrl, string revision)
        {
            return string.Format(rawUrl, revision);
        }

        public static byte[] Create(string rawUrl, string revision, IEnumerable<Tuple<string, string>> paths, bool downloadWithPowershell)
        {
            Argument.IsNotNullOrWhitespace(() => rawUrl);
            Argument.IsNotNullOrWhitespace(() => revision);

            using (var ms = new MemoryStream())
            {
                using (var sw = new StreamWriter(ms))
                {
                    var scheme = new Uri(rawUrl).Scheme;
                
                    sw.WriteLine("SRCSRV: ini ------------------------------------------------");
                    sw.WriteLine("VERSION=2");
                    sw.WriteLine("SRCSRV: variables ------------------------------------------");                    
                    sw.WriteLine("RAWURL={0}", CreateTarget(rawUrl, revision));
                    if(downloadWithPowershell)
                    {
                        sw.WriteLine("TRGFILE=%fnbksl%(%targ%%var2%)");
                        sw.WriteLine("SRCSRVTRG=%TRGFILE%");
                        sw.WriteLine("SRCSRVCMD=powershell -NoProfile -Command \"(New-Object System.Net.WebClient).DownloadFile('%RAWURL%', '%TRGFILE%')\"");
                    }
                    else
                    {
                        sw.WriteLine("SRCSRVVERCTRL={0}", scheme);
                        sw.WriteLine("SRCSRVTRG=%RAWURL%");
                    }
                    sw.WriteLine("SRCSRV: source files ---------------------------------------");

                    foreach (var tuple in paths)
                    {
                        sw.WriteLine("{0}*{1}", tuple.Item1, tuple.Item2);
                    }

                    sw.WriteLine("SRCSRV: end ------------------------------------------------");

                    sw.Flush();

                    return ms.ToArray();
                }
            }
        }
    }
}