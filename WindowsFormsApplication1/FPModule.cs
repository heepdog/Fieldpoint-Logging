using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;
using System.Threading;
using System.Diagnostics;
using System.ComponentModel;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Collections;

namespace NILogger
{
    // Define a class to hold custom event info
    public class CustomEventArgs : EventArgs
    {
        public CustomEventArgs(string s)
        {
            message = s;
        }
        private string message;

        public string Message
        {
            get { return message; }
            set { message = value; }
        }
    }

    [Serializable]
    public class FPModule //: ISerializable 
    {
        #region Atributes
        public double seconds { get; set; }
        public int seconds2 { get; set; }
        protected int address;
        private string[] ModuleType = new string[2];
        public string[] moduleType
        {
            get; set;
        }
        protected Channel[] Channels;
        private readonly static object moduleLock = new object();

        public int size()
        {
            return Channels.Length;

        }
        protected bool Monitoring = false;

        public override string ToString()
        {
            return ("Address: " + address.ToString() + " Type: " + ModuleType[1]);
        }
        

        
        #endregion

        #region Constants
        protected static readonly Dictionary<string, string> QUADATTRIBS1 = new Dictionary<string, string>()
        {
            { "00", "Unknown" },
            { "01", "Unknown1" },
            { "02", "unknown2" },
            { "03", "Unknown3" },
            { "04", "Unknown4" },

        };

        protected static readonly Dictionary<string, string> QUADATTRIBS2 = new Dictionary<string, string>()
        {
            { "00", "Unknown" },
            { "01", "Unknown1" },
            { "02", "unknown2" },
            { "03", "Unknown3" },
            { "04", "Unknown4" },

        };
        static protected readonly Dictionary<string, string> MODULEERRORS = new Dictionary<string, string>()
        {
            { "00", "E_PUCLR_EXP" },
            { "01", "E_INVALID_CMD" },
            { "02", "E_BAD_CHECKSUM" },
            { "03", "E_INBUF_OVRFLO" },
            { "04", "E_ILLEGAL_CHAR" },
            { "05", "E_INSUFF_CHARS" },
            { "06", "E_WATCHDOG_TMO" },
            { "07", "E_INV_LIMS_GOT" },
            { "80", "E_ILLEGAL_DIGIT" },
            { "81", "E_BAD_ADDRESS" },
            { "82", "E_INBUF_FRMERR" },
            { "83", "E_NO_MODULE" },
            { "84", "E_INV_CHNL" },
            { "85", "E_INV_RANGE" },
            { "86", "E_INV_ATTR" },
            { "88", "E_HOTSWAP" },
            { "89", "E_ADDR_NOT_SAME" },
            { "8A", "E_NO_RESEND_BUF" },
            { "8B", "E_HW_FAILURE" },
            { "8C", "E_UNKNOWN" }

        };
        static protected readonly Dictionary<string, string> AIATTRIBS1 = new Dictionary<string, string>()
        {
            { "00", "60Hz filter" },
            { "01", "50Hz filter" },
            {"02", "500Hz filter" }
        };
        static protected readonly Dictionary<string, string> TCATTRIBS1 = new Dictionary<string, string>()
        {
            { "00", "J Type" },
            { "01", "K Type" },
            { "02", "T Type" },
            { "03", "E Type" },
            { "04", "R Type" },
            { "05", "S Type" },
            { "06", "N Type" },
            { "07", "B Type" }
        };
        static protected readonly Dictionary<string, string> CJATTRIBS1 = new Dictionary<string, string>()
        {
            {"00", "Internal Sensor" },
            {"01", "0° C" },
            {"02",  "25° C" }
        };
        static protected readonly Dictionary<string, string> RANGES = new Dictionary<string, string>()
        {
            {"00", "0 to 21 mA" },
            {"01", "3.5 to 21 mA" },
            {"02", "-21 to 21 mA" },
            {"03", "-10.4 to 10.4 V" },
            {"04", "0 to 10.4 V" },
            {"05", "-5.2 to 5.2 V" },
            {"06", "0 to 5.2 V" },
            {"07", "-1.04 to 1.04 V" },
            {"08", "0 to 1.04 V" },
            {"09", "-325 to 325 mV" },
            {"0A", "-65 to 65 mV" },
            //{"0A", "±50 mV" },
            {"0B", "-25 to 25 mV" },
            {"0C", "-20 to 80 mV" },
            {"0D", "-10 to 10 mV" },
            {"10", "0 Unknown 0 Unknown" },
            {"20", "0 to 2048 degK" },
            {"21", "-270 to 1770 degC" },
            {"22", "-454 to 3218 degF" },
            {"23", "223 to 358 degK" },
            {"24", "-50 to 85 degC" },
            {"25", "-58 to 185 degF" },
            {"40", "0 to 65535 counts" },
            {"50", "-160 to 160 counts/usec" },
            {"51", "-80 to 80 counts/usec" },
            {"52", "-40 to 40 counts/usec" },
            {"53", "-20 to 20 counts/usec" },
            {"54", "-10 to 10 counts/usec" },
            {"55", "-5 to 5 counts/usec" },
            {"56", "-2.5 to 2.5 counts/usec" },
            {"57", "-1.25 to 1.25 counts/usec" }
        };

        #endregion


        public bool calibrateChannelDisplay(int number, float display1, float raw1, float display2, float raw2)
        {
            if (number > this.size() || number < 0)
            {
                throw new ArgumentException("Argument is out of bounds");
            }
            return Channels[number].calibrate(display1, raw1, display2, raw2);

        }
        protected bool refreshData(string data, int filtering)
        {
            string[] responseString = SplitResponse(data, 4);

            for (int i = 0, j = responseString.Length - 1; i < responseString.Length; i++)
            {
                //    int temp = int.Parse(responseString[j--], System.Globalization.NumberStyles.HexNumber);
                //  Channels[i].updateValue((float)((temp / 65535.0 * (Channels[i].rangeHigh - Channels[i].rangeLow)) + Channels[i].rangeLow));
                Debug.WriteLine("{0}, {1}, response String: {2}", this.ToString(), this.getChannelName(i), responseString[j]);
                Channels[i].updateValue(int.Parse(responseString[j--], System.Globalization.NumberStyles.HexNumber), filtering);
            }


            return true;
        }
        public string getchannelunits(int channel)
        {
            if (channel > this.size() || channel < 0)
            {
                throw new ArgumentException("Argument is out of bounds");
            }
            return Channels[channel].rangeUnit;
        }
        public double getChannelDisplayValue(int channel)
        {
            if (channel > this.size() || channel < 0)
            {
                throw new ArgumentException("Argument is out of bounds", this.ToString() + " channel: " + channel.ToString() );
            }
            return Channels[channel].displayValue;
        }
        public double getChannelUnitValue(int channel)
        {
            if (channel > this.size() || channel < 0)
            {
                throw new ArgumentException("Argument is out of bounds");
            }
            return Channels[channel].rangeValue;
        }
        public string getChannelName(int channel)
        {
            if (channel > this.size() || channel < 0)
            {
                throw new ArgumentException("Argument is out of bounds");
            }
            return Channels[channel].ToString();
        }
        public string getchannelRange(int channel)
        {
            if (channel > this.size() || channel < 0)
            {
                throw new ArgumentException("Argument is out of bounds");
            }
            return Channels[channel].channelRange;
        }
        public string getChannelScale(int channel)
        {
            if (channel > this.size() || channel < 0)
            {
                throw new ArgumentException("Argument is out of bounds");
            }
            return "X = " + Channels[channel].scaling.Key.ToString() + ": Y = " + Channels[channel].scaling.Value.ToString();
        }
        public int getChannelRaw(int channel)
        {
            if (channel > this.size() || channel < 0)
            {
                throw new ArgumentException("Argument is out of bounds");
            }
            return Channels[channel].filteredraw;
        }
        public string getChannelrange(int channel)
        {
            if (channel > this.size() || channel < 0)
            {
                throw new ArgumentException("Argument is out of bounds");
            }
            return Channels[channel].rangeValue.ToString("N3");
        }
        public void setChannelNickname(int ch, string Name)
        {
            Channels[ch].setNickname(Name);
        }
        //[NonSerialized] protected SerialPort Interface;
        [NonSerialized] protected LoggerStream Interface;
        public bool setInterface(LoggerStream newiface)
        {
            try
            {
                Interface = newiface;
                return true;
            }
            catch
            {
                return false;
            }
            
        }
        public LoggerStream getInterface()
        {
            return Interface;
        }
        public event EventHandler ModuleEvent;


        public FPModule()
        {

            //string response;
            // string checksumResponse;
            Interface = null;
            Channels = null;
            address = 0;
            ModuleType[0] = "Unknown";
            ModuleType[1] = "99";



        }

        public bool monitorModule(bool monitor)
        {
            if (monitor)
            {
                try
                {
                    Monitoring = true;
                    Thread othread = new Thread(new ThreadStart(halfminupdate));
                    othread.Start();

                }
                catch
                {
                    Monitoring = false;
                    return false;
                }
                return true;
            }
            else
            {
                Monitoring = false;
                return true;
            }

        }

        //private BackgroundWorker bg1;

        private void halfminupdate()
        {
            while (Monitoring)
            {
                UpdateValues();
                onModuleEvent(new CustomEventArgs("Updated Values"));
                Debug.WriteLine("module updated");
                Thread.Sleep(30000);
            }
        }
        protected virtual void onModuleEvent(CustomEventArgs e)
        {
            // Make a temporary copy of the event to avoid possibility of
            // a race condition if the last subscriber unsubscribes
            // immediately after the null check and before the event is raised.

            EventHandler handler = ModuleEvent;

            // Event will be null if there are no subscribers
            if (handler != null)
            {
                // Format the string to send inside the CustomEventArgs parameter
                e.Message += String.Format(" at {0}", DateTime.Now.ToString());

                // Use the () operator to raise the event.
               //handler(this, e));
                handler.Invoke(this, e);

            }
        }

        ~FPModule()
        {
            Monitoring = false;
        }

 

        public FPModule(LoggerStream sp, int a)
        {
            string response;
            string checksumResponse;
            address = a;
            Interface = sp;
            if (Interface.IsOpen)
            {
                //send Get Module ID
                string command = ">" + address.ToString("X2") + "!A";
                lock (moduleLock)
                {
                    
                    Interface.WriteLine(command + checksum(command));
                    do
                    {
                        response = Interface.ReadLine();
                    } while (!checksumOK(response));
                    //response = response.Remove(response.Length - 1);
                }
                // trim acknowledgment and Cecksum and EOL '\r'
                checksumResponse = response.Remove(0, response.Length - 2);
                response = response.Remove(response.Length - 2).Trim('A');
                switch (response)
                {
                    case "0001"://FP - 1000
                        ModuleType[0] = response;
                        ModuleType[1] = "FP-1000";
                        Channels = new Channel[0];

                        break;

                    case "0002":

                        break;

                    case "0101": //FP-AI-110
                        ModuleType[0] = response;
                        ModuleType[1] = "FP-AI-110";
                        Channels = new Channel[8];
                        for (int i = 0; i < 8; i++)
                        {
                            Channels[i] = new Channel(i, Channel.chdirection.input, Channel.chmode.analog);
                        }
                        // Get Channel Ranges
                        command = ">" + address.ToString("X2") + "!E00FF0000100001000010000100001000010000100001";
                        lock (moduleLock)
                        {
                            Interface.WriteLine(command + checksum(command));
                            do
                            {
                                response = Interface.ReadLine();
                            } while (!checksumOK(response));
                        }
                        string[] responseString = SplitResponse(response, 2);

                        for (int i = 0, j = responseString.Length - 1; i < responseString.Length; i++)
                        {
                            Channels[i].setRange(RANGES[responseString[j--]]);
                        }

                        //get channel attributes 
                        command = ">" + address.ToString("X2") + "!E00FF0001000010000100001000010000100001000010";
                        lock (moduleLock)
                        {
                            Interface.WriteLine(command + checksum(command));
                            do
                            {
                                response = Interface.ReadLine();
                            } while (!checksumOK(response));
                        }
                        responseString = SplitResponse(response, 2);

                        //TODO: check for valid response

                        for (int i = 0, j = responseString.Length - 1; i < responseString.Length; i++)
                        {
                            Channels[i].setatr("0001", responseString[j], AIATTRIBS1[responseString[j--]]);
                            //Channels[i].setAttribute("0001", responseString[j--]);
                        }

                        break;

                    case "0102":

                        break;

                    case "0103":
                        break;

                    case "0104"://FP-DO-400
                        ModuleType[0] = response;
                        ModuleType[1] = "FP-DO-400";
                        Channels = new Channel[8];
                        for (int i = 0; i < 8; i++)
                        {
                            Channels[i] = new Channel(i, Channel.chdirection.output, Channel.chmode.digital);
                        }

                        break;

                    case "0105":
                        break;

                    case "0106":
                        break;

                    case "0107"://FP-TC-120
                        ModuleType[0] = response;
                        ModuleType[1] = "FP-TC-120";
                        Channels = new Channel[9];
                        for (int i = 0; i < 9; i++)
                        {
                            Channels[i] = new Channel(i, Channel.chdirection.input, Channel.chmode.analog);
                        }
                        // Get Channel Ranges
                        command = ">" + address.ToString("X2") + "!E01FF000010000100001000010000100001000010000100001";
                        lock (moduleLock)
                        {
                            Interface.WriteLine(command + checksum(command));
                            do
                            {
                                response = Interface.ReadLine();
                            } while (!checksumOK(response));
                        }
                        responseString = SplitResponse(response, 2);

                        for (int i = 0, j = responseString.Length - 1; i < responseString.Length; i++)
                        {
                            Channels[i].setRange(RANGES[responseString[j--]]);
                        }

                        //get channel attributes 
                        command = ">" + address.ToString("X2") + "!E00FF0001000010000100001000010000100001000010";
                        lock (moduleLock)
                        {
                            Interface.WriteLine(command + checksum(command));
                            do
                            {
                                response = Interface.ReadLine();
                            } while (!checksumOK(response));
                            responseString = SplitResponse(response, 2);
                        }

                        //TODO: check for valid response

                        for (int i = 0, j = responseString.Length - 1; i < responseString.Length; i++)
                        {
                            // Channels[i] = new Channel(i);
                            Channels[i].setatr("0001", responseString[j], TCATTRIBS1[responseString[j--]]);

                            //Channels[i].setAttribute("0001", responseString[j--]);
                        }

                        command = ">" + address.ToString("X2") + "!E010000010";
                        lock (moduleLock)
                        {
                            Interface.WriteLine(command + checksum(command));
                            do
                            {
                                response = Interface.ReadLine();
                            } while (!checksumOK(response));
                        }
                        responseString = SplitResponse(response, 2);

                        Channels[8].setatr("0001", responseString[0], CJATTRIBS1[responseString[0]]);
                        break;

                    case "0108":
                        break;

                    case "0109":
                        break;

                    case "010A":
                        break;

                    case "010B":
                        break;

                    case "010C":
                        break;

                    case "010D":
                        break;

                    case "010E":
                        break;

                    case "010F":
                        break;

                    case "0110":

                        break;

                    case "0111":
                        break;

                    case "FFFF":
                        break;

                    case "0116"://FP-510_QUAD
                        ModuleType[0] = response;
                        ModuleType[1] = "FP-510_QUAD";
                        Channels = new Channel[18];
                        //chanels are 16bit counters 0,3 combine for a 32bit counter in channel 16 1,4 combine in chanel 17
                        for (int i = 0; i < 12; i++)
                        {
                            Channels[i] = new Channel(i, Channel.chdirection.input, Channel.chmode.analog);
                        }
                        //Channels for index
                        for (int i = 12; i < 16; i++)
                        {
                            Channels[i] = new Channel(i, Channel.chdirection.input, Channel.chmode.digital);
                        }
                        //channels to combine 16 bit counts
                        for ( int i = 16; i < 18; i++)
                        {
                            Channels[i] = new Channel(i, Channel.chdirection.input, Channel.chmode.digital);
                        }

                        // Get Channel Ranges
                        command = ">" + address.ToString("X2") + "!EFFFF00001000010000100001000010000100001000010000100001000010000100001000010000100001";
                        lock (moduleLock)
                        {
                            Interface.WriteLine(command + checksum(command));
                            do
                            {
                                response = Interface.ReadLine();
                            } while (!checksumOK(response));
                        }
                        responseString = SplitResponse(response, 2);

                        for (int i = 0, j = responseString.Length - 1; i < responseString.Length; i++)
                        {
                            Channels[i].setRange(RANGES[responseString[j--]]);
                        }

                        //get channel attributes 
                        command = ">" + address.ToString("X2") + "!E000F00030000300003000030";
                        lock (moduleLock)
                        {
                            Interface.WriteLine(command + checksum(command));
                            do
                            {
                                response = Interface.ReadLine();
                            } while (!checksumOK(response));
                        }
                        responseString = SplitResponse(response, 2);

                        //TODO: check for valid response

                        for (int i = 0, j = responseString.Length - 1; i < responseString.Length / 2; i++)
                        {
                            Channels[i].setatr("0001", responseString[j], QUADATTRIBS1[responseString[j--]]);
                            Channels[i].setatr("0002", responseString[j], QUADATTRIBS2[responseString[j--]]);

                        }

                        break;

                    default:
                        ModuleType[0] = response;
                        ModuleType[1] = "UNKNOWN";

                        break;


                }


            }
        }

        // todo: need to add checksum check to update values.
        public bool UpdateValues()   
        {
            string command;
            string response;

            switch (ModuleType[0])
            {
                case "0001"://FP - 1000
                    break;

                case "0002":
                    break;

                case "0101": //FP-AI-110 !F01FF A8F00FFFF246A248224902474243B2461EB
                    command = ">" + address.ToString("X2") + "!F00FF";
                    lock (moduleLock)
                    {
                        Interface.WriteLine(command + checksum(command));
                        do
                        {
                            response = Interface.ReadLine();
                        } while (!checksumOK(response));
                    }

                    refreshData(response,10);

                    break;

                case "0102":

                    break;

                case "0103":
                    break;

                case "0104"://FP-DO-400

                    break;

                case "0105":
                    break;

                case "0106":
                    break;

                case "0107"://FP-TC-120
                            //TODO: create tead for TC
                    command = ">" + address.ToString("X2") + "!F01FF";
                    lock (moduleLock)
                    {
                        Interface.WriteLine(command + checksum(command));
                        do
                        {
                            response = Interface.ReadLine();
                        } while (!checksumOK(response));
                    }
                    /*
                    responseString = SplitResponse(response, 4);

                    for (int i = 0, j=responseString.Length-1 ;i < responseString.Length;i++)
                    {
                        int temp = int.Parse(responseString[j--], System.Globalization.NumberStyles.HexNumber);
                        Channels[i].updateValue(((temp / 65535 * (Channels[i].rangeHigh - Channels[i].rangeLow)) + Channels[i].rangeLow));
                    }*/
                    refreshData(response,10);

                    break;

                case "0108":
                    break;

                case "0109":
                    break;

                case "010A":
                    break;

                case "010B":
                    break;

                case "010C":
                    break;

                case "010D":
                    break;

                case "010E":
                    break;

                case "010F":
                    break;

                case "0110":

                    break;

                case "0111":
                    break;

                case "FFFF":
                    break;

                case "0116"://FP-510_QUAD
                            //TODO: create Values for quad
                    command = ">" + address.ToString("X2") + "!F0FFF";
                    lock (moduleLock)
                    {
                        Interface.WriteLine(command + checksum(command));
                        do
                        {
                            response = Interface.ReadLine();
                        } while (!checksumOK(response));
                    }
                    refreshData(response,1);
                    int lower = Channels[0].lastraw;
                    int upper = Channels[4].lastraw << 16;
                    Channels[16].updateValue(lower + upper,1);

                    //uncomment for channel 17
                    //lower = Channels[1].lastraw;
                    //upper = Channels[5].lastraw << 16;
                    //Channels[17].updateValue(lower + upper, 1);

                    break;


            }
            return true;
        }
        
        public string[] getchannelattribs(int chan)
        {
            return Channels[chan].getatriblist();
        }

        //private string[] SplitResponse(string r, int size)
        //{
        //    //r = r.Remove(r.Length - 2).TrimStart('A');
        //    r = r.Remove(1, r.Length - 2);
        //    int numbers = r.Length / size;
        //    string[] next = new string[numbers];
        //    for (int i = 0; i < numbers - 1; i++)
        //    {
        //        next[i] = r.Remove(size);
        //        r = r.Remove(0, size);
        //    }
        //    next[numbers - 1] = r;
        //    return next;
        //}

        private string[] SplitResponse(string r, int size)
        {
            //r = r.Remove(r.Length - 2).TrimStart('A');
            //r = r.Remove(1, r.Length - 2);
            int numbers = (r.Length - 3) / size;
            int s = 1;
            string[] next = new string[numbers];
            for (int i = 0; i < numbers ; i++)
            {
                next[i] = r.Substring(s, size);
                s += size;
            }
            //next[numbers - 1] = r;
            return next;
        }


        public static String checksum(String command)
        {
                //calculate checksum
            int sum = 0;
            //create Byte array without the start character '>'
            byte[] cmdarray = Encoding.ASCII.GetBytes(command.TrimStart('>'));
            //add all bytes together
            foreach (byte i in cmdarray)
            {
                sum = (sum + i);
            }
            //return getHexstring((sum % 256), 1, true);
            return (sum % 256).ToString("X2");
            }
        public static bool checksumOK(string command)
        {
            int sum = 0;
            string check = command.Substring(command.Length-2);
            //byte[] cmdarray = Encoding.ASCII.GetBytes(command.TrimStart('A').Remove(command.Length - 3));
            byte[] cmdarray = Encoding.ASCII.GetBytes(command.Substring(1,command.Length - 3));

            foreach (byte i in cmdarray)
            {
                sum = sum + i;
            }
            int result = sum % 256;
            string hexend = result.ToString("X2");
            Debug.WriteLine("Received check : {0}, Calculated Check {1}", check, hexend);
            if (hexend != check)
                Debug.Print("Checksum Error: recieved - " + check + "Calculated - " + hexend);
            return (hexend == check);
        }

        
    }


    [Serializable]
    public class Channel
    {
        public Channel()
        {
            rangeHigh = 0;
            rangeLow = 0;
            rangeUnit = null;
            rangeValue = 0;


        }
        public enum chdirection { input, output };
        public enum chmode { analog, digital };
        public float rangeHigh{ get; set; }
        public int lastraw;
        public float rangeLow { get; set; }
        public string rangeUnit { get; set; }
        public KeyValuePair<float, float> scaling { get; set; } = new KeyValuePair<float, float>(1, 0);
        //public KeyValuePair<float, float> scaling { get; set; }
        private Queue<int> filter { get; set; } = new Queue<int>();
        public float rangeValue { get; set; }

        [Serializable] public struct atr
        {
            public string mask, Setting, Description;

            public override string ToString()
            {
                return Description;
            }

        }
        int? ChannelNumber = null;
        public int filteredraw;
        public string channelRange { get; set; }

        float LastValue;
        public float displayValue;
        chdirection Direction;
        chmode Mode;
        protected Dictionary<string, string> Attributes = new Dictionary<string, string>();
        protected List<atr> attriblist = new List<atr>();
        protected string Nickname { get; set; }

        public Channel(int a)
        {
            ChannelNumber = a;
            Nickname = "Channel " + ChannelNumber.ToString();
        }

        public Channel(int a, chdirection dir, chmode m)
        {
            ChannelNumber = a;
            Direction = dir;
            Mode = m;
            Nickname = "Channel " + ChannelNumber.ToString();

        }
        public bool setatr(string m, string s, string d)
        {
            if (ChannelNumber == null)
            {
                return false;
            }
            atr temp;
            temp.mask = m;
            temp.Setting = s;
            temp.Description = d;

            attriblist.Add(temp);
            return true;
        }
        public string[] getatriblist()
        {
            string[] listing = new string[attriblist.Count()];
            for (int i = 0; i < attriblist.Count(); i++)
            {
                listing[i] = attriblist[i].ToString();
            }
            return listing;
        }

        
        //public bool setAttribute(string key, string value)
        //{
        //    if (ChannelNumber == null)
        //    {
        //        return false;
        //    }
             
        //    Attributes.Add(key, value);
        //    return true;
        //}

        public bool setRange(string value)
        {
            if (ChannelNumber == null)
            {
                return false;
            }
            string[] valsplit = value.Split(' ');
            channelRange = value;
            rangeHigh = float.Parse(valsplit[2]);
            rangeLow = float.Parse(valsplit[0]);
            rangeUnit = valsplit[3];
            return true;
        }

        public override string ToString()
        {
            // return base.ToString();)
            return Nickname + ", " + LastValue + ", " + channelRange; 

        }
 /*       public int updateValue(float temp)
        {
            LastValue = temp;
            displayValue = temp * scaling.Key + scaling.Value;
            if (Math.Abs(filteredval - displayValue) < 100)
                filter.Enqueue(displayValue);
            if (filter.Count > 10)
                filter.Dequeue();
            filteredval = 0;
            foreach (float i in filter)
            {
                filteredval = filteredval + i;
            }
            filteredval = filteredval / filter.Count;

            return 1 ;
        }
  */

 //*********************************************************************************
 //     Take the raw number from the Channel and update the Display value using an 
 //     average of the last 10 values, the range of the channel and the x,y calibration
 //     Value.
 //         in: (int)temp - Raw Value from the Channel
 //         out: 1 Success, 0 Failure (temp is not within range
 //************************************************************************************
  
        public int updateValue(int temp, int filtering)
        {
            if (temp < 0)
            {
                MessageBox.Show(this. Nickname + " value is negative");
                return 0;
            }
            while (filtering < filter.Count)
            {
                filter.Dequeue();
            }
            //if ((Math.Abs(filteredraw - temp) < 1000) || (filter.Count == 0))
            if ((temp != 0) && (temp < 66000) || (filter.Count == 0) || (Math.Abs(lastraw - temp) < 1000))
            {
                filter.Enqueue(temp);
                lastraw = temp;
            }
            else
            {
                filter.Dequeue();
                return 0;
            }

            if (filter.Count > filtering)
                filter.Dequeue();
           
            filteredraw = 0;

            foreach (int i in filter)
            {
                filteredraw = filteredraw + i;
            }
            filteredraw = filteredraw / (int)(filter.Count);

            rangeValue = (float)((filteredraw / 65535.0 * (rangeHigh - rangeLow)) + rangeLow);
            LastValue= (float)((temp / 65535.0 * (rangeHigh - rangeLow)) + rangeLow);
            displayValue = filteredraw * scaling.Key + scaling.Value;
            return 1;
        }
        public bool calibrate(float display1, float raw1, float display2, float raw2)
        {
            float m = (display1 - display2) / (raw1 - raw2);
            float b = display1 - m * raw1;
            scaling = new KeyValuePair<float, float>(m, b);

            return true;
        }

        internal void setNickname(string name)
        {
            Nickname = name;
            //throw new NotImplementedException();
        }
    }

    [Serializable]
    public class FPNetwork : IEnumerable
    {
        
        public IEnumerator GetEnumerator()
        {
            return new NetworkEnumerator(this);
        }

        private class NetworkEnumerator : IEnumerator
        {
            private int position = -1;
            private FPNetwork nw;

            public NetworkEnumerator(FPNetwork nw)
            {
                this.nw = nw;
            }

            public bool MoveNext()
            {
                position++;
                return (position < nw.Modules.Count);
            }

            public void Reset()
            { position = -1; }

            public object Current
            {
                get { return nw.Modules[position]; }
            }
        }
        private SortedList<int, FPModule> Modules { get; set; }
        public int Length { get; set; }
        public bool IsConfigured { get; internal set; }

        public FPNetwork()
        {
            Modules = new SortedList<int, FPModule>();
            IsConfigured = false;
        }

        public bool GetNetwork(LoggerStream  sp)
        {
            try {

                sp.WriteLine(">00!B" + FPModule.checksum(">00!B"));
                string response = sp.ReadLine();
                int Return = int.Parse(response.Substring(1, 2));
                Length = Return - 1;
                int address = 0;
                for (; address < Return; address++)
                {
                    FPModule temp = new FPModule(sp, address);
                    Modules.Add(address, temp);


                }
                IsConfigured = true;
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show("Unable to Get Network", "FP Error", MessageBoxButtons.OK);
                Debug.WriteLine(e.Message);
                IsConfigured = false;
                return false;
            }
        }
        public FPModule this[int index]
        {
            get
            {
                //return Modules.GetByIndex(Modules.IndexOfKey(index)) ;
                FPModule r;
                if (Modules.TryGetValue(index, out r))
                {
                    return r;
                }

                return null;
            }
            set
            {
                FPModule r;
                Modules.TryGetValue(index, out r);
                LoggerStream l = r.getInterface();

                Modules[index] = new FPModule(l, index);

            }

        }
        public bool UpdateNetwork()
        {
            foreach (FPModule m in Modules.Values )
            {
                m.UpdateValues();
            }
            return true;
        }

        public bool SetNetworkPort(LoggerStream s)
        {
            foreach (FPModule m in Modules.Values)
            {
                m.setInterface(s);
            }
            return true;

        }
    }
}
