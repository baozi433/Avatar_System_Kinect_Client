using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using Microsoft.Kinect;
using Rug.Osc;

namespace KinectV2OSC.Model.Network
{
    public class BodySender
    {
        //private MessageBuilder messageBuilder;
        private List<OscSender> oscSenders; // Create a list of OscSender which is used for creating UDP sender to the connected socket
        private List<IPAddress> ipAddresses;  // list of IPAddress object which not only contain ip but also other info like port etc.
        private string port;  
        private string status;

        //private MessageBuilder2 messageBuilder2;
        private MessageBuilder3 messageBuilder3;
        private OscMessage message;

        public BodySender(string delimitedIpAddresses, string port)   //BodySender constructor
        {
            this.status = "";
            this.ipAddresses = this.Parse(delimitedIpAddresses);  //call the Parse() method to analyse delimitedIpAddresses
            this.oscSenders = new List<OscSender>();
            this.port = port;

            //this.messageBuilder2 = new MessageBuilder2();
            this.messageBuilder3 = new MessageBuilder3();
            this.TryConnect();
        }

        private void TryConnect()   //Try to connect another pc and send oscsender to the machine,if works add the oscsendr to the list
        {
            foreach(var ipAddress in this.ipAddresses)
            {
                try
                {
                    var oscSender = new OscSender(ipAddress, int.Parse(this.port));
                    oscSender.Connect();
                    this.oscSenders.Add(oscSender);
                    this.status += "OSC connection established on\nIP: " + ipAddress + "\nPort: " + port + "\n";
                }
                catch (Exception e)
                {
                    this.status += "Unable to make OSC connection on\nIP: " + ipAddress + "\nPort: " + port + "\n";
                    Console.WriteLine("Exception on OSC connection...");
                    Console.WriteLine(e.StackTrace);
                }
            }

        }

        public void Send(Body[] bodies, CameraSpacePoint[] cameraSpacePoint, int index)   // This method has the same name in the block but have different agruments.
        {
            foreach (Body body in bodies)
            {
                if (body.IsTracked)
                {
                    this.Send(body, cameraSpacePoint, index);
                    Console.WriteLine("Sending message from index: " + index);
                }

                else
                {
                    this.Send2();
                }
            }
        }

        public string GetStatusText()
        {
            return this.status;
        }

        private void Send(Body body, CameraSpacePoint[] cameraSpacePoint, int index)
        {

            //message = messageBuilder2.BuildJointMessage(body, cameraSpacePoint);
            message = messageBuilder3.BuildJointMessage(body, cameraSpacePoint, index);
            this.Broadcast(message);

            /*
            ///add send jointorientation message
            foreach (var jointOrientation in body.JointOrientations )  
            {
                message = messageBuilder2.BuildJointOrientationMessage(body, jointOrientation);
                this.Broadcast(message);
            }
            ///add send jointorientation message

            message = messageBuilder2.BuildHandMessage(body, "Left", body.HandLeftState, body.HandLeftConfidence);
            this.Broadcast(message);

            message = messageBuilder2.BuildHandMessage(body, "Right", body.HandRightState, body.HandRightConfidence);
            this.Broadcast(message);
            */
        }

        private void Send2()
        {
            //message = messageBuilder2.KinectStatus();
            message = messageBuilder3.KinectStatus();
            this.Broadcast(message);
        }

        private void Broadcast(OscMessage message)    //Broadcast method 
        {
            foreach (var oscSender in this.oscSenders)
            {
                oscSender.Send(message);
            }
        }

        private List<IPAddress> Parse(string delimitedIpAddresses)   //convert string array to list
        {
            try
            {
                var ipAddressStrings = delimitedIpAddresses.Split(',');   // convert string like"192.101.1.1, 192.101.0.1" to array
                var ipAddresses = new List<IPAddress>();
                foreach (var ipAddressString in ipAddressStrings)
                {
                    ipAddresses.Add(IPAddress.Parse(ipAddressString));
                }
                return ipAddresses;
            }
            catch (Exception e)
            {
                status += "Unable to parse IP address string: '" + delimitedIpAddresses + "'";
                Console.WriteLine("Exception parsing IP address string...");
                Console.WriteLine(e.StackTrace);
                return null;
            }
        }
    }
}
