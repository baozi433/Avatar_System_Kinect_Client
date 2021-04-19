using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Configuration file reading
using System.Xml;


namespace KinectV2OSC.Model.Network
{
    class CameraConfig
    {
        // The camera name, which is used for identify camera
        public string name;

        // The camera's order in raw data list
        public int index;

        // The camera's Lan address
        public string address;

        // The server's Lan address
        public string serveraddress;

        // The camera's port
        public int port;

        // The server's port
        public int serverport;

        // The camera's working mode
        public string mode;

        public CameraConfig()
        {
            name = KinectV2OSC.Properties.Resources.Name;

            ReadConfigurationFile();

            //Console.WriteLine("Name is " + name + ", Index is " + index + ", Address is " + address + ", Port is " + port + ", mode is " + mode);
        }

        void ReadConfigurationFile()
        {
            try
            {
                XmlDocument doc = new XmlDocument();

                XmlReaderSettings settings = new XmlReaderSettings();
                settings.IgnoreComments = true;

                XmlReader reader = XmlReader.Create("MLS_Global_Config.xml", settings);
                doc.Load(reader);

                XmlNode _xn_connecteddevice = doc.SelectSingleNode("connecteddevice");

                XmlNode _xn_serverdevice = _xn_connecteddevice.SelectSingleNode("serverdevice");
                XmlElement _xe_server = (XmlElement)_xn_serverdevice.ChildNodes[0];
                serveraddress = _xe_server.ChildNodes.Item(0).InnerText;
                serverport = int.Parse(_xe_server.ChildNodes.Item(1).InnerText);

                XmlNode _xn_clientdevice = _xn_connecteddevice.SelectSingleNode("clientdevice");
                XmlNodeList _xnl_clientdeviceliset = _xn_clientdevice.ChildNodes;

                foreach (XmlNode xn in _xnl_clientdeviceliset)
                {
                    XmlElement xe = (XmlElement)xn;

                    if (xe.GetAttribute("Name") == name)
                    {
                        XmlNodeList xnl = xe.ChildNodes;
                        index = int.Parse(xe.GetAttribute("Index"));
                        address = xnl.Item(1).InnerText;
                        port = int.Parse(xnl.Item(2).InnerText);
                        mode = xnl.Item(3).InnerText;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
