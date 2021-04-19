using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Kinect;
using Rug.Osc;

namespace KinectV2OSC.Model.Network
{
    public class MessageBuilder2
    {
        public OscMessage KinectStatus()
        {
            var address = String.Format("/kinect{0}nt", 2);
            return new OscMessage(address, 0f, 0f, 0f);
        }

        public OscMessage BuildJointMessage(Body body, CameraSpacePoint[] cameraSpacePoint)
        {
            var address = String.Format("/kinect{0}", 2);
            return new OscMessage(address, cameraSpacePoint[0].X,  cameraSpacePoint[0].Y,  cameraSpacePoint[0].Z,  body.Joints[JointType.SpineBase].TrackingState.ToString(), 
                                           cameraSpacePoint[1].X,  cameraSpacePoint[1].Y,  cameraSpacePoint[1].Z,  body.Joints[JointType.SpineMid].TrackingState.ToString(),
                                           cameraSpacePoint[2].X,  cameraSpacePoint[2].Y,  cameraSpacePoint[2].Z,  body.Joints[JointType.Neck].TrackingState.ToString(),
                                           cameraSpacePoint[3].X,  cameraSpacePoint[3].Y,  cameraSpacePoint[3].Z,  body.Joints[JointType.Head].TrackingState.ToString(),
                                           cameraSpacePoint[4].X,  cameraSpacePoint[4].Y,  cameraSpacePoint[4].Z,  body.Joints[JointType.ShoulderLeft].TrackingState.ToString(),
                                           cameraSpacePoint[5].X,  cameraSpacePoint[5].Y,  cameraSpacePoint[5].Z,  body.Joints[JointType.ElbowLeft].TrackingState.ToString(),
                                           cameraSpacePoint[6].X,  cameraSpacePoint[6].Y,  cameraSpacePoint[6].Z,  body.Joints[JointType.WristLeft].TrackingState.ToString(),
                                           cameraSpacePoint[7].X,  cameraSpacePoint[7].Y,  cameraSpacePoint[7].Z,  body.Joints[JointType.HandLeft].TrackingState.ToString(),
                                           cameraSpacePoint[8].X,  cameraSpacePoint[8].Y,  cameraSpacePoint[8].Z,  body.Joints[JointType.ShoulderRight].TrackingState.ToString(),
                                           cameraSpacePoint[9].X,  cameraSpacePoint[9].Y,  cameraSpacePoint[9].Z,  body.Joints[JointType.ElbowRight].TrackingState.ToString(),
                                           cameraSpacePoint[10].X, cameraSpacePoint[10].Y, cameraSpacePoint[10].Z, body.Joints[JointType.WristRight].TrackingState.ToString(),
                                           cameraSpacePoint[11].X, cameraSpacePoint[11].Y, cameraSpacePoint[11].Z, body.Joints[JointType.HandRight].TrackingState.ToString(),
                                           cameraSpacePoint[12].X, cameraSpacePoint[12].Y, cameraSpacePoint[12].Z, body.Joints[JointType.HipLeft].TrackingState.ToString(),
                                           cameraSpacePoint[13].X, cameraSpacePoint[13].Y, cameraSpacePoint[13].Z, body.Joints[JointType.KneeLeft].TrackingState.ToString(),
                                           cameraSpacePoint[14].X, cameraSpacePoint[14].Y, cameraSpacePoint[14].Z, body.Joints[JointType.AnkleLeft].TrackingState.ToString(),
                                           cameraSpacePoint[15].X, cameraSpacePoint[15].Y, cameraSpacePoint[15].Z, body.Joints[JointType.FootLeft].TrackingState.ToString(),
                                           cameraSpacePoint[16].X, cameraSpacePoint[16].Y, cameraSpacePoint[16].Z, body.Joints[JointType.HipRight].TrackingState.ToString(),
                                           cameraSpacePoint[17].X, cameraSpacePoint[17].Y, cameraSpacePoint[17].Z, body.Joints[JointType.KneeRight].TrackingState.ToString(),
                                           cameraSpacePoint[18].X, cameraSpacePoint[18].Y, cameraSpacePoint[18].Z, body.Joints[JointType.AnkleRight].TrackingState.ToString(),
                                           cameraSpacePoint[19].X, cameraSpacePoint[19].Y, cameraSpacePoint[19].Z, body.Joints[JointType.FootRight].TrackingState.ToString(),
                                           cameraSpacePoint[20].X, cameraSpacePoint[20].Y, cameraSpacePoint[20].Z, body.Joints[JointType.SpineShoulder].TrackingState.ToString(),
                                           cameraSpacePoint[21].X, cameraSpacePoint[21].Y, cameraSpacePoint[21].Z, body.Joints[JointType.HandTipLeft].TrackingState.ToString(),
                                           cameraSpacePoint[22].X, cameraSpacePoint[22].Y, cameraSpacePoint[22].Z, body.Joints[JointType.ThumbLeft].TrackingState.ToString(),
                                           cameraSpacePoint[23].X, cameraSpacePoint[23].Y, cameraSpacePoint[23].Z, body.Joints[JointType.HandTipRight].TrackingState.ToString(),
                                           cameraSpacePoint[24].X, cameraSpacePoint[24].Y, cameraSpacePoint[24].Z, body.Joints[JointType.ThumbRight].TrackingState.ToString(),
                                           body.JointOrientations[JointType.SpineBase].Orientation.X,      body.JointOrientations[JointType.SpineBase].Orientation.Y,     body.JointOrientations[JointType.SpineBase].Orientation.Z,     body.JointOrientations[JointType.SpineBase].Orientation.W,
                                           body.JointOrientations[JointType.SpineMid].Orientation.X,       body.JointOrientations[JointType.SpineMid].Orientation.Y,      body.JointOrientations[JointType.SpineMid].Orientation.Z,      body.JointOrientations[JointType.SpineMid].Orientation.W,
                                           body.JointOrientations[JointType.Neck].Orientation.X,           body.JointOrientations[JointType.Neck].Orientation.Y,          body.JointOrientations[JointType.Neck].Orientation.Z,          body.JointOrientations[JointType.Neck].Orientation.W,
                                           body.JointOrientations[JointType.Head].Orientation.X,           body.JointOrientations[JointType.Head].Orientation.Y,          body.JointOrientations[JointType.Head].Orientation.Z,          body.JointOrientations[JointType.Head].Orientation.W,
                                           body.JointOrientations[JointType.ShoulderLeft].Orientation.X,   body.JointOrientations[JointType.ShoulderLeft].Orientation.Y,  body.JointOrientations[JointType.ShoulderLeft].Orientation.Z,  body.JointOrientations[JointType.ShoulderLeft].Orientation.W,
                                           body.JointOrientations[JointType.ElbowLeft].Orientation.X,      body.JointOrientations[JointType.ElbowLeft].Orientation.Y,     body.JointOrientations[JointType.ElbowLeft].Orientation.Z,     body.JointOrientations[JointType.ElbowLeft].Orientation.W,
                                           body.JointOrientations[JointType.WristLeft].Orientation.X,      body.JointOrientations[JointType.WristLeft].Orientation.Y,     body.JointOrientations[JointType.WristLeft].Orientation.Z,     body.JointOrientations[JointType.WristLeft].Orientation.W,
                                           body.JointOrientations[JointType.HandLeft].Orientation.X,       body.JointOrientations[JointType.HandLeft].Orientation.Y,      body.JointOrientations[JointType.HandLeft].Orientation.Z,      body.JointOrientations[JointType.HandLeft].Orientation.W,
                                           body.JointOrientations[JointType.ShoulderRight].Orientation.X,  body.JointOrientations[JointType.ShoulderRight].Orientation.Y, body.JointOrientations[JointType.ShoulderRight].Orientation.Z, body.JointOrientations[JointType.ShoulderRight].Orientation.W,
                                           body.JointOrientations[JointType.ElbowRight].Orientation.X,     body.JointOrientations[JointType.ElbowRight].Orientation.Y,    body.JointOrientations[JointType.ElbowRight].Orientation.Z,    body.JointOrientations[JointType.ElbowRight].Orientation.W,
                                           body.JointOrientations[JointType.WristRight].Orientation.X,     body.JointOrientations[JointType.WristRight].Orientation.Y,    body.JointOrientations[JointType.WristRight].Orientation.Z,    body.JointOrientations[JointType.WristRight].Orientation.W,
                                           body.JointOrientations[JointType.HandRight].Orientation.X,      body.JointOrientations[JointType.HandRight].Orientation.Y,     body.JointOrientations[JointType.HandRight].Orientation.Z,     body.JointOrientations[JointType.HandRight].Orientation.W,
                                           body.JointOrientations[JointType.HipLeft].Orientation.X,        body.JointOrientations[JointType.HipLeft].Orientation.Y,       body.JointOrientations[JointType.HipLeft].Orientation.Z,       body.JointOrientations[JointType.HipLeft].Orientation.W,
                                           body.JointOrientations[JointType.KneeLeft].Orientation.X,       body.JointOrientations[JointType.KneeLeft].Orientation.Y,      body.JointOrientations[JointType.KneeLeft].Orientation.Z,      body.JointOrientations[JointType.KneeLeft].Orientation.W,
                                           body.JointOrientations[JointType.AnkleLeft].Orientation.X,      body.JointOrientations[JointType.AnkleLeft].Orientation.Y,     body.JointOrientations[JointType.AnkleLeft].Orientation.Z,     body.JointOrientations[JointType.AnkleLeft].Orientation.W,
                                           body.JointOrientations[JointType.FootLeft].Orientation.X,       body.JointOrientations[JointType.FootLeft].Orientation.Y,      body.JointOrientations[JointType.FootLeft].Orientation.Z,      body.JointOrientations[JointType.FootLeft].Orientation.W,
                                           body.JointOrientations[JointType.HipRight].Orientation.X,       body.JointOrientations[JointType.HipRight].Orientation.Y,      body.JointOrientations[JointType.HipRight].Orientation.Z,      body.JointOrientations[JointType.HipRight].Orientation.W,
                                           body.JointOrientations[JointType.KneeRight].Orientation.X,      body.JointOrientations[JointType.KneeRight].Orientation.Y,     body.JointOrientations[JointType.KneeRight].Orientation.Z,     body.JointOrientations[JointType.KneeRight].Orientation.W,
                                           body.JointOrientations[JointType.AnkleRight].Orientation.X,     body.JointOrientations[JointType.AnkleRight].Orientation.Y,    body.JointOrientations[JointType.AnkleRight].Orientation.Z,    body.JointOrientations[JointType.AnkleRight].Orientation.W,
                                           body.JointOrientations[JointType.FootRight].Orientation.X,      body.JointOrientations[JointType.FootRight].Orientation.Y,     body.JointOrientations[JointType.FootRight].Orientation.Z,     body.JointOrientations[JointType.FootRight].Orientation.W,
                                           body.JointOrientations[JointType.SpineShoulder].Orientation.X,  body.JointOrientations[JointType.SpineShoulder].Orientation.Y, body.JointOrientations[JointType.SpineShoulder].Orientation.Z, body.JointOrientations[JointType.SpineShoulder].Orientation.W,
                                           body.JointOrientations[JointType.HandTipLeft].Orientation.X,    body.JointOrientations[JointType.HandTipLeft].Orientation.Y,   body.JointOrientations[JointType.HandTipLeft].Orientation.Z,   body.JointOrientations[JointType.HandTipLeft].Orientation.W,
                                           body.JointOrientations[JointType.ThumbLeft].Orientation.X,      body.JointOrientations[JointType.ThumbLeft].Orientation.Y,     body.JointOrientations[JointType.ThumbLeft].Orientation.Z,     body.JointOrientations[JointType.ThumbLeft].Orientation.W,
                                           body.JointOrientations[JointType.HandTipRight].Orientation.X,   body.JointOrientations[JointType.HandTipRight].Orientation.Y,  body.JointOrientations[JointType.HandTipRight].Orientation.Z,  body.JointOrientations[JointType.HandTipRight].Orientation.W,
                                           body.JointOrientations[JointType.ThumbRight].Orientation.X,     body.JointOrientations[JointType.ThumbRight].Orientation.Y,    body.JointOrientations[JointType.ThumbRight].Orientation.Z,    body.JointOrientations[JointType.ThumbRight].Orientation.W);                                          
        }
    }
}
