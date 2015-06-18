// ***********************************************************************
// Project          : ChepingServer
// Author           : Siqi Lu
// Created          : 2015-06-12  11:21 AM
//
// Last Modified By : Siqi Lu
// Last Modified On : 2015-06-12  12:25 PM
// ***********************************************************************
// <copyright file="CaseController.cs" company="Shanghai Yuyi Mdt InfoTech Ltd.">
//     Copyright ©  2012-2015 Shanghai Yuyi Mdt InfoTech Ltd. All rights reserved.
// </copyright>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using ChepingServer.Models;
using Moe.Lib;

namespace ChepingServer.Controllers
{
    /// <summary>
    ///     CaseController.
    /// </summary>
    [RoutePrefix("Case")]
    public class CaseController : ApiController
    {
        /// <summary>
        ///     添加事项信息
        /// </summary>
        /// <param name="info">
        ///     包含事项信息的请求内容
        /// </param>
        /// <response code="200"></response>
        /// <response code="400"></response>
        /// <response code="500"></response>
        [Route("AddCase"), ResponseType(typeof(Case))]
        public async Task<IHttpActionResult> AddCase(Case info)
        {
            User user;

            using (ChePingContext db = new ChePingContext())
            {
                user = await db.Users.FirstOrDefaultAsync(u => u.Id == info.CurrentAttn);
            }

            if (user == null)
            {
                return this.BadRequest("无法指派给编号{0}的操作人".FormatWith(info.CurrentAttn));
            }

            using (ChePingContext db = new ChePingContext())
            {
                VehicleInfo vehicleInfo = new VehicleInfo();
                VehicleInspec vehicleInspec = new VehicleInspec();

                db.VehicleInfos.Add(vehicleInfo);
                db.VehicleInspecs.Add(vehicleInspec);

                await db.SaveChangesAsync();

                info.SerialId = user.UserCode + DateTime.Now.ToString("yyyyMMdd");
                info.VehicleInfoId = vehicleInfo.Id;
                info.VehicleInspecId = vehicleInspec.Id;

                db.Cases.Add(info);
                await db.SaveChangesAsync();
            }

            return this.Ok(info);
        }

        /// <summary>
        ///     编辑事项信息
        /// </summary>
        /// <param name="info">
        ///     包含事项信息的请求内容
        /// </param>
        /// <response code="200"></response>
        /// <response code="400"></response>
        /// <response code="500"></response>
        [Route("EditCase"), ResponseType(typeof(Case))]
        public async Task<IHttpActionResult> EditCase(Case info)
        {
            Case @case;
            using (ChePingContext db = new ChePingContext())
            {
                @case = await db.Cases.FirstOrDefaultAsync(c => c.Id == info.Id);

                @case.CurrentAttn = info.CurrentAttn;
                @case.PurchasePrice = info.PurchasePrice;
                @case.State = info.State;

                await db.SaveChangesAsync();
            }

            return this.Ok(@case);
        }

        /// <summary>
        ///     查询事项信息
        /// </summary>
        /// <param name="id">
        ///     二手车编号
        /// </param>
        /// <response code="200"></response>
        /// <response code="400"></response>
        /// <response code="500"></response>
        [Route("Info"), ResponseType(typeof(Case))]
        public async Task<IHttpActionResult> Info(int id)
        {
            Case info;
            using (ChePingContext db = new ChePingContext())
            {
                info = await db.Cases.FirstOrDefaultAsync(i => i.Id == id);
                if (info == null)
                {
                    return this.BadRequest("无该车辆信息");
                }
            }

            return this.Ok(info);
        }

        /// <summary>
        ///     查询二手车信息，分页查询
        /// </summary>
        /// <param name="pageIndex">分页编号，从0开始</param>
        /// <param name="pageSize">分页大小</param>
        /// <response code="200"></response>
        /// <response code="400"></response>
        /// <response code="500"></response>
        [Route("Infos"), ResponseType(typeof(List<Case>))]
        public async Task<IHttpActionResult> Infos(int pageIndex, int pageSize)
        {
            List<Case> infos;
            using (ChePingContext db = new ChePingContext())
            {
                infos = await db.Cases.OrderBy(i => i.Id).Skip(pageIndex * pageSize).Take(pageSize).ToListAsync();
            }

            return this.Ok(infos);
        }
    }
}