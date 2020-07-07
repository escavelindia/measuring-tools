using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.PostProcessing;

namespace MeasuringTools
{
    public class InstructionMeasuringTools : MonoBehaviour
    {
        public static InstructionMeasuringTools instance;

        [Header("Instruction Panels")]
        public GameObject objectivePanel;
        public RectTransform objectiveTransform;
        public GameObject clickVernierCaliperI;
        public GameObject clickManometerI;
        public GameObject cameraLeftClickI;
        public GameObject cameraFrontClickI;
        public GameObject cameraZoomI;
        public GameObject cameraOrbitI;
        public GameObject showLablesI;
        public GameObject hideLablesI;
        public GameObject clickCmAndMmI;
        public GameObject coinSelectedI;
        public GameObject vernierCaliperZoomInI;
        public GameObject coinRotationI;
        public GameObject setVernierCliaperI;
        //public GameObject enterMeasuredValueI;
        public GameObject submitAnswerI;
        public GameObject checkAnswareI;
        public GameObject tabletClickI;
        public GameObject ductTapeSelectedI;
        public GameObject ductTapePositionI;
        public GameObject resetI;
        public GameObject micrometerClickI;
        public GameObject bearingClickI;
        public GameObject michrometerCloseViewI;
        public GameObject setMichrometerI;
        public GameObject instructionDoneMI;
       


        [Header("UI Properties")]
        public GameObject instructionButton;
        public GameObject exitInstructionMode;
        public GameObject instructionImage;
        //public GameObject 

        public GameObject mainCamera;
        public PostProcessingProfile instructionModeProfile;

        public bool isInstructionClick;
        public bool isScrolligInstruction;
        public bool isObjectSelected;

        public BoxCollider tabletCol;

        public void Awake()
        {
            instance = this;
        }

        private void Start()
        {
            // if state is 1
            // late instruction
            // set state to 0
            if (!PlayerPrefs.HasKey("measuringtools"))
            {
                PlayerPrefs.SetString("measuringtools", "0");
            }

            if (PlayerPrefs.GetString("measuringtools") == "1")
            {
                LateInstructions();
                PlayerPrefs.SetString("measuringtools", "0");
            }
        }

        void LateInstructions()
        {
            isInstructionClick = true;
            instructionButton.SetActive(false);
            exitInstructionMode.SetActive(true);
            mainCamera.GetComponent<PostProcessingBehaviour>().profile = instructionModeProfile;
            objectiveTransform.DOAnchorPos(new Vector2(0, -950f), 1f);
            instructionImage.SetActive(true);
            //disable buttons interactability
            CameraSwitchVernierCaliper.instance.frontButton.interactable = false;
            CameraSwitchVernierCaliper.instance.topButton.interactable = false;
            CameraSwitchVernierCaliper.instance.leftButton.interactable = false;
            CameraSwitchVernierCaliper.instance.rightButton.interactable = false;
            ToolSelection.instance.vernierCliperButton.interactable = false;
            ToolSelection.instance.michrometerButton.interactable = false;
            mainCamera.GetComponent<MouseMovement>().enabled = false;
            UIManager.instance.showLabelB.GetComponent<Button>().interactable = false;
            UIManager.instance.hideLabelB.GetComponent<Button>().interactable = false;

            UIManager.instance.ball.GetComponent<SphereCollider>().enabled = false;
            UIManager.instance.coin10.GetComponent<MeshCollider>().enabled = false;
            UIManager.instance.box.GetComponentInChildren<BoxCollider>().enabled = false;
            UIManager.instance.ductTape.GetComponentInChildren<BoxCollider>().enabled = false;
            UIManager.instance.ductTape.GetComponentInChildren<MeshCollider>().enabled = false;
            UIManager.instance.glass.GetComponentInChildren<MeshCollider>().enabled = false;
            UIManager.instance.glass.GetComponentInChildren<BoxCollider>().enabled = false;
            tabletCol.enabled = false;
        }

        public void InstructionClick()
        {
            PlayerPrefs.SetString("measuringtools", "1");
            UIManager.instance.Reset();            
        }

        public void ObjectiveNextClick()
        {
            objectivePanel.SetActive(false);
            ToolSelection.instance.vernierCliperButton.interactable = true;
            ToolSelection.instance.michrometerButton.interactable = true;
            clickVernierCaliperI.SetActive(true);
            micrometerClickI.SetActive(true);
        }

        public void CameraZoomInstruction()
        {
            isScrolligInstruction = true;
            cameraZoomI.SetActive(false);
            cameraOrbitI.SetActive(true);
            Camera.main.fieldOfView = 50f;
        }

        public void CameraOrbitInstruction()
        {
            MouseMovement.instance.isOrbit = true;
            isScrolligInstruction = false;
            InstructionMeasuringTools.instance.cameraOrbitI.SetActive(false);
            CameraSwitchVernierCaliper.instance.mainCam.GetComponent<MouseMovement>().enabled = false;
            UIManager.instance.showLabelB.GetComponent<Button>().interactable = true;
            InstructionMeasuringTools.instance.showLablesI.SetActive(true);
            CameraSwitchVernierCaliper.instance.FrontCameraView();
            Camera.main.fieldOfView = 60f;
        }

       

        public void BackTOStartingScreen()
        {
            ductTapePositionI.SetActive(false);
            resetI.SetActive(true);
        }

        public void ExitInstructionMode()
        {
            UIManager.instance.Reset();
        }


    }

}
