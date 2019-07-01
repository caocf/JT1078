﻿using JT808.Protocol.Attributes;
using JT808.Protocol.Extensions.JT1078.Formatters;
using JT808.Protocol.MessageBody;

namespace JT808.Protocol.Extensions.JT1078.MessageBody
{
    /// <summary>
    /// 视频相关报警
    /// 0x0200_0x14
    /// </summary>
    [JT808Formatter(typeof(JT808_0x0200_0x14_Formatter))]
    public class JT808_0x0200_0x14 : JT808_0x0200_CustomBodyBase
    {
        public override byte AttachInfoId { get; set; } = 0x14;
        /// <summary>
        /// 数据 长度
        /// </summary>
        public override byte AttachInfoLength { get; set; } = 4;
        /// <summary>
        /// 视频相关报警
        /// </summary>
        public uint VideoRelateAlarm { get; set; }
    }
}
