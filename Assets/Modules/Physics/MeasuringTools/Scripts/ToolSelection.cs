using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MeasuringTools
{
    public class ToolSelection : MonoBehaviour
    {

        public static ToolSelection instance;
        [Header("3d objects")]
        public GameObject VernierCaliperGO;
        public GameObject micrometerGO;
        public GameObject vernierObject;
        public GameObject micrometerObjects;


        [Header("UI Properties")]
        public GameObject startingScene;
        public Button vernierCliperButton;
        public Button michrometerButton;

        public bool isVernierCaliper;
        public bool isMicrometer;

        public GameObject cameraPanel;
        public GameObject showHidePanel;

        private void Start()
        {
            instance = this;
            cameraPanel.SetActive(false);
            showHidePanel.SetActive(false);
        }

        public void VernierCaliperSelected()
        {
            VernierCaliper.instance.cmAndMmButtonParent.SetActive(true);
            CameraSwitchVernierCaliper.instance.mainCam.transform.localPosition = CameraSwitchVernierCaliper.instance.frontCamGO.transform.localPosition;
            startingScene.SetActive(false);
            VernierCaliperGO.SetActive(true);
            micrometerGO.SetActive(false);
            vernierObject.SetActive(true);
            micrometerObjects.SetActive(false);
            isVernierCaliper = true;
            isMicrometer = false;
            cameraPanel.SetActive(true);
            showHidePanel.SetActive(true);
            CameraSwitchVernierCaliper.instance.mainCam.GetComponent<MouseCursor>().enabled = true;
            CameraSwitchVernierCaliper.instance.mainCam.GetComponent<MouseMovement>().enabled = true;

            if(InstructionMeasuringTools.instance.isInstructionClick)
            {
                CameraSwitchVernierCaliper.instance.mainCam.GetComponent<MouseMovement>().enabled = false;
                CameraSwitchVernierCaliper.instance.leftButton.interactable = true;
                InstructionMeasuringTools.instance.clickVernierCaliperI.SetActive(false);
                InstructionMeasuringTools.instance.cameraLeftClickI.SetActive(true);
                MiliMeterSelection.instance.miliMeterButton.GetComponent<BoxCollider>().enabled = false;
                CentimeterScale.instance.cmButtonObject.GetComponent<BoxCollider>().enabled = false;
                UIManager.instance.setB.GetComponentInParent<Button>().interactable = false;
                UIManager.instance.resetB.GetComponentInParent<Button>().interactable = false;
                VernierCaliper.instance.zoomInB_Vernier.GetComponent<Button>().interactable = false;
            }
        }

        public void MicrometerSelected()
        {
            VernierCaliper.instance.cmAndMmButtonParent.SetActive(false);
            CameraSwitchVernierCaliper.instance.mainCam.transform.localPosition = CameraSwitchVernierCaliper.instance.frontCamGO.transform.localPosition;
            startingScene.SetActive(false);
            VernierCaliperGO.SetActive(false);
            micrometerGO.SetActive(true);
            vernierObject.SetActive(false);
            micrometerObjects.SetActive(true);
            isVernierCaliper = false;
            isMicrometer = true;
            cameraPanel.SetActive(true);
            showHidePanel.SetActive(true);
            CameraSwitchVernierCaliper.instance.mainCam.GetComponent<MouseCursor>().enabled = true;
            CameraSwitchVernierCaliper.instance.mainCam.GetComponent<MouseMovement>().enabled = true;

            if (InstructionMeasuringTools.instance.isInstructionClick)
            {
                Debug.Log("g");
                CameraSwitchVernierCaliper.instance.mainCam.GetComponent<MouseMovement>().enabled = false;
                CameraSwitchVernierCaliper.instance.leftButton.interactable = true;
                InstructionMeasuringTools.instance.micrometerClickI.SetActive(false);
                InstructionMeasuringTools.instance.cameraLeftClickI.SetActive(true);
            }
        }
    }
}