// ***********************************************************************
// Project          : ChepingServer
// Author           : Siqi Lu
// Created          : 2015-06-24  3:57 AM
//
// Last Modified By : Siqi Lu
// Last Modified On : 2015-06-24  4:33 AM
// ***********************************************************************
// <copyright file="Program.cs" company="Shanghai Yuyi Mdt InfoTech Ltd.">
//     Copyright ©  2012-2015 Shanghai Yuyi Mdt InfoTech Ltd. All rights reserved.
// </copyright>
// ***********************************************************************

using System;
using ChepingServer.Services;
using Moe.Lib;

namespace ConsoleApplication
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            CaseService service = new CaseService();
            var result = service.GetValueDto(20, 6000, 10000000);
            try
            {
                result.Wait();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            Console.WriteLine(result.Result.ToJson());
        }
    }
}