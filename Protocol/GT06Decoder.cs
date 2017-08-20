using ServerGps.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServerGps.Tools;
using ServerGps.Main;

namespace ServerGps.Protocol
{
    class GT06Decoder:IGPSDecoder
    {

        const ushort MSG_LOGIN = 0x01;
        const ushort MSG_POSITION = 0x12;
        const ushort MSG_HEARBEAT = 0x013;
        bool needResponse;
        ServerContext context;
        byte[] response;
        public GT06Decoder()
        {
            needResponse = false;
        }
        /*
         *  Format                      Length(Byte)
            Start Bit                   2
            Packet Length               1
            Protocol Number             1
            Information Content         N
            Information Serial Number   2
            Error Check                 2
            Stop Bit                    2
         */
        public void ParseData(byte[] data)
        {
            if (!((data[0] == 0x78) && (data[1] == 0x78)))
            {
                return;
            }
            response = null;
            needResponse = false;
            //packet length
            ushort pl = data[2];
            ushort protocol = data[3];

            switch (protocol)
            {
                case MSG_LOGIN:                    
                    //PARSE LOGIN
                    Console.WriteLine("PARSE LOGIN");
                    byte[] bytesimei = new byte[8];
                    Array.Copy( data, 4, bytesimei, 0, 8);
                    string imei=Tools.Tools.ByteToHexString(bytesimei);
                    Console.WriteLine("IMEI:"+ imei);
                    sendResponse((byte)protocol,BitConverter.ToInt16(data,12));
                    needResponse = false;
                    break;
            }
        }
        private void sendResponse(byte protocol,short serial)
        {
            byte[] crc = new byte[4];
            crc[0] = 0x05;
            crc[1] = 0x01;
            crc[2] = (byte)serial;
            crc[3] = (byte)(serial >> 8);

            Console.WriteLine(((byte)serial).ToString("X"));
            Console.WriteLine(((byte)(serial >> 8)).ToString("X"));
            

            short crcshort=Crc.ComputeChecksum(crc);
            Console.WriteLine(crcshort.ToString("X"));
            
            

            response= new byte[10];
            response[0] = 0x78;
            response[1] = 0x78;
            response[2] = 0x05;
            response[3] = protocol;
            response[4] = (byte)(serial >> 8);
            response[5] = (byte)serial;
            response[6] = (byte)(crcshort >> 8);
            response[7] = (byte)crcshort;
            response[8] = 0x0D;
            response[9] = 0x0A;
        }

        public void ParseGps()
        {
            //throw new NotImplementedException();
        }

        public void parseAlarm()
        {
            //throw new NotImplementedException();
        }


        public bool IsNeedResponse()
        {
            return needResponse;
        }


        public byte[] getResponse()
        {
            return response;
        }
    }
}
