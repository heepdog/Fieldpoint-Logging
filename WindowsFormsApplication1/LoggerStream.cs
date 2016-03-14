using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.IO;
using System.Diagnostics;
using System.Threading;

namespace WindowsFormsApplication1
{
       class LoggerStream : Stream
    {
        public Stream mystream;
        public string ipAddress { get; set; }
        public string ComPort { get; set; }
        public int ipPort { get; set; }
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
            ComPort = Port;
            in_SerialPort = new SerialPort(Port);
            in_SerialPort.Open();
            mystream = in_SerialPort.BaseStream;
            StreamType = ST.Serial;
        }
        public LoggerStream(string add, int pn)
        {
            byte[] buffer = new byte[80];
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
                buffer = Encoding.ASCII.GetBytes(">00!B??\r");

                try
                {
                    mystream.Write(buffer, 0, 8);
                }
                catch (Exception E)
                {
                    Console.WriteLine(E.Message);
                    throw E;
                }

                buffer = new byte[80];
                Thread.Sleep(1000);

                try
                {
                    mystream.Read(buffer, 0, 80);
                    Debug.WriteLine(Encoding.Default.GetString(buffer));
                }
                catch (Exception E)
                {
                    Console.WriteLine(E.Message);
                }
            }
            catch (Exception E)
            {
                Console.WriteLine(E.Message);
            }

            if(mystream != null)
                mystream.Close();

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
        public bool IsSerial { get; }
        public bool IsConnected { get; }
        public string PortName { get; set; }
        public string TCPAddress { get; set; }
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
    }


}
