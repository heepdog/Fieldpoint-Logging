using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.IO;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    [Serializable]
       public class LoggerStream : Stream, IDisposable
    {
        private Stream mystream;

        private string ipAddress;// { get; set; }
        private string comport;// { get; set; }
        private int ipPort;// { get; set; }
        public enum ST
        {
            Serial, TCP
        }
        public ST StreamType;

        public LoggerStream(bool Serial)
        {
            if (Serial)
            {
                in_SerialPort = new SerialPort();
                mystream = in_SerialPort.BaseStream;
                StreamType = ST.Serial;

            }
            else
            {
                in_TCPClient = new TcpClient();
                mystream = in_TCPClient.GetStream();
                StreamType = ST.TCP;
            }
        }
        public LoggerStream(string Port)
        {
            TcpPortName = null;
            in_TCPClient = null;
            ComPort = Port;
            in_SerialPort = new SerialPort(Port);
            in_SerialPort.Open();
            mystream = in_SerialPort.BaseStream;
            StreamType = ST.Serial;
        }

        public LoggerStream(string add, int pn)
        {
           
            try
            {
                in_TCPClient = new TcpClient(add, pn);
                in_TCPClient.ReceiveTimeout = 3000;
                in_TCPClient.SendTimeout = 30000;

                try
                {
                    mystream = in_TCPClient.GetStream();
                }
                catch (Exception E)
                {
                    Console.WriteLine(E.Message);
                    throw E;
                }

                StreamType = ST.TCP;
                TCPAddress = add;
                TcpPort = pn;
                ComPort = null;
                in_SerialPort = null;

            }
            catch (Exception E)
            {
                Console.WriteLine(E.Message);
            }

        }

        public override bool CanRead
        {
            get
            {
                //throw new NotImplementedException();
                return true;
            }
        }

        public override bool CanSeek
        {
            get
            {
                //throw new NotImplementedException();
                return false;
            }
        }

        public override bool CanWrite
        {
            get
            {
                //throw new NotImplementedException();
                return true;
            }
        }

        public SerialPort in_SerialPort { get; set; }
        public TcpClient in_TCPClient { get; set; }
        public bool IsSerial
        {
            get
            {
                return (this.StreamType == ST.Serial ? true : false);
            }
        }
        public bool IsOpen
        {
            get
            {

                if (in_SerialPort != null)
                {
                    if (in_SerialPort.IsOpen)
                    {
                        return true;
                    }
                }
                if (in_TCPClient != null)
                {
                    if(in_TCPClient.Connected)
                    {
                        return true;
                    }
                }
                return false;
             }
        }
        public string TcpPortName
        {
            get
            {
                
                return tcpPort == 0 ? null : tcpPort.ToString();
            }
            set
            {
                tcpPort = TcpPortName == null ? 0 : int.Parse(TcpPortName);
            }
        }
        public string TCPAddress { get; set; }
        private int tcpPort;
        public int TcpPort { get; set; }


        public override long Length
        {
            get
            {
                //throw new NotImplementedException();
                return mystream.Length;
            }
        }

        public override long Position
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public string ComPort
        {
            get
            {
                return comport;
            }

            set
            {
                comport = value;
            }
        }

        public string IpAddress
        {
            get
            {
                return ipAddress;
            }

            set
            {
                ipAddress = value;
            }
        }

        public int IpPort
        {
            get
            {
                return ipPort;
            }

            set
            {
                ipPort = value;
            }
        }

        public override void Flush()
        {
            //throw new NotImplementedException();
            mystream.Flush();
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            //throw new NotImplementedException();
            try
            {
                return mystream.Read(buffer, offset, count);
            }
            catch(Exception e)
            {
                Debug.WriteLine(e.Message);
            }
                return 0;
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            throw new NotImplementedException();
        }

        public override void SetLength(long value)
        {
            throw new NotImplementedException();
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            //throw new NotImplementedException();
            try
            {
                mystream.Write(buffer, offset, count);
            }
            catch (Exception E)
            {
                Console.WriteLine(E.Message);
            }
        }
        public void WriteLine(string Data)
        {
            Data = Data + "\r";
            byte[] buffer = Encoding.ASCII.GetBytes(Data);
            mystream.Write(buffer, 0, buffer.Length);


        }
        public string ReadLine()
        {
            byte[] singlebuf = new byte[1];
            string result = "";
            do
            {
                Read(singlebuf, 0, 1);
                result = result + Encoding.ASCII.GetString(singlebuf);
            } while (singlebuf[0] != '\r');

            return result;

        }

        public string ReadTillEOL()
        {
            throw new NotImplementedException();
        }

        public override int ReadByte()
        {
            return mystream.ReadByte();
        }
        public override void WriteByte(byte value)
        {
            mystream.WriteByte(value);
        }

        protected override void Dispose( bool disposing)
        {
            if (this.IsOpen)
                mystream.Close();
            if (this.IsSerial)
            {
                if (this.IsOpen)
                {
                    mystream.Close();
                    in_SerialPort.Close();
                }
            }
            else if (!this.IsSerial)
            {
                if (this.IsOpen)
                    mystream.Close();
            }
            mystream.Dispose();
            base.Dispose();
            
        }
    }


}
