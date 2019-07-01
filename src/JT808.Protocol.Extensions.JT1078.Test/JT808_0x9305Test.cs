﻿using JT808.Protocol.Extensions.JT1078.MessageBody;
using JT808.Protocol.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace JT808.Protocol.Extensions.JT1078.Test
{
    public class JT808_0x9305Test
    {
        JT808Serializer JT808Serializer;
        public JT808_0x9305Test()
        {
            IServiceCollection serviceDescriptors1 = new ServiceCollection();
            serviceDescriptors1
                            .AddJT808Configure()
                            .AddJT1078Configure();
            var ServiceProvider1 = serviceDescriptors1.BuildServiceProvider();
            var defaultConfig = ServiceProvider1.GetRequiredService<IJT808Config>();
            JT808Serializer = defaultConfig.GetSerializer();

            Newtonsoft.Json.JsonConvert.DefaultSettings = new Func<JsonSerializerSettings>(() =>
            {
                //日期类型默认格式化处理
                return new Newtonsoft.Json.JsonSerializerSettings
                {
                    DateFormatHandling = Newtonsoft.Json.DateFormatHandling.MicrosoftDateFormat,
                    DateFormatString = "yyyy-MM-dd HH:mm:ss"
                };
            });
        }

        [Fact]
        public void Test1()
        {
            JT808_0x9305 jT808_0x9305 = new JT808_0x9305()
            {
 LogicChannelNo=1,
 StartOrStop=2
            };
            var str = Newtonsoft.Json.JsonConvert.SerializeObject(jT808_0x9305);
            var hex = JT808Serializer.Serialize(jT808_0x9305).ToHexString();
            Assert.Equal("0102", hex);
        }

        [Fact]
        public void Test2()
        {
            var str = "{\"LogicChannelNo\":1,\"StartOrStop\":2,\"SkipSerialization\":false}";
            var jT808_0x9305 = JT808Serializer.Deserialize<JT808_0x9305>("0102".ToHexBytes());
            Assert.Equal(Newtonsoft.Json.JsonConvert.SerializeObject(jT808_0x9305), str);
        }
    }
}