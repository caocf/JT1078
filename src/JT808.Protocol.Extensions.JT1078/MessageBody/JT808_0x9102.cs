﻿using JT808.Protocol.Formatters;
using JT808.Protocol.MessagePack;
using System;
using System.Collections.Generic;
using System.Text;

namespace JT808.Protocol.Extensions.JT1078.MessageBody
{
    /// <summary>
    /// 音视频实时传输控制
    /// </summary>
    public class JT808_0x9102:JT808Bodies, IJT808MessagePackFormatter<JT808_0x9102>
    {
        public override string Description => "音视频实时传输控制";
        public override ushort MsgId => 0x9102;
        /// <summary>
        /// 逻辑通道号
        /// </summary>
        public byte LogicalChannelNo { get; set; }
        /// <summary>
        /// 控制指令
        /// 平台可以通过该指令对设备的实时音视频进行控制：
        /// 0:关闭音视频传输指令
        /// 1:切换码流（增加暂停和继续）
        /// 2:暂停该通道所有流的发送
        /// 3:恢复暂停前流的发送,与暂停前的流类型一致
        /// 4:关闭双向对讲
        /// </summary>
        public byte ControlCmd { get; set; }
        /// <summary>
        /// 关闭音视频类型
        /// 0:关闭该通道有关的音视频数据
        /// 1:只关闭该通道有关的音频，保留该通道有关的视频
        /// 2:只关闭该通道有关的视频，保留该通道有关的音频
        /// </summary>
        public byte CloseAVData { get; set; }
        /// <summary>
        /// 切换码流类型
        /// 将之前申请的码流切换为新申请的码流，音频与切换前保持一致。
        /// 新申请的码流为：
        /// 0:主码流
        /// 1:子码流
        /// </summary>
        public byte SwitchStreamType { get; set; }

        public JT808_0x9102 Deserialize(ref JT808MessagePackReader reader, IJT808Config config)
        {
            JT808_0x9102 jT808_0X9102 = new JT808_0x9102();
            jT808_0X9102.LogicalChannelNo = reader.ReadByte();
            jT808_0X9102.ControlCmd = reader.ReadByte();
            jT808_0X9102.CloseAVData = reader.ReadByte();
            jT808_0X9102.SwitchStreamType = reader.ReadByte();
            return jT808_0X9102;
        }

        public void Serialize(ref JT808MessagePackWriter writer, JT808_0x9102 value, IJT808Config config)
        {
            writer.WriteByte(value.LogicalChannelNo);
            writer.WriteByte(value.ControlCmd);
            writer.WriteByte(value.CloseAVData);
            writer.WriteByte(value.SwitchStreamType);
        }
    }
}
