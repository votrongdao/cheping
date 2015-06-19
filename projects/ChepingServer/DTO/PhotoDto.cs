using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChepingServer.DTO
{

    /// <summary>
    /// Class PhotoEx.
    /// </summary>
    public static class PhotoEx {
        /// <summary>
        /// To the dto.
        /// </summary>
        /// <param name="photo">The photo.</param>
        /// <returns>PhotoDto.</returns>
        public static PhotoDto ToDto(this PhotoDto photo)
        {
            return new PhotoDto
            {
                CaseId = photo.CaseId,
                Content = photo.Content,
                Id = photo.Id,
                UploadTime = photo.UploadTime
            };
        }
    }


    /// <summary>
    /// Class PhotoDto.
    /// </summary>
    public class PhotoDto
    {
        /// <summary>
        /// 订单Id
        /// </summary>
        public int CaseId { get; set; }

        /// <summary>
        /// 图片内容
        /// </summary>
        public byte[] Content { get; set; }

        /// <summary>
        /// 图片Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 上传时间
        /// </summary>
        public DateTime UploadTime { get; set; }

    }
}