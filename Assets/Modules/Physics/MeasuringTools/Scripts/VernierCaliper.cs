using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace MeasuringTools
{
    public class VernierCaliper : MonoBehaviour
    {

        public static VernierCaliper instance;

        public Rigidbody rbSlider;

        public bool isVernierCZoom;
        public BoxCollider verUpperCol;

        public GameObject vernierScaleSlideGO;
        public Slider vernierSlider;
        public GameObject vernierCaliperGO;
        public GameObject vernierScaleGO;

        public GameObject vernirCaliperRotateGO;
        public Vector3 vernierCaliperRot;
        public Vector3 vernierCaliperStartRot;
        public float vernierRotateSpeed = 5f;

        public float slidingValue = 0.01f;
        public bool isVernierRotated;
        public float sliderValue;

        public float slideValuseUpperJaws = 0.8969247f;

        public bool isVernierScaleSliding = true;

        public Vector3 vernierScaleStartPos;
        public Vector3 vernierScaleResetPos;

        [Header("UI Properties")]
        public GameObject zoomInB_Vernier;
        public GameObject zoomOutB_Vernier;
        public Text cmAndmmText;
        public GameObject freezButton;

        public Rigidbody rb;

        private Vector3 screenPoint;
        private Vector3 offset;
        public float moveSpeed;

        public bool isLeftDrag;
        public bool isRightDrag;
        public bool isFreezVC;

        public GameObject mmScale;
        public GameObject cmScale;
        public Material cmAndmmHighlightdMat;
        public Material cmAndmmMat;
        public GameObject cmAndMmButtonParent;

        public void Awake()
        {
            instance = this;
        }
        public void Start()
        {
            vernierCaliperRot = vernirCaliperRotateGO.transform.localEulerAngles;
            vernierCaliperStartRot = vernierCaliperGO.transform.localEulerAngles;
            vernierScaleStartPos = vernierScaleGO.transform.localPosition;
            MiliMeterScaleslected();


        }

        private void OnMouseEnter()
        {

        }
        void OnMouseDown()
        {
            screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);

            offset = gameObject.transform.position - Camera.main.ScreenToViewportPoint(new Vector3(Input.mousePosition.x, screenPoint.y, screenPoint.z));
            Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, screenPoint.y, screenPoint.z);

            Vector3 curPosition = Camera.main.ScreenToViewportPoint(curScreenPoint) + offset;

            if (isLeftDrag)
            {
                if (UIManager.instance.isSetResetToggle == false)
                {
                    rb.velocity = Vector3.left;//*(-curPosition);
                }
                if (UIManager.instance.isSetResetToggle == true)
                {
                    rb.velocity = Vector3.right;
                }
              
            }

            if (isRightDrag)
            {
                if (UIManager.instance.isSetResetToggle == false)
                {
                    rb.velocity = Vector3.right;
                }
                if (UIManager.instance.isSetResetToggle == true)
                {
                    rb.velocity = Vector3.left; 
                }
               
            }
        }

        public void FreezVernierC()
        {
            isFreezVC = !isFreezVC;
            if (isFreezVC)
            {
                freezButton.GetComponentInChildren<Text>().text = "Unfreeze Vernier Caliper";
                rb.isKinematic = true;
            }
            else
            {
                freezButton.GetComponentInChildren<Text>().text = "Freeze       Vernier Caliper";
                rb.isKinematic = false;
            }
        }
        public void ZoomInVC()
        {
            CameraSwitchVernierCaliper.instance.VernierCaliperCloseView();
            zoomInB_Vernier.SetActive(false);
            zoomOutB_Vernier.SetActive(true);
            CameraSwitchVernierCaliper.instance.mainCam.GetComponent<MouseMovement>().enabled = false;

            if (InstructionMeasuringTools.instance.isInstructionClick)
            {
                InstructionMeasuringTools.instance.vernierCaliperZoomInI.SetActive(false);
                VernierCaliper.instance.zoomInB_Vernier.GetComponent<Button>().interactable = false;
                InstructionMeasuringTools.instance.coinRotationI.SetActive(true);
            }

        }

        public void ZoomOutVC()
        {
            CameraSwitchVernierCaliper.instance.FrontCameraView();
            zoomInB_Vernier.SetActive(true);
            zoomOutB_Vernier.SetActive(false);
            CameraSwitchVernierCaliper.instance.mainCam.GetComponent<MouseMovement>().enabled = true;
        }


        public void LeftClick()
        {
            isLeftDrag = true;
            isRightDrag = false;

            OnMouseDown();

            if (InstructionMeasuringTools.instance.isInstructionClick)
            {
                //UIManager.instance.setB.GetComponentInParent<Button>().interactable = false;
                InstructionMeasuringTools.instance.setVernierCliaperI.SetActive(false);
                InstructionMeasuringTools.instance.submitAnswerI.SetActive(true);
            }
            
        }

        public void RightClick()
        {
            isRightDrag = true;
            isLeftDrag = false;

            OnMouseDown();
        }

        //When Touching UI
        private bool IsPointerOverUIObject()
        {
            PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
            eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            List<RaycastResult> results = new List<RaycastResult>();
            EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
            return results.Count > 0;
        }

        public void IncreaseSliderValue()
        {
            vernierSlider.value = vernierSlider.value + slidingValue;
        }

        public void DecreaseSliderValue()
        {
            vernierSlider.value = vernierSlider.value - slidingValue;

        }

        public void RotateVernierCaliper()
        {
            isVernierRotated = !isVernierRotated;
            if (isVernierRotated)
            {
                iTween.RotateTo(vernierCaliperGO, vernierCaliperRot, vernierRotateSpeed);
            }
            else
            {
                iTween.RotateTo(vernierCaliperGO, vernierCaliperStartRot, vernierRotateSpeed);
            }

        }

        public void ResetVernierScale()
        {
            vernierScaleSlideGO.transform.localPosition = vernierScaleStartPos;

        }
        public void SetVernierScale()
        {
            vernierScaleSlideGO.transform.localPosition = vernierScaleResetPos;
        }

        //selected cenetimeter scale
        public void CentimeterScaleSelected()
        {
            CentimeterScale.instance.isCMSelected = true;
            MiliMeterSelection.instance.isMMSelected = false;
            cmAndmmText.text = "cm";
            cmScale.SetActive(true);
            mmScale.SetActive(false);
            CentimeterScale.instance.cmButtonObject.GetComponent<Renderer>().material = cmAndmmHighlightdMat;
            MiliMeterSelection.instance.miliMeterButton.GetComponent<Renderer>().material = cmAndmmMat;
            //UIManager.instance.CrossCheckScreen();

            if (InstructionMeasuringTools.instance.isInstructionClick)
            {
                InstructionMeasuringTools.instance.clickCmAndMmI.SetActive(false);
                InstructionMeasuringTools.instance.coinSelectedI.SetActive(true);
                UIManager.instance.coin10.GetComponent<MeshCollider>().enabled = true;
                CentimeterScale.instance.cmButtonObject.GetComponent<BoxCollider>().enabled = false;
                
            }
        }

        //selectedw meter scale
        public void MiliMeterScaleslected()
        {
            CentimeterScale.instance.isCMSelected = false;
            MiliMeterSelection.instance.isMMSelected = true;
            cmAndmmText.text = "mm";
            cmScale.SetActive(false);
            mmScale.SetActive(true);
            CentimeterScale.instance.cmButtonObject.GetComponent<Renderer>().material = cmAndmmMat;
            MiliMeterSelection.instance.GetComponent<Renderer>().material = cmAndmmHighlightdMat;
            //UIManager.instance.CrossCheckScreen();
        }
    }
}