using System;
using System.Collections.Generic;
using System.Text;
using System.IO.Ports;

namespace FTS.BaseBusiness.Systems
{
    public class PoleDisplay
    {
        SerialPort srPort;
        bool active = false;
        public PoleDisplay(string com)
        {
            try
            {
                srPort = new SerialPort(com, 9600, Parity.None, 8, StopBits.One);
                if (!srPort.IsOpen) srPort.Open();
                active = true;
            }
            catch
            {
                active = false;
            }
        }
        ~PoleDisplay()
        {
            if (!active)
                return;
            srPort.Close();
        }
        public void ClearDisplay()
        {
            try
            {
                if (!active)
                    return;
                byte[] data = new byte[] { 0x0C };
                srPort.Write(data, 0, data.Length);
            }
            catch { }
        }
        public void Display(string textToDisplay, int line)
        {
            try
            {
                if (!active)
                    return;
                if (textToDisplay.Length <= 19)
                {
                    textToDisplay = FTS.BaseBusiness.Utilities.Functions.Unicode2NoSign(textToDisplay);
                    int blank = (20 - textToDisplay.Length) / 2;
                    for (int i = 0; i < blank; i++)
                        textToDisplay = " " + textToDisplay;
                }
                else
                {
                    textToDisplay = textToDisplay.Substring(0, 19).Trim();
                    textToDisplay = FTS.BaseBusiness.Utilities.Functions.Unicode2NoSign(textToDisplay);
                }
                if (line == 0)
                {
                    srPort.Write(textToDisplay);
                }
                else if (line == 1)
                {
                    byte[] data = new byte[] { 0x0A, 0x0D };
                    srPort.Write(data, 0, data.Length);
                    srPort.Write(textToDisplay);
                }
            }
            catch { }
        }
    }
}
