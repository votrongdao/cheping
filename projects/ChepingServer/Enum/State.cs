// ***********************************************************************
// Project          : ChepingServer
// Author           : Siqi Lu
// Created          : 2015-06-19  12:26 PM
//
// Last Modified By : Siqi Lu
// Last Modified On : 2015-06-19  12:28 PM
// ***********************************************************************
// <copyright file="State.cs" company="Shanghai Yuyi Mdt InfoTech Ltd.">
//     Copyright ©  2012-2015 Shanghai Yuyi Mdt InfoTech Ltd. All rights reserved.
// </copyright>
// ***********************************************************************

namespace ChepingServer.Enum
{
    public enum State
    {
        Valuing = 10,
        Checking = 20,
        CheckFailed = 30,
        Inspecting = 40,
        InspectFailed = 50
    }
}