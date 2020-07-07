using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MeasuringTools
{
    public class BillBoard : MonoBehaviour
    {

        public Camera m_Camera;
        public Vector3 offset;

        //Orient the camera after all movement is completed this frame to avoid jittering
        void LateUpdate()
        {
            transform.LookAt(transform.position + m_Camera.transform.localRotation * Vector3.forward + offset);
        }
    }
}