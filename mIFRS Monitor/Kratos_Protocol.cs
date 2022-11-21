using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Monitor
{
    class KratosProtocolFrame
    {
        public string Preamble;
        public string Opcode;
        public string MessageCounter ;
        public string LengthOfEntireMessage;
        public string CommandActivation ;
        public string MessageTimeTag ;
        public string Data;
        public string CheckSum;

        public override string ToString()
        {
            return String.Format("Preamble: [{0}] Opcode: [{1}] MessageCounter: [{2}] CommandActivation: [{3}] MessageTimeTag: [{4}] Data length: [{5}] Data : [{6}]  CheckSum: [{7}]",
                Preamble, Opcode, MessageCounter, CommandActivation, MessageTimeTag, LengthOfEntireMessage, Regex.Replace(Data, ".{2}", "$0 "), CheckSum);
        }
    }


    class Kratos_Protocol
    {

        static byte[] StringToByteArray(string hex)
        {
            try
            {
                return Enumerable.Range(0, hex.Length)
                                 .Where(x => x % 2 == 0)
                                 .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                                 .ToArray();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public static string ByteArrayToString(byte[] ba)
        {
            return BitConverter.ToString(ba).Replace("-", "");
        }

        static public byte[] EncodeKratusProtocol_Extended(KratosProtocolFrame i_Frame)
        {
            try
            {
                List<byte> ListBytes = new List<byte>();

                ListBytes.AddRange(StringToByteArray(i_Frame.Preamble));

                ListBytes.AddRange(StringToByteArray(i_Frame.Opcode));

                byte[] DataBytes = StringToByteArray(i_Frame.Data);
                UInt32 Datalength = (UInt32)DataBytes.Length;
                byte[] intBytes = BitConverter.GetBytes(Datalength);
                ListBytes.AddRange(intBytes);


                ListBytes.AddRange(DataBytes);

                UInt16 CheckSum = 0;

                for (int i = 0; i < ListBytes.Count; i++)
                {
                    CheckSum += ListBytes[i];
                }
                intBytes = BitConverter.GetBytes(CheckSum);
                ListBytes.AddRange(intBytes);

                byte[] Ret = ListBytes.ToArray();

                return Ret;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        static public KratosProtocolFrame DecodeKratusProtocol_Extended(byte[] i_IncomingBytes)
        {
            KratosProtocolFrame Ret = new KratosProtocolFrame();

            try
            {
                byte[] DataLengthBytes = i_IncomingBytes.Skip(4).Take(4).ToArray();

                UInt32 FrameDataLength = BitConverter.ToUInt32(DataLengthBytes, 0);
                int CheckSumIndex = (int)FrameDataLength + 8;


                UInt16 CheckSumCalc = 0;

                for (int i = 0; i < CheckSumIndex; i++)
                {
                    CheckSumCalc += i_IncomingBytes[i];
                }

                byte[] CheckSumBytes = i_IncomingBytes.Skip(CheckSumIndex).Take(2).ToArray();
                UInt16 CheckSumSent = BitConverter.ToUInt16(CheckSumBytes, 0);

                if (CheckSumSent == CheckSumCalc)
                {

                    Ret.Preamble = ByteArrayToString(i_IncomingBytes.Skip(0).Take(2).ToArray());

                    Ret.Opcode = ByteArrayToString(i_IncomingBytes.Skip(2).Take(2).ToArray());

                    Ret.Data = ByteArrayToString(i_IncomingBytes.Skip(8).Take((int)FrameDataLength).ToArray());

                    Ret.LengthOfEntireMessage = FrameDataLength.ToString();

                    Ret.CheckSum = CheckSumSent.ToString("X2");
                    return Ret;


                }
                else
                {
                    throw new Exception("Check sum failed!");

                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }


        }

        static public byte[] EncodeKratusProtocol_Standard(KratosProtocolFrame i_Frame)
        {
            try
            {
                List<byte> ListBytes = new List<byte>();

                ListBytes.AddRange(StringToByteArray(i_Frame.Preamble));

                ListBytes.AddRange(StringToByteArray(i_Frame.Opcode));

                byte[] DataBytes = StringToByteArray(i_Frame.Data);
                UInt16 Datalength = (UInt16)DataBytes.Length;
                byte[] intBytes = BitConverter.GetBytes(Datalength);
                ListBytes.AddRange(intBytes.Reverse().ToArray());

                
                ListBytes.AddRange(DataBytes);

                byte CheckSum = 0;

                for (int i = 0; i < ListBytes.Count; i++)
                {
                    CheckSum += ListBytes[i];
                }
                // intBytes = BitConverter.GetBytes(CheckSum);
                ListBytes.Add(CheckSum);

                byte[] Ret = ListBytes.ToArray();

                return Ret;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        static public KratosProtocolFrame DecodeKratusProtocol_Standard(ref byte[] i_IncomingBytes)
        {
            KratosProtocolFrame Ret = new KratosProtocolFrame();

            //try
            //{
            byte[] DataLengthBytes = i_IncomingBytes.Skip(2).Take(2).Reverse().ToArray();

            UInt16 FrameDataLength = BitConverter.ToUInt16(DataLengthBytes, 0);
            int CheckSumIndex = (int)FrameDataLength + 4;


            Byte CheckSumCalc = 0;

            for (int i = 0; i < CheckSumIndex; i++)
            {
                CheckSumCalc += i_IncomingBytes[i];
            }

            byte[] CheckSumBytes = i_IncomingBytes.Skip(CheckSumIndex).Take(1).ToArray();
            Byte CheckSumSent = CheckSumBytes[0];

            if (CheckSumSent == CheckSumCalc)
            {

                Ret.Preamble = ByteArrayToString(i_IncomingBytes.Skip(0).Take(1).ToArray());

                Ret.Opcode = ByteArrayToString(i_IncomingBytes.Skip(1).Take(1).ToArray());

                Ret.Data = ByteArrayToString(i_IncomingBytes.Skip(4).Take((int)FrameDataLength).ToArray());

                Ret.LengthOfEntireMessage = FrameDataLength.ToString();

                Ret.CheckSum = CheckSumSent.ToString("X2");

                i_IncomingBytes = i_IncomingBytes.Skip(CheckSumIndex + 1).ToArray(); 
                return Ret;


            }
            else
            {
                throw new Exception("Income Frame - Check sum failed!");

            }

            //}
            //catch ()
            //{
            //    //throw new Exception(ex.Message);

            //}


        }

    }
}
