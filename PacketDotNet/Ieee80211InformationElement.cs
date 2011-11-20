﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PacketDotNet
{
    public class Ieee80211InformationElement
    {
        public enum ElementId
        {
            ServiceSetIdentity = 0x00,
            SupportedRates = 0x01,
            FhParamterSet = 0x02,
            DsParameterSet = 0x03,
            CfParameterSet = 0x04,
            TrafficIndicationMap = 0x05,
            IbssParameterSet = 0x06,
            Country = 0x07,
            HoppingParametersPattern = 0x08,
            HoppingPatternTable = 0x09,
            Request = 0x0A,
            ChallengeText = 0x10,
            PowerContstraint = 0x20,
            PowerCapability = 0x21,
            TransmitPowerControlRequest = 0x22,
            TransmitPowerControlReport = 0x23,
            SupportedChannels = 0x24,
            ChannelSwitchAnnouncement = 0x25,
            MeasurementRequest = 0x26,
            MeasurementReport = 0x27,
            Quiet = 0x28,
            IbssDfs = 0x29,
            ErpInformation = 0x2A,
            RobustSecurityNetwork = 0x30,
            ExtendedSupportedRates = 0x32,
            WifiProtectedAccess = 0xD3,
            VendorSpecific = 0xDD
        }

        public Ieee80211InformationElement(ElementId id, Byte[] value)
        {
            if (value.Length > 0xFF)
            {
                throw new ArgumentException("Value is too long. Maximum allowed length is 256 bytes.");
            }

            Id = id;
            Value = value;
        }

        public ElementId Id { get; private set; }

        public int Length
        {
            get
            {
                return Value.Length;
            }
        }

        public Byte[] Value { get; private set; }

        public Byte[] Bytes
        {
            get
            {
                Byte[] bytes = new Byte[2 + Length];
                bytes[0] = (byte)Id;
                bytes[1] = (byte)Length;
                Array.Copy(Value, 0, bytes, 2, Length);
                return bytes;
            }
        }

        // override object.Equals
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Ieee80211InformationElement ie = obj as Ieee80211InformationElement;
            return ((Id == ie.Id) && (Value.SequenceEqual(ie.Value)));
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            return Id.GetHashCode() ^ Value.GetHashCode();
        }
    }
}
