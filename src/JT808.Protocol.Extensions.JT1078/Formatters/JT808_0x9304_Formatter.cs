﻿using JT808.Protocol.Extensions.JT1078.MessageBody;
using JT808.Protocol.Formatters;
using JT808.Protocol.Interfaces;
using JT808.Protocol.MessagePack;
using System;
using System.Collections.Generic;
using System.Text;

namespace JT808.Protocol.Extensions.JT1078.Formatters
{
    public class JT808_0x9304_Formatter : IJT808MessagePackFormatter<JT808_0x9304>
    {
        public JT808_0x9304 Deserialize(ref JT808MessagePackReader reader, IJT808Config config)
        {
            JT808_0x9304 jT808_0x9304 = new JT808_0x9304();
            jT808_0x9304.LogicChannelNo = reader.ReadByte();
            jT808_0x9304.StartOrStop = reader.ReadByte();
            return jT808_0x9304;
        }

        public void Serialize(ref JT808MessagePackWriter writer, JT808_0x9304 value, IJT808Config config)
        {
            writer.WriteByte(value.LogicChannelNo);
            writer.WriteByte(value.StartOrStop);
        }
    }
}