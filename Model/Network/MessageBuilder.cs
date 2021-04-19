using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Kinect;
using Rug.Osc;

namespace KinectV2OSC.Model.Network
{
    public class MessageBuilder
    {
        public OscMessage BuildJointMessage(Body body, KeyValuePair<JointType, Joint> joint, CameraSpacePoint cameraSpacePoint)  
        {
            var address = String.Format("/bodies/kinect3/joints/{0}",joint.Key);   //address contains / body.TrackingId to display body ID
            //var position = joint.Value.Position;
    
            //System.Diagnostics.Debug.WriteLine(address);
            return new OscMessage(address, cameraSpacePoint.X, cameraSpacePoint.Y, cameraSpacePoint.Z, joint.Value.TrackingState.ToString());
        }

        public OscMessage BuildJointOrientationMessage(Body body, KeyValuePair<JointType, JointOrientation> jointOrientation)  //add jointOrientation to the buildJointMessage
        {
            var address = String.Format("/bodies/kinect3/jointsOrientation/{0}", jointOrientation.Key); //address contains / body.TrackingId to display body ID
            var orientation = jointOrientation.Value.Orientation;
            //System.Diagnostics.Debug.WriteLine(address);
            return new OscMessage(address, orientation.X, orientation.Y, orientation.Z, orientation.W);
        }

        public OscMessage BuildHandMessage(Body body, string key, HandState state, TrackingConfidence confidence)
        {
            var address = String.Format("/bodies/kinect3/hands/{0}", key);  // address contains /body.TrackingId to detect body
            //System.Diagnostics.Debug.WriteLine(address);
            return new OscMessage(address, state.ToString(), confidence.ToString());
        }
    }
}
