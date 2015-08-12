// ***********************************************************************
// Project          : ChepingServer
// File             : Program.cs
// Created          : 2015-06-24  3:57 AM
//
// Last Modified By : Siqi Lu
// Last Modified On : 2015-08-12  2:35 PM
// ***********************************************************************
// <copyright file="Program.cs" company="Shanghai Yuyi Mdt InfoTech Ltd.">
//     Copyright ©  2012-2015 Shanghai Yuyi Mdt InfoTech Ltd. All rights reserved.
// </copyright>
// ***********************************************************************

using ChepingServer.Services;

namespace ConsoleApplication
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            SmsService service = new SmsService();
            service.SendMessage("15800780728", "aaaa").Wait();
        }
    }
}