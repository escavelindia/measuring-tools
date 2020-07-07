using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace MeasuringTools
{
    public class MouseMovement : MonoBehaviour
    {
        public static MouseMovement instance;
        public Transform target;

        public float xSpeed = 120.0f;
        public float ySpeed = 120.0f;
        public float distance = 5.0f;
        public float distanceMin = .5f;
        public float distanceMax = 15f;
        public float yMinLimit = 0f;
        public float yMaxLimit = 90f;

        public float lableShowLimit = 25f;

        Vector3 lastPosition;
        Vector3 negDistance;

        float x = 0.0f;
        float y = 0.0f;

        Vector3 clickedMousePosition, leavedMousePosition;

        public float minZoomV = 20f;
        public float maxZoomV = 70f;

        public bool isScrolling;
        public bool isOrbit;

        private void Awake()
        {
            instance = this;
        }

        void Start()
        {
            Vector3 angles = transform.eulerAngles;
            x = angles.y;
            y = angles.x;
            negDistance = new Vector3(0f, 0f, -distance);
        }

        void LateUpdate()
        {

            if (Input.GetMouseButtonDown(0))
            {
                clickedMousePosition = Input.mousePosition;
                //UIManager.instance.showHideBContainer.SetActive(false);
               
            }

            if (Input.GetMouseButton(0) && !MouseCursor.obstacle)
            {
                UIManager.instance.showHideBContainer.SetActive(false);
                UIManager.instance.HideLabels();
                //Debug.Log("inside mouse movement, why it is not moving?");
                leavedMousePosition = Input.mousePosition;

                // if distance is more than 0.1 then mouse is dragged.
                if (Vector3.Distance(clickedMousePosition, leavedMousePosition) > 0.1f)
                {
                    // CameraSwitchBellJar.instance.objectLables.SetActive(false);
                    x += Input.GetAxis("Mouse X") * xSpeed * 0.02f;
                    y -= Input.GetAxis("Mouse Y") * ySpeed * 0.02f;

                    y = ClampAngle(y, yMinLimit, yMaxLimit);

                    Quaternion rotation = Quaternion.Euler(y, x, 0);

                    Vector3 position = target.position + rotation * new Vector3(negDistance.x, 0.0f, negDistance.z);

                    transform.rotation = rotation;
                    transform.position = position;

                    float angleLimit = Mathf.Lerp(-40f, 40, Mathf.InverseLerp(0f, 40f, (transform.localEulerAngles.y)));
                    //Debug.Log(angleNeedle);

                 }
            }
            if (Input.GetMouseButtonUp(0))
            {
                if (InstructionMeasuringTools.instance.isInstructionClick && !InstructionMeasuringTools.instance.isScrolligInstruction)
                {

                    Debug.Log("hh");
                    InstructionMeasuringTools.instance.cameraOrbitI.SetActive(false);
                    if (isScrolling == true)
                    {
                        isOrbit = true;
                        isScrolling = false;
                        InstructionMeasuringTools.instance.cameraOrbitI.SetActive(false);
                        CameraSwitchVernierCaliper.instance.mainCam.GetComponent<MouseMovement>().enabled = false;
                        UIManager.instance.showLabelB.GetComponent<Button>().interactable = true;
                        InstructionMeasuringTools.instance.showLablesI.SetActive(true);
                        CameraSwitchVernierCaliper.instance.FrontCameraView();
                        Camera.main.fieldOfView = 70f;
                    }
                }
            }

            if (Input.GetAxis("Mouse ScrollWheel") < 0) // back
            {
                isScrolling = true;
                float value = Camera.main.fieldOfView;
                value++;
                float v = Mathf.Clamp(value, minZoomV, maxZoomV);
                //Debug.Log("value : " + v);
                Camera.main.fieldOfView = v;
            }
            if (Input.GetAxis("Mouse ScrollWheel") > 0) // forward
            {
                isScrolling = true;
                float value = Camera.main.fieldOfView;
                value--;
                float v = Mathf.Clamp(value, minZoomV, maxZoomV);
                Camera.main.fieldOfView = v;
            }

            if (InstructionMeasuringTools.instance.isInstructionClick && isScrolling)
            {
                
                InstructionMeasuringTools.instance.cameraZoomI.SetActive(false);
                InstructionMeasuringTools.instance.cameraOrbitI.SetActive(true);
            }
        }

        //private void Update()
        //{
        //    if(Input.GetMouseButtonDown(0))
        //    {
        //        target.position = transform.position;
        //        target.position += transform.forward * 5;
        //    }
        //    if (Input.GetMouseButton(0))
        //        transform.RotateAround(target.position, Vector3.up, 50 * Time.deltaTime);
        //}

        public static float ClampAngle(float angle, float min, float max)
        {
            if (angle < -360F)
                angle += 360F;
            if (angle > 360F)
                angle -= 360F;
            return Mathf.Clamp(angle, min, max);
        }

    }
}