using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MeasuringTools
{
    public class CameraSwitchVernierCaliper : MonoBehaviour
    {

        public static CameraSwitchVernierCaliper instance;

        private Vector3 frontPos;
        private Vector2 frontPosSolid;
        private Vector3 leftPos;
        private Vector3 rightPos;
        private Vector3 topPos;
        private Vector3 vernierCaliperPos;
        private Vector3 micrometerPos;
        private Vector3 tabletCloseViewPos;

        private Vector3 frontRotation;
        private Vector2 frontPosSolidRotation;
        private Vector3 leftRotation;
        private Vector3 rightRotation;
        private Vector3 topRotation;
        private Vector3 vernierCaliperRotation;
        private Vector3 micrometerRotation;
        private Vector3 tabletCloseViewRotation;


        [Header("GameObject for cam posAndrot")]
        public GameObject frontCamGO;
        public GameObject leftCamGO;
        public GameObject rightCamGO;
        public GameObject topCamGO;
        public GameObject vernierCaliperGO;
        public GameObject micrometerGO;
        public GameObject tabletViewGO;

        [Header("UI buttons")]
        public Button frontButton;
        public Button leftButton;
        public Button topButton;
        public Button rightButton;

        public GameObject mainCam;
        public float orthographicSizeToolClose = 0.4f;

        public float camMoveSpeed = 5f;

        public Text camViewText;

        public float minScrollV = 0.2f;
        public float maxScrollV = 0.4f;

        public float panSensitivity = 0.5f;

        public Vector3 touchStart;
        public bool isToolCloseView;
        public bool isTopView;
        //public bool isTabletCloseView;

        private void Start()
        {
            instance = this;
            //exract object Positions and rotation
            frontPos = frontCamGO.transform.localPosition;
            leftPos = leftCamGO.transform.localPosition;
            rightPos = rightCamGO.transform.localPosition;
            topPos = topCamGO.transform.localPosition;
            vernierCaliperPos = vernierCaliperGO.transform.localPosition;
            micrometerPos = micrometerGO.transform.localPosition;
            tabletCloseViewPos = tabletViewGO.transform.localPosition;


            frontRotation = frontCamGO.transform.eulerAngles;
            leftRotation = leftCamGO.transform.eulerAngles;
            rightRotation = rightCamGO.transform.eulerAngles;
            topRotation = topCamGO.transform.eulerAngles;
            vernierCaliperRotation = vernierCaliperGO.transform.eulerAngles;
            micrometerRotation = micrometerGO.transform.localEulerAngles;
            tabletCloseViewRotation = tabletViewGO.transform.localEulerAngles;

            mainCam.GetComponent<MouseCursor>().enabled = false;
            mainCam.GetComponent<MouseMovement>().enabled = false;

        }

        public void Update()
        {
            if (isToolCloseView)
            {
                if (Input.GetAxis("Mouse ScrollWheel") < 0)
                {
                    float scrollValue = mainCam.GetComponent<Camera>().orthographicSize;
                    scrollValue = scrollValue + 0.1f;
                    float scrollVLimit = Mathf.Clamp(scrollValue, minScrollV, maxScrollV);
                    mainCam.GetComponent<Camera>().orthographicSize = scrollVLimit;

                }

                if (Input.GetAxis("Mouse ScrollWheel") > 0)
                {
                    float scrollVAlue = mainCam.GetComponent<Camera>().orthographicSize;
                    scrollVAlue = scrollVAlue - 0.1f;
                    float scrollLimit = Mathf.Clamp(scrollVAlue, minScrollV, maxScrollV);
                    mainCam.GetComponent<Camera>().orthographicSize = scrollLimit;
                }

                if (Input.GetMouseButtonDown(0))
                {
                    touchStart = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                }
                if (Input.GetMouseButton(0))
                {
                    Vector3 direction = (touchStart - Camera.main.ScreenToWorldPoint(Input.mousePosition));
                    Camera.main.transform.position += direction;
                    Camera.main.transform.position = new Vector3(Mathf.Clamp(Camera.main.transform.position.x, -1.5f, 1.5f), Mathf.Clamp(Camera.main.transform.position.y, -0.5f, 0.5f), 0f);
                }

            }
  }
      

        public void FrontCameraView()
        {
          
            mainCam.GetComponent<Camera>().orthographic = false;
            iTween.MoveTo(mainCam.gameObject, frontPos, camMoveSpeed);
            iTween.RotateTo(mainCam.gameObject, frontRotation, camMoveSpeed);
            camViewText.text = "Front View";
            if (InstructionMeasuringTools.instance.isInstructionClick)
            {
                mainCam.GetComponent<MouseMovement>().enabled = false;
            }
            else
            {
                mainCam.GetComponent<MouseMovement>().enabled = true;
            }
           
            isToolCloseView = false;
            isToolCloseView = false;
            if(ToolSelection.instance.isVernierCaliper)
            {
                VernierCaliper.instance.zoomInB_Vernier.SetActive(true);
                VernierCaliper.instance.zoomOutB_Vernier.SetActive(false);
            }
            if (ToolSelection.instance.isMicrometer)
            {
                Micrometer.instance.zoomInMB_Micrometer.SetActive(true);
                Micrometer.instance.zoomOutMB_Micrometer.SetActive(false);
            }
            UIManager.instance.showHideBContainer.SetActive(true);

            if(InstructionMeasuringTools.instance.isInstructionClick && !MouseMovement.instance.isOrbit)
            {
                
                InstructionMeasuringTools.instance.cameraFrontClickI.SetActive(false);
                frontButton.interactable = false;
                InstructionMeasuringTools.instance.cameraZoomI.SetActive(true);
                mainCam.GetComponent<MouseMovement>().enabled = true;
            }

            
        }

        public void LeftCameraView()
        {
           
            mainCam.GetComponent<Camera>().orthographic = false;
            iTween.MoveTo(mainCam.gameObject, leftPos, camMoveSpeed);
            iTween.RotateTo(mainCam.gameObject, leftRotation, camMoveSpeed);
            camViewText.text = "Left View";
            mainCam.GetComponent<MouseMovement>().enabled = true;
            isToolCloseView = false;
            isTopView = false;
            UIManager.instance.showHideBContainer.SetActive(false);

            if(InstructionMeasuringTools.instance.isInstructionClick)
            {
                mainCam.GetComponent<MouseMovement>().enabled = false;
                InstructionMeasuringTools.instance.cameraLeftClickI.SetActive(false);
                CameraSwitchVernierCaliper.instance.leftButton.interactable = false;
                frontButton.interactable = true;
                InstructionMeasuringTools.instance.cameraFrontClickI.SetActive(true);
            }
        }

        public void RightCameraView()
        {
           
            mainCam.GetComponent<Camera>().orthographic = false;
            iTween.MoveTo(mainCam.gameObject, rightPos, camMoveSpeed);
            iTween.RotateTo(mainCam.gameObject, rightRotation, camMoveSpeed);
            camViewText.text = "Right View";
            mainCam.GetComponent<MouseMovement>().enabled = true;
            isToolCloseView = false;
            isTopView = false;
            UIManager.instance.showHideBContainer.SetActive(false);
        }

        public void TopCameraView()
        {
           
            mainCam.GetComponent<Camera>().orthographic = false;
            iTween.MoveTo(mainCam.gameObject, topPos, camMoveSpeed);
            iTween.RotateTo(mainCam.gameObject, topRotation, camMoveSpeed);
            camViewText.text = "Top View";
            mainCam.GetComponent<Camera>().orthographicSize = 0.85f;
            mainCam.GetComponent<MouseMovement>().enabled = true;
            maxScrollV = 1f;
            isToolCloseView = false;
            isTopView = true;
            UIManager.instance.showHideBContainer.SetActive(false);
        }

        public void VernierCaliperCloseView()
        {
            
            mainCam.GetComponent<Camera>().orthographic = true;
            mainCam.GetComponent<Camera>().orthographicSize = orthographicSizeToolClose;
            iTween.MoveTo(mainCam.gameObject, vernierCaliperPos, camMoveSpeed);
            iTween.RotateTo(mainCam.gameObject, vernierCaliperRotation, camMoveSpeed);
            camViewText.text = "Vernier Caliper View";
            isToolCloseView = true;
            isTopView = true;
            UIManager.instance.showHideBContainer.SetActive(false);

        }

        public void TabletCloseView()
        {
           
            iTween.MoveTo(mainCam.gameObject, tabletCloseViewPos, camMoveSpeed);
            iTween.RotateTo(mainCam.gameObject, tabletCloseViewRotation, camMoveSpeed);
            camViewText.text = "Tablet Close View";
            mainCam.GetComponent<Camera>().orthographic = false;
            isToolCloseView = false;
            UIManager.instance.showHideBContainer.SetActive(false);


        }

        public void MicrometerCloseView()
        {
           
            mainCam.GetComponent<Camera>().orthographic = true;
            mainCam.GetComponent<Camera>().orthographicSize = orthographicSizeToolClose;
            iTween.MoveTo(mainCam.gameObject, micrometerPos, camMoveSpeed);
            iTween.RotateTo(mainCam.gameObject, micrometerRotation, camMoveSpeed);
            camViewText.text = "Micrometer View";
            mainCam.GetComponent<MouseMovement>().enabled = false;
            isToolCloseView = true;
            isTopView = true;
            UIManager.instance.showHideBContainer.SetActive(false);

        }






    }
}