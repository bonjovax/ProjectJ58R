using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;

namespace nPOSProj.Conf
{
    class Drawer
    {
        private SerialPort sp;
        public void Open()
        {
            try
            {
                Byte[] cashDrawerCmd = { 27, 112, 0, 25, 250 };
                sp = new SerialPort();
                sp.PortName = "COM2";
                sp.Open();
                sp.BaudRate = 9600;
                sp.DataBits = 8;
                sp.Parity = System.IO.Ports.Parity.None;
                sp.StopBits = System.IO.Ports.StopBits.One;
                sp.Handshake = System.IO.Ports.Handshake.RequestToSend;

                sp.Write(cashDrawerCmd, 0, cashDrawerCmd.Length);
                sp.Close();
            }
            catch (Exception)
            {
                sp.Close();
            }
        }
    }
}