using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MeasuringTools
{
    public class Micrometer : MonoBehaviour
    {

        public static Micrometer instance;

        public Rigidbody rb;

        [Header("UI Properties")]
        public GameObject zoomInMB_Micrometer;
        public GameObject zoomOutMB_Micrometer;

        private Vector3 screenPoint;
        private Vector3 offset;
        public float moveSpeed;

        public bool isLeftDrag;
        public bool isRightDrag;

        public Animator rodRotation;

        public void Start()
        {
            instance = this;
        }

        void OnMouseDown()
        {
            screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);

            offset = gameObject.transform.position - Camera.main.ScreenToViewportPoint(new Vector3(Input.mousePosition.x, screenPoint.y, screenPoint.z));
            Debug.Log("hh");
            Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, screenPoint.y, screenPoint.z);

            Vector3 curPosition = Camera.main.ScreenToViewportPoint(curScreenPoint) + offset;
            //transform.position = curPosition;


            LeftMove();


         
        }


        public void LeftMove()
        {
            if (BallMSelection.instance.isBallMSelected)
            {
                // rodRotation.SetTrigger("Ideal");
                rodRotation.SetTrigger("BallS");
                rodRotation.SetBool("IsMicrometerOpen", false);
            }
           
            if (PaperSelection.instance.isPaperSelected)
            {
                rodRotation.SetBool("IsMicrometerOpen", false);
                // rodRotation.SetTrigger("Ideal");
                rodRotation.SetTrigger("Paper");
            }
            if (ThickWireSelection.instance.isThickWireSelected)
            {
                rodRotation.SetBool("IsMicrometerOpen", false);
                rodRotation.SetTrigger("ThickWire");
            }
            if (ThinWireSelection.instance.isThinWireSelected)
            {
                rodRotation.SetBool("IsMicrometerOpen", false);
                rodRotation.SetTrigger("ThinWire");
            }
        }

        // when you select a object.
        public void ResettingMicrometer()
        {
            //Invoke("RodMoveDelayRight", 1f);
            //if(rodRotation.GetBool("BallS") && )
            //rodRotation.SetTrigger("Set");
            rodRotation.SetBool("IsMicrometerOpen", true);

        }

       
        public void LeftDragM()
        {
            //isLeftDrag = true;
            //isRightDrag = false;
            OnMouseDown();
            if (InstructionMeasuringTools.instance.isInstructionClick)
            {
                InstructionMeasuringTools.instance.setMichrometerI.SetActive(false);
                InstructionMeasuringTools.instance.submitAnswerI.SetActive(true);
            }
        }

        public void RightDragM()
        {
           
            OnMouseDown();

        }


        public void ZoomInMicrometer()
        {
            zoomInMB_Micrometer.SetActive(false);
            zoomOutMB_Micrometer.SetActive(true);
            CameraSwitchVernierCaliper.instance.MicrometerCloseView();

            if(InstructionMeasuringTools.instance.isInstructionClick)
            {
                InstructionMeasuringTools.instance.michrometerCloseViewI.SetActive(false);
                InstructionMeasuringTools.instance.setMichrometerI.SetActive(true);
            }
        }

        public void ZoomOutMicrometer()
        {
            zoomInMB_Micrometer.SetActive(true);
            zoomOutMB_Micrometer.SetActive(false);
            CameraSwitchVernierCaliper.instance.FrontCameraView();
        }
    }
}