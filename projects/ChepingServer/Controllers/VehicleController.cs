// ***********************************************************************
// Project          : ChepingServer
// Author           : Siqi Lu
// Created          : 2015-06-12  10:03 AM
//
// Last Modified By : Siqi Lu
// Last Modified On : 2015-06-12  12:52 PM
// ***********************************************************************
// <copyright file="VehicleController.cs" company="Shanghai Yuyi Mdt InfoTech Ltd.">
//     Copyright ©  2012-2015 Shanghai Yuyi Mdt InfoTech Ltd. All rights reserved.
// </copyright>
// ***********************************************************************

using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using ChepingServer.Models;

namespace ChepingServer.Controllers
{
    /// <summary>
    ///     VehicleController.
    /// </summary>
    [RoutePrefix("Vehicle")]
    public class VehicleController : ApiController
    {
        /// <summary>
        ///     添加二手车信息
        /// </summary>
        /// <param name="info">
        ///     包含二手车信息的请求内容
        /// </param>
        /// <response code="200"></response>
        /// <response code="400"></response>
        /// <response code="500"></response>
        [Route("AddVehicleInfo"), ResponseType(typeof(VehicleInfo))]
        public async Task<IHttpActionResult> AddVehicleInfo(VehicleInfo info)
        {
            using (ChePingContext db = new ChePingContext())
            {
                db.VehicleInfos.Add(info);
                await db.SaveChangesAsync();
            }

            return this.Ok(info);
        }

        /// <summary>
        ///     添加验车信息
        /// </summary>
        /// <param name="inspec">
        ///     包含二手车验车信息的请求内容
        /// </param>
        /// <response code="200"></response>
        /// <response code="400"></response>
        /// <response code="500"></response>
        [Route("AddVehicleInspec"), ResponseType(typeof(VehicleInspec))]
        public async Task<IHttpActionResult> AddVehicleInspec(VehicleInspec inspec)
        {
            using (ChePingContext db = new ChePingContext())
            {
                db.VehicleInspecs.Add(inspec);
                await db.SaveChangesAsync();
            }

            return this.Ok(inspec);
        }

        /// <summary>
        ///     编辑二手车验车信息
        /// </summary>
        /// <param name="inspec">
        ///     包含二手车验车信息的请求内容
        /// </param>
        /// <response code="200"></response>
        /// <response code="400"></response>
        /// <response code="500"></response>
        [Route("EditVehicleInfo"), ResponseType(typeof(VehicleInspec))]
        public async Task<IHttpActionResult> EditVehicleInfo(VehicleInspec inspec)
        {
            VehicleInspec source;
            using (ChePingContext db = new ChePingContext())
            {
                source = await db.VehicleInspecs.FirstOrDefaultAsync(i => i.Id == inspec.Id);
                if (source == null)
                {
                    return this.BadRequest("无该车辆信息");
                }

                source.BondsNote = inspec.BondsNote;
                source.BondsState = inspec.BondsState;
                source.ClaimNote = inspec.ClaimNote;
                source.ClaimState = inspec.ClaimState;
                source.ConservationNote = inspec.ConservationNote;
                source.ConservationState = inspec.ConservationState;
                source.EngineCode = inspec.EngineCode;
                source.LastConservationTime = inspec.LastConservationTime;
                source.LicenseCode = inspec.LicenseCode;
                source.PolicyCode = inspec.PolicyCode;
                source.RealMileage = inspec.RealMileage;
                source.VITCode = inspec.VITCode;
                source.ViolationNote = inspec.ViolationNote;
                source.ViolationState = inspec.ViolationState;

                await db.SaveChangesAsync();
            }

            return this.Ok(source);
        }

        /// <summary>
        ///     查询二手车信息
        /// </summary>
        /// <param name="id">
        ///     二手车编号
        /// </param>
        /// <response code="200"></response>
        /// <response code="400"></response>
        /// <response code="500"></response>
        [Route("Info"), ResponseType(typeof(VehicleInfo))]
        public async Task<IHttpActionResult> Info(int id)
        {
            VehicleInfo info;
            using (ChePingContext db = new ChePingContext())
            {
                info = await db.VehicleInfos.FirstOrDefaultAsync(i => i.Id == id);
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
        [Route("Infos"), ResponseType(typeof(List<VehicleInfo>))]
        public async Task<IHttpActionResult> Infos(int pageIndex, int pageSize)
        {
            List<VehicleInfo> infos;
            using (ChePingContext db = new ChePingContext())
            {
                infos = await db.VehicleInfos.OrderBy(i => i.Id).Skip(pageIndex * pageSize).Take(pageSize).ToListAsync();
            }

            return this.Ok(infos);
        }

        /// <summary>
        ///     查询二手车验车信息
        /// </summary>
        /// <param name="id">
        ///     二手车验车信息编号
        /// </param>
        /// <response code="200"></response>
        /// <response code="400"></response>
        /// <response code="500"></response>
        [Route("VehicleInspecInfo"), ResponseType(typeof(VehicleInfo))]
        public async Task<IHttpActionResult> VehicleInspecInfo(int id)
        {
            VehicleInspec info;
            using (ChePingContext db = new ChePingContext())
            {
                info = await db.VehicleInspecs.FirstOrDefaultAsync(i => i.Id == id);
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
        [Route("VehicleInspecInfos"), ResponseType(typeof(List<VehicleInspec>))]
        public async Task<IHttpActionResult> VehicleInspecInfos(int pageIndex, int pageSize)
        {
            List<VehicleInspec> infos;
            using (ChePingContext db = new ChePingContext())
            {
                infos = await db.VehicleInspecs.OrderBy(i => i.Id).Skip(pageIndex * pageSize).Take(pageSize).ToListAsync();
            }

            return this.Ok(infos);
        }
    }
}