﻿using System;
using System.Collections.Generic;
using System.Text;

namespace JT1078.Flv.Metadata
{


    /// <summary>
    /// <code>
    ///AVCDecoderConfigurationRecord 结构的定义：
    ///aligned(8) class AVCDecoderConfigurationRecord
    ///{
    ///unsigned int (8) configurationVersion = 1;
    ///unsigned int (8) AVCProfileIndication;
    ///unsigned int (8) profile_compatibility;
    ///unsigned int (8) AVCLevelIndication;
    ///bit(6) reserved = ‘111111’b;
    ///unsigned int (2) lengthSizeMinusOne;
    ///bit(3) reserved = ‘111’b;
    ///unsigned int (5) numOfSequenceParameterSets;
    ///for (i=0; i<numOfSequenceParameterSets; i++) {
    ///unsigned int (16) sequenceParameterSetLength ;
    ///bit(8*sequenceParameterSetLength) sequenceParameterSetNALUnit;
    ///}
    ///unsigned int (8) numOfPictureParameterSets;
    ///for (i=0; i<numOfPictureParameterSets; i++) {
    ///unsigned int (16) pictureParameterSetLength;
    ///bit(8*pictureParameterSetLength) pictureParameterSetNALUnit;
    ///}
    ///} 
    /// </code>
    /// </summary>
    public class AVCDecoderConfigurationRecord
    {
        public byte ConfigurationVersion { get; set; } = 1;
        public byte AVCProfileIndication { get; set; }
        public byte ProfileCompatibility { get; set; }
        public byte AVCLevelIndication { get; set; }
        public int LengthSizeMinusOne { get; set; }
        public int NumOfSequenceParameterSets { get; set; }= 0xE0 | 1;
        public byte[] SPSBuffer { get; set; }
        public byte NumOfPictureParameterSets { get; set; }
        public byte[] PPSBuffer { get; set; }
        public bool IsPPSAndSPS
        {
            get
            {
                return (SPSBuffer != null && SPSBuffer.Length > 0) && (PPSBuffer != null && SPSBuffer.Length > 0);
            }
        }

        #region Just for non-spec-conform encoders ref:org.mp4parser.boxes.iso14496.part15.AvcDecoderConfigurationRecord
        public const int LengthSizeMinusOnePaddingBits = 63;
        public const int NumberOfSequenceParameterSetsPaddingBits = 7;
        public const int ChromaFormatPaddingBits = 31;
        public const int BitDepthLumaMinus8PaddingBits = 31;
        public const int BitDepthChromaMinus8PaddingBits = 31;
        #endregion
    }
}
