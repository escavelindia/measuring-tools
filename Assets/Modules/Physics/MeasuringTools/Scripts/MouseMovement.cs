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
        Camera cam;

        Vector3 lastPosition;
        Vector3 negDistance;

        float x = 0.0f;
        float y = 0.0f;

        Vector3 clickedMousePosition, leavedMousePosition;

        public float minZoomV = 20f;
        public float maxZoomV = 70f;

        public bool isScrolling;
        public bool isOrbit;
        // mobile variables
        Vector2 firstpoint;
        private Vector2 secondpoint;
        private float xAngle; //angle for axes x for rotation
        private float yAngle;
        private float xAngTemp; //temp variable for angle
        private float yAngTemp;
        float TouchZoomSpeed = 0.1f;
        public GameObject mobileControlMessage;
        public GameObject sliderZoom;

        float ZoomMinBound = 20f;
        float ZoomMaxBound = 70f;

        private void Awake()
        {
            instance = this;
        }

        void Start()
        {
            cam = Camera.main;

            Vector3 angles = transform.eulerAngles;
            x = angles.y;
            y = angles.x;
            negDistance = new Vector3(0f, 0f, -distance);
            if (Input.touchSupported)
            {
                xAngle = x;
                yAngle = y;
                transform.rotation = Quaternion.Euler(yAngle, xAngle, 0.0f);
                xSpeed = 60f;
                ySpeed = 60f;
                if (PlayerPrefs.GetInt("seenMobileInputInfo") == 0)
                {
                    mobileControlMessage.SetActive(true);
                    PlayerPrefs.SetInt("seenMobileInputInfo", 1);
                }
            }
        }
        void TouchZoom()
        {
            // Pinch to zoom
            if (Input.touchCount >= 2)
            {
                isScrolling = true;
                // get current touch positions
                Touch tZero = Input.GetTouch(0);
                Touch tOne = Input.GetTouch(1);
                // get touch position from the previous frame
                Vector2 tZeroPrevious = tZero.position - tZero.deltaPosition;
                Vector2 tOnePrevious = tOne.position - tOne.deltaPosition;

                float oldTouchDistance = Vector2.Distance(tZeroPrevious, tOnePrevious);
                float currentTouchDistance = Vector2.Distance(tZero.position, tOne.position);

                // get offset value
                float deltaDistance = oldTouchDistance - currentTouchDistance;
                Zoom(deltaDistance, TouchZoomSpeed);

                // different 
                if (InstructionMeasuringTools.instance.isInstructionClick && isScrolling)
                {

                    InstructionMeasuringTools.instance.cameraZoomI.SetActive(false);
                    InstructionMeasuringTools.instance.cameraOrbitI.SetActive(true);
                }

            }
            else if (target && Input.touchCount == 1/* && Input.GetTouch(0).position.x > Screen.width / 2*/ && Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                Orbit(Input.GetTouch(0));

            }

            else if (Input.GetTouch(0).phase == TouchPhase.Ended && Input.touchCount == 1)
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
          
        }
        void Orbit(Touch touch)
        {
            if (!MouseCursor.obstacle)
            {
                x += touch.deltaPosition.x * xSpeed * 0.01f /* * distance*/;
                y -= touch.deltaPosition.y * ySpeed * 0.01f /* * distance*/;
                y = ClampAngle(y, yMinLimit, yMaxLimit);

                Quaternion rotation = Quaternion.Euler(y, x, 0);

                //distance = Mathf.Clamp(distance - Input.GetAxis("Mouse ScrollWheel") * 5, distanceMin, distanceMax);

                //RaycastHit hit;

                //if (Physics.Linecast(target.position, transform.position, out hit))
                //{
                //}
                Vector3 negDistance = new Vector3(0.0f, 0.0f, -distance);
                Vector3 position = rotation * negDistance + target.position;
                transform.rotation = rotation;
                transform.position = position;
            }
        }

        void Zoom(float deltaMagnitudeDiff, float speed)
        {
            cam.fieldOfView += deltaMagnitudeDiff * speed;
            // set min and max value of Clamp function upon your requirement
            cam.fieldOfView = Mathf.Clamp(cam.fieldOfView, ZoomMinBound, ZoomMaxBound);
        }
        void LateUpdate()
        {
            if (Input.touchSupported)
                TouchZoom();
            else
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