using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace MeasuringTools
{
    public class UIManager : MonoBehaviour
    {


        public static UIManager instance;

        //public Material outLineShader;
        public float outlineShaderWidth = 0.002f;
        public float objectMoveSpeed = 5f;

        [Header("UI Properties")]
        public GameObject toolSelection;
        public GameObject objectDimensionText;

        public GameObject tabletStartPanel;
        public GameObject objectiveTitle;
        public GameObject objectObjective;
        public GameObject inputField;
        public GameObject ObjectDimensionPanel;
        public GameObject tabletScreen;
        public GameObject warningMessgForTape;
        public GameObject objectRotationB;
        public GameObject ObjectOriginalRotationB;
        public GameObject objectRotationBMicrometer;
        public GameObject ObjectOriginalRotationBMicrometer;
        public GameObject objectPositionOnVC_Panel;
        public GameObject upperJawB;
        public GameObject lowerJawB;
        public GameObject depthB;
        public GameObject setB;
        public GameObject resetB;
        public GameObject vcObjectsLabelCanvas;
        public GameObject mObjectsLabelCanvas;
        public GameObject showLabelB;
        public GameObject hideLabelB;
        public GameObject showHideBContainer;

        [Header("3d Objects")]
        public GameObject ball;
        public GameObject ballM;
        public GameObject glass;
        public GameObject box;
        public GameObject coin10;
        public GameObject coin10M;
        public GameObject ductTape;
        public GameObject paper;
        public GameObject thinWire;
        public GameObject thickWire;


        [Header("ball object Parameter")]
        public GameObject ballPosInVC;
        public GameObject ballPosInMicrometer;
        private Vector3 ballStartPos;
        public GameObject ballDimensionPanel;


        [Header("coin Object Parameter")]
        public GameObject coin10PosInVC;
        public GameObject coinPosInVC_Rotation;
        public GameObject coin10PosInMicrometer;
        public GameObject coinPosInVC_RotationMicrometer;
        public GameObject coinStart10Pos;
        public GameObject coinDimensionPanel;
        public GameObject coinDiameterDimension;
        public GameObject coinThicknessDimension;

        [Header("Box Object Parameter")]
        public GameObject boxPosInVC;
        public GameObject boxPosInVC_Rotation;
        public GameObject boxPosInMicrometer;
        public GameObject boxPosInVC_RotationMicrometer;
        public GameObject boxStartPos;
        public GameObject boxDimensionPanel;
        public GameObject boxLengthDimension;
        public GameObject boxWidthDimension;

        [Header("glass object Parameter")]
        public GameObject glassPosInVC;
        public GameObject glassPosInVCLowerJaws;
        public GameObject glassPosInUpperJaws;
        public GameObject glassPosInVCUpperJaws;
        public GameObject glassPosInVCDepthRod;
        public GameObject glassPosInMicrometer;
        public GameObject glassStartPos;
        public GameObject glassDimensionPanel;
        public GameObject glassDimensionInner;
        public GameObject glassDimensionOuter;
        public GameObject glasseDimensionDepth;

        [Header("duct Tape parameters")]
        public GameObject ductTapePosInVCLowerJaws;
        public GameObject ductTapePosInUpperJaws;
        public GameObject ductTapePosInVCUpperJaws;
        public GameObject ductTapePosInVCDepthRod;
        public GameObject ductTapePosInMicrometer;
        public GameObject ductTapeStartPos;
        public GameObject ductTapeDimensionPanel;
        public GameObject ductTapeDimensionInner;
        public GameObject ductTapeDimensionOuter;
        public GameObject ductTapeDimensionDepth;

        [Header("Paper Parameters")]
        public GameObject paperPositionInM;
        public GameObject paperStartPos;
        public GameObject paperDimnesionPanel;

        [Header("BallM Properties")]
        public GameObject ballPositionInM;
        public GameObject ballMStartPos;
        public GameObject bearingDimensionPanel;

        [Header("Thin Wire Properties")]
        public GameObject thinWirePosMicormeter;
        public GameObject thinWireStartPos;
        public GameObject thinWireDimensionPanel;

        [Header("Thick Wire Properties")]
        public GameObject thickWirePosMicrometer;
        public GameObject thickWireStartPos;
        public GameObject thickWireDimensionPanel;

        public bool isBallMove;
        public bool istoolSelected;

        public bool isSubmitPressed;
        public bool isObjectRotated;

        public bool isobjectLowerJaw;
        public bool isObjectUpperJaw;
        public bool isObjctDepthRod;
        public bool isHideLables;

        public Color normalColor = new Color();
        public Color clickedColor = new Color();

        public bool isSetResetToggle;

        private void Start()
        {
            istoolSelected = false;
            tabletStartPanel.SetActive(true);
            instance = this;
            Time.timeScale = 1f;
            //ballPosVC = ballInVC.transform.localPosition;
            ballStartPos = ball.transform.localPosition;
            //coinStart10Pos= coin10.transform.localPosition;
            //boxStartPos= box.transform.localPosition;
            //glassStartPos = glass.transform.localPosition;
            //ductTapeStartPosLowerJaws = ductTape.transform.localPosition;
            isobjectLowerJaw = true;
            isObjctDepthRod = false;
            isObjectUpperJaw = false;
            objectObjective.GetComponent<Text>().text = "Measure the Given Objects Dimensions";
            showLabelB.SetActive(true);
            hideLabelB.SetActive(false);
        }

        private void Update()
        {
            if(Input.GetKey(KeyCode.Return))
            {
                SubmitClick();
               
            }
        }


        public void SubmitClick()
        {
            isSubmitPressed = true;
            CheckAnswereInputField.instance.CheckAnswer();
            if (InstructionMeasuringTools.instance.isInstructionClick)
            {
                if (ToolSelection.instance.isVernierCaliper)
                {
                    UIManager.instance.setB.GetComponentInParent<Button>().interactable = false;
                }
               
                InstructionMeasuringTools.instance.submitAnswerI.SetActive(false);
                UIManager.instance.coin10.GetComponent<MeshCollider>().enabled = false;
                InstructionMeasuringTools.instance.checkAnswareI.SetActive(true);
            }
        }



        public void VernierCaliperSelected()
        {
            istoolSelected = true;
            isSubmitPressed = false;
            inputField.SetActive(true);
            toolSelection.SetActive(false);
            objectDimensionText.SetActive(false);
            VernierCaliper.instance.isFreezVC = true;
            VernierCaliper.instance.FreezVernierC();
            CheckAnswereInputField.instance.wrongAnswer.SetActive(false);
            CheckAnswereInputField.instance.rightAnswer.SetActive(false);
            CentimeterScale.instance.cmButtonObject.GetComponent<CentimeterScale>().enabled = true;
            MiliMeterSelection.instance.GetComponent<MiliMeterSelection>().enabled = true;
            VernierCaliper.instance.cmAndMmButtonParent.SetActive(true);
            warningMessgForTape.SetActive(false);
            //VernierCaliper.instance.ZoomInVC();
            setB.GetComponent<Text>().text = "Set";
            resetB.GetComponent<Text>().text = "Reset";
            isSetResetToggle = false;
            VernierCaliper.instance.verUpperCol.GetComponent<BoxCollider>().enabled = false;
            //UIManager.instance.showHideBContainer.SetActive(false);
            HideLabels();
            if (BallSelection.instance.isBallSelected)
            {
                //Debug.Log("ballSelected");
                //ball.transform.localPosition = ballPosVC;
                objectPositionOnVC_Panel.SetActive(false);
                iTween.MoveTo(ball.gameObject, ballPosInVC.transform.localPosition, objectMoveSpeed);
                iTween.MoveTo(coin10.gameObject, coinStart10Pos.transform.localPosition, objectMoveSpeed);
                iTween.RotateTo(coin10.gameObject, coinStart10Pos.transform.localEulerAngles, objectMoveSpeed);
                iTween.MoveTo(glass.gameObject, iTween.Hash("position", glassStartPos.transform.localPosition, "time", 1f, "oncompletetarget", gameObject, "oncomplete", "EnableColliderGlass"));
                iTween.RotateTo(glass.gameObject, glassStartPos.transform.localEulerAngles, objectMoveSpeed);
                iTween.MoveTo(ductTape.gameObject, iTween.Hash("position", ductTapeStartPos.transform.localPosition, "time", 1f, "oncompletetarget", gameObject, "oncomplete", "EnableColliderTape"));
                iTween.RotateTo(ductTape.gameObject, ductTapeStartPos.transform.localEulerAngles, objectMoveSpeed);
                iTween.MoveTo(box.gameObject, iTween.Hash("position", boxStartPos.transform.localPosition, "time", 1f, "oncompletetarget", gameObject, "oncomplete", "EnableBoxCollider"));
                iTween.RotateTo(box.gameObject, boxStartPos.transform.localEulerAngles, objectMoveSpeed);
                //BallSelection.instance.outlineShader.SetFloat("_Outline", 0f);
                objectRotationB.SetActive(false);
                ObjectOriginalRotationB.SetActive(false);
                
            }
            if (GlassSelection.instance.isGlassSelected)
            {
                objectPositionOnVC_Panel.SetActive(true);
                iTween.MoveTo(glass.gameObject, glassPosInVC.transform.localPosition, objectMoveSpeed);
                iTween.RotateTo(glass.gameObject, glassPosInVCLowerJaws.transform.localEulerAngles, objectMoveSpeed);
                iTween.MoveTo(ball.gameObject, ballStartPos, objectMoveSpeed);
                iTween.MoveTo(coin10.gameObject, coinStart10Pos.transform.localPosition, objectMoveSpeed);
                iTween.RotateTo(coin10.gameObject, coinStart10Pos.transform.localEulerAngles, objectMoveSpeed);
                iTween.MoveTo(ductTape.gameObject, iTween.Hash("position", ductTapeStartPos.transform.localPosition, "time", 1f, "oncompletetarget", gameObject, "oncomplete", "EnableColliderTape"));
                iTween.RotateTo(ductTape.gameObject, ductTapeStartPos.transform.localEulerAngles, objectMoveSpeed);
                iTween.MoveTo(box.gameObject, iTween.Hash("position", boxStartPos.transform.localPosition, "time", 1f, "oncompletetarget", gameObject, "oncomplete", "EnableBoxCollider"));
                iTween.RotateTo(box.gameObject, boxStartPos.transform.localEulerAngles, objectMoveSpeed);
                // GlassSelection.instance.outlineShader.SetFloat("_Outline", 0f);
                glassDimensionOuter.SetActive(true);
                glassDimensionInner.SetActive(false);
                glasseDimensionDepth.SetActive(false);
                objectRotationB.SetActive(false);
                ObjectOriginalRotationB.SetActive(false);
                upperJawB.SetActive(true);
                lowerJawB.SetActive(false);
                depthB.SetActive(true);
            }
            if (Coin10Selection.instance.iscoin10Selected)
            {
                Debug.Log("coin10Selected");
                //coin10.transform.Rotate(270f, 0f, 0f);
                objectPositionOnVC_Panel.SetActive(false);
                iTween.MoveTo(coin10.gameObject, coin10PosInVC.transform.localPosition, objectMoveSpeed);
                iTween.RotateTo(coin10.gameObject, coin10PosInVC.transform.localEulerAngles, objectMoveSpeed);
                iTween.MoveTo(ball.gameObject, ballStartPos, objectMoveSpeed);
                iTween.MoveTo(glass.gameObject, iTween.Hash("position", glassStartPos.transform.localPosition, "time", 1f, "oncompletetarget", gameObject, "oncomplete", "EnableColliderGlass"));
                iTween.RotateTo(glass.gameObject, glassStartPos.transform.localEulerAngles, objectMoveSpeed);
                iTween.MoveTo(ductTape.gameObject, ductTapeStartPos.transform.localPosition, objectMoveSpeed);
                iTween.MoveTo(ductTape.gameObject, iTween.Hash("position", ductTapeStartPos.transform.localPosition, "time", 1f, "oncompletetarget", gameObject, "oncomplete", "EnableColliderTape"));
                iTween.MoveTo(box.gameObject, iTween.Hash("position", boxStartPos.transform.localPosition, "time", 1f, "oncompletetarget", gameObject, "oncomplete", "EnableBoxCollider"));
                iTween.RotateTo(box.gameObject, boxStartPos.transform.localEulerAngles, objectMoveSpeed);
                // Coin10Selection.instance.outlineShader.SetFloat("_Outline", 0f);
                objectRotationB.SetActive(true);
                ObjectOriginalRotationB.SetActive(false);
                coinDiameterDimension.SetActive(true);
                coinThicknessDimension.SetActive(false);

            }



            if (DuctTapeSelection.instance.isDuctTapeSelected)
            {
                Debug.Log("ductTapeSelected");
                objectPositionOnVC_Panel.SetActive(true);
                iTween.MoveTo(ductTape.gameObject, ductTapePosInVCLowerJaws.transform.localPosition, objectMoveSpeed);
                iTween.MoveTo(ball.gameObject, ballStartPos, objectMoveSpeed);
                iTween.MoveTo(coin10.gameObject, coinStart10Pos.transform.localPosition, objectMoveSpeed);
                iTween.RotateTo(coin10.gameObject, coinStart10Pos.transform.localEulerAngles, objectMoveSpeed);
                iTween.MoveTo(glass.gameObject, iTween.Hash("position", glassStartPos.transform.localPosition, "time", 1f, "oncompletetarget", gameObject, "oncomplete", "EnableColliderGlass"));
                iTween.RotateTo(glass.gameObject, glassStartPos.transform.localEulerAngles, objectMoveSpeed);
                iTween.MoveTo(box.gameObject, iTween.Hash("position", boxStartPos.transform.localPosition, "time", 1f, "oncompletetarget", gameObject, "oncomplete", "EnableBoxCollider"));
                iTween.RotateTo(box.gameObject, boxStartPos.transform.localEulerAngles, objectMoveSpeed);
                //DuctTapeSelection.instance.outlineShader.SetFloat("_Outline", 0f);
                objectRotationB.SetActive(false);
                ObjectOriginalRotationB.SetActive(false);
                ductTapeDimensionInner.SetActive(false);
                ductTapeDimensionDepth.SetActive(false);
                ductTapeDimensionOuter.SetActive(true);
                upperJawB.SetActive(true);
                lowerJawB.SetActive(false);
                depthB.SetActive(true);


            }
            if (BoxSelection.instance.isBoxSelected)
            {
                //Debug.Log("ductTapeSelected");
                objectPositionOnVC_Panel.SetActive(false);
                BoxSelection.instance.boxCol.GetComponent<BoxCollider>().enabled = false;
                iTween.MoveTo(box.gameObject, iTween.Hash("position", boxPosInVC.transform.localPosition, "time", 1f, "oncompletetarget", gameObject, "oncomplete", "EnableBoxCollider"));
                iTween.MoveTo(ball.gameObject, ballStartPos, objectMoveSpeed);
                iTween.MoveTo(coin10.gameObject, coinStart10Pos.transform.localPosition, objectMoveSpeed);
                iTween.RotateTo(coin10.gameObject, coinStart10Pos.transform.localEulerAngles, objectMoveSpeed);
                iTween.MoveTo(glass.gameObject, iTween.Hash("position", glassStartPos.transform.localPosition, "time", 1f, "oncompletetarget", gameObject, "oncomplete", "EnableColliderGlass"));
                iTween.RotateTo(glass.gameObject, glassStartPos.transform.localEulerAngles, objectMoveSpeed);
                iTween.MoveTo(ductTape.gameObject, iTween.Hash("position", ductTapeStartPos.transform.localPosition, "time", 1f, "oncompletetarget", gameObject, "oncomplete", "EnableColliderTape"));
                iTween.RotateTo(ductTape.gameObject, ductTapeStartPos.transform.localEulerAngles, objectMoveSpeed);
                objectRotationB.SetActive(true);
                ObjectOriginalRotationB.SetActive(false);
                boxLengthDimension.SetActive(true);
                boxWidthDimension.SetActive(false);
            }


        }

        // THIS FUNCTION HELPS IN SELECFTING MICROMETER WITH ITS OBJECTS.
        public void MicrometerSelected()
        {
            VernierCaliper.instance.cmAndMmButtonParent.SetActive(false);
            istoolSelected = true;
            inputField.SetActive(true);
            toolSelection.SetActive(false);
            objectDimensionText.SetActive(false);
            CheckAnswereInputField.instance.wrongAnswer.SetActive(false);
            CheckAnswereInputField.instance.rightAnswer.SetActive(false);
            //Micrometer.instance.ZoomInMicrometer();
            Micrometer.instance.ResettingMicrometer();
            isSetResetToggle = false;
            coinDimensionPanel.SetActive(false);
            ballDimensionPanel.SetActive(false);
            thickWireDimensionPanel.SetActive(false);
            thinWireDimensionPanel.SetActive(false);
            //UIManager.instance.showHideBContainer.SetActive(false);
            HideLabels();
            if (BallMSelection.instance.isBallMSelected)
            {
                Debug.Log("ballSelected");
                //ball.transform.localPosition = ballPosVC;
                iTween.MoveTo(ballM.gameObject, ballPosInMicrometer.transform.localPosition, objectMoveSpeed);
                iTween.MoveTo(paper.gameObject, paperStartPos.transform.localPosition, objectMoveSpeed);
                iTween.RotateTo(paper.gameObject, paperStartPos.transform.localEulerAngles, objectMoveSpeed);
                iTween.MoveTo(thinWire.gameObject, thinWireStartPos.transform.localPosition, objectMoveSpeed);
                iTween.MoveTo(thickWire.gameObject, thickWireStartPos.transform.localPosition, objectMoveSpeed);
               
            }
            if (PaperSelection.instance.isPaperSelected)
            {
                iTween.MoveTo(paper.gameObject, paperPositionInM.transform.localPosition, objectMoveSpeed);
                iTween.RotateTo(paper.gameObject, paperPositionInM.transform.localEulerAngles, objectMoveSpeed);
                iTween.MoveTo(ballM.gameObject, ballMStartPos.transform.localPosition, objectMoveSpeed);
                iTween.MoveTo(thinWire.gameObject, thinWireStartPos.transform.localPosition, objectMoveSpeed);
                iTween.MoveTo(thickWire.gameObject, thickWireStartPos.transform.localPosition, objectMoveSpeed);
            }
          
            if (ThinWireSelection.instance.isThinWireSelected)
            {
                iTween.MoveTo(thinWire.gameObject, thinWirePosMicormeter.transform.localPosition, objectMoveSpeed);
                iTween.MoveTo(ballM.gameObject, ballMStartPos.transform.localPosition, objectMoveSpeed);
                iTween.MoveTo(paper.gameObject, paperStartPos.transform.localPosition, objectMoveSpeed);
                iTween.RotateTo(paper.gameObject, paperStartPos.transform.localEulerAngles, objectMoveSpeed);
                iTween.MoveTo(thickWire.gameObject, thickWireStartPos.transform.localPosition, objectMoveSpeed);
            }

            if (ThickWireSelection.instance.isThickWireSelected)
            {
                iTween.MoveTo(thickWire.gameObject, thickWirePosMicrometer.transform.localPosition, objectMoveSpeed);
                iTween.MoveTo(ballM.gameObject, ballMStartPos.transform.localPosition, objectMoveSpeed);
                iTween.MoveTo(paper.gameObject, paperStartPos.transform.localPosition, objectMoveSpeed);
                iTween.RotateTo(paper.gameObject, paperStartPos.transform.localEulerAngles, objectMoveSpeed);
                iTween.MoveTo(thinWire.gameObject, thinWireStartPos.transform.localPosition, objectMoveSpeed);
            }



        }

        public void CrossCheckScreen()
        {
            //VernierCaliper.instance.cmAndMmButtonParent.SetActive(false);
            CentimeterScale.instance.cmButtonObject.GetComponent<CentimeterScale>().enabled = false;
            MiliMeterSelection.instance.GetComponent<MiliMeterSelection>().enabled = false;
            CameraSwitchVernierCaliper.instance.TabletCloseView();
            ObjectDimensionPanel.SetActive(true);
          
            inputField.SetActive(false);
            CheckAnswereInputField.instance.inputAnswer.text = "";
            CheckAnswereInputField.instance.wrongAnswer.SetActive(false);
            CheckAnswereInputField.instance.rightAnswer.SetActive(false);

            if (ToolSelection.instance.isVernierCaliper)
            {
                if (BallSelection.instance.isBallSelected)
                {
                    ballDimensionPanel.SetActive(true);
                    objectDimensionText.SetActive(true);
                    if (CentimeterScale.instance.isCMSelected)
                    {
                        objectDimensionText.GetComponent<Text>().text = "1.44";
                    }
                    if(MiliMeterSelection.instance.isMMSelected)
                    {
                        objectDimensionText.GetComponent<Text>().text = "14.4";
                    }

                }

                if (Coin10Selection.instance.iscoin10Selected)
                {
                    coinDimensionPanel.SetActive(true);
                    objectDimensionText.SetActive(true);
                    if (isObjectRotated == false)
                    {
                        if (CentimeterScale.instance.isCMSelected)
                        {
                            objectDimensionText.GetComponent<Text>().text = "2.70";
                        }
                        if (MiliMeterSelection.instance.isMMSelected)
                        {
                            objectDimensionText.GetComponent<Text>().text = "27.0";
                        }
                        
                    }
                    else
                    {
                        //Debug.Log("b");
                        if (CentimeterScale.instance.isCMSelected)
                        {
                            objectDimensionText.GetComponent<Text>().text = "0.17";
                        }
                        if (MiliMeterSelection.instance.isMMSelected)
                        {
                            objectDimensionText.GetComponent<Text>().text = "1.7";
                        }
                    }
                }
                if (BoxSelection.instance.isBoxSelected)
                {
                    boxDimensionPanel.SetActive(true);
                    objectDimensionText.SetActive(true);
                    if (isObjectRotated == false)
                    {
                        if (CentimeterScale.instance.isCMSelected)
                        {
                            objectDimensionText.GetComponent<Text>().text = "4.60";
                        }
                        if (MiliMeterSelection.instance.isMMSelected)
                        {
                            objectDimensionText.GetComponent<Text>().text = "46.0";
                        }
                    }
                    else
                    {
                        if (CentimeterScale.instance.isCMSelected)
                        {
                            objectDimensionText.GetComponent<Text>().text = "1.40";
                        }
                        if (MiliMeterSelection.instance.isMMSelected)
                        {
                            objectDimensionText.GetComponent<Text>().text = "14.0";
                        }
                    }
                }
                //Duct tape dimension Values 
                if (DuctTapeSelection.instance.isDuctTapeSelected)
                {
                    ductTapeDimensionPanel.SetActive(true);
                    objectDimensionText.SetActive(true);
                    if (isobjectLowerJaw)
                    {
                        if (CentimeterScale.instance.isCMSelected)
                        {
                            objectDimensionText.GetComponent<Text>().text = "5.72";
                        }
                        if (MiliMeterSelection.instance.isMMSelected)
                        {
                            objectDimensionText.GetComponent<Text>().text = "57.2";
                        }          
                    }
                    if (isObjectUpperJaw)
                    {
                        if (CentimeterScale.instance.isCMSelected)
                        {
                            objectDimensionText.GetComponent<Text>().text = "4.31";
                        }
                        if (MiliMeterSelection.instance.isMMSelected)
                        {
                            objectDimensionText.GetComponent<Text>().text = "43.1";
                        }      
                    }

                    if (isObjctDepthRod)
                    {
                        if (CentimeterScale.instance.isCMSelected)
                        {
                            objectDimensionText.GetComponent<Text>().text = "1.76";
                        }
                        if (MiliMeterSelection.instance.isMMSelected)
                        {
                            objectDimensionText.GetComponent<Text>().text = "17.6";
                        }
                    }
                }
                if (GlassSelection.instance.isGlassSelected)
                {
                    glassDimensionPanel.SetActive(true);
                    objectDimensionText.SetActive(true);
                    if (isobjectLowerJaw)
                    {
                        if (CentimeterScale.instance.isCMSelected)
                        {
                            objectDimensionText.GetComponent<Text>().text = "4.22";
                        }
                        if (MiliMeterSelection.instance.isMMSelected)
                        {
                            objectDimensionText.GetComponent<Text>().text = "42.2";
                        }
                    }
                    if (isObjectUpperJaw)
                    {
                        if (CentimeterScale.instance.isCMSelected)
                        {
                            objectDimensionText.GetComponent<Text>().text = "3.84";
                        }
                        if (MiliMeterSelection.instance.isMMSelected)
                        {
                            objectDimensionText.GetComponent<Text>().text = "38.4";
                        }
                    }

                    if (isObjctDepthRod)
                    {
                        if (CentimeterScale.instance.isCMSelected)
                        {
                            objectDimensionText.GetComponent<Text>().text = "4.56";
                        }
                        if (MiliMeterSelection.instance.isMMSelected)
                        {
                            objectDimensionText.GetComponent<Text>().text = "45.6";
                        }
                    }
                }

            }
            if (ToolSelection.instance.isMicrometer)
            {
                if (BallMSelection.instance.isBallMSelected)
                {
                    bearingDimensionPanel.SetActive(true);
                    objectDimensionText.SetActive(true);
                    if (MiliMeterSelection.instance.isMMSelected)
                    {
                        objectDimensionText.GetComponent<Text>().text = "6.08";
                    }
                }
                if (PaperSelection.instance.isPaperSelected)
                {
                    paperDimnesionPanel.SetActive(true);
                    objectDimensionText.SetActive(true);
                    if (MiliMeterSelection.instance.isMMSelected)
                    {
                        objectDimensionText.GetComponent<Text>().text = "1.50";
                    }
                }
                if (ThinWireSelection.instance.isThinWireSelected)
                {
                    thinWireDimensionPanel.SetActive(true);
                    objectDimensionText.SetActive(true);
                    if (MiliMeterSelection.instance.isMMSelected)
                    {
                        objectDimensionText.GetComponent<Text>().text = "2.74";
                    }
                }
                if (ThickWireSelection.instance.isThickWireSelected)
                {
                    thickWireDimensionPanel.SetActive(true);
                    objectDimensionText.SetActive(true);
                    if (MiliMeterSelection.instance.isMMSelected)
                    {
                        objectDimensionText.GetComponent<Text>().text = "6.14";
                    }
                }
            }

        }

        public void Reset()
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
           
        }


        public void DeselectDimensionPanels()
        {
            ballDimensionPanel.SetActive(false);
            coinDimensionPanel.SetActive(false);
            boxDimensionPanel.SetActive(false);
            ductTapeDimensionPanel.SetActive(false);
            glassDimensionPanel.SetActive(false);
            paperDimnesionPanel.SetActive(false);
            bearingDimensionPanel.SetActive(false);
        }

        public void ObjectRotation()
        {
            isObjectRotated = true;
            objectDimensionText.SetActive(false);
            VernierCaliper.instance.cmAndMmButtonParent.SetActive(true);
            objectRotationB.SetActive(false);
            ObjectOriginalRotationB.SetActive(true);
            inputField.SetActive(true);
            coinDimensionPanel.SetActive(false);
            boxDimensionPanel.SetActive(false);
            VernierCaliper.instance.ResetVernierScale();
            VernierCaliper.instance.isFreezVC = true;
            VernierCaliper.instance.FreezVernierC();
            if (Coin10Selection.instance.iscoin10Selected)
            {
                iTween.MoveTo(coin10.gameObject, coinPosInVC_Rotation.transform.localPosition, objectMoveSpeed);
                iTween.RotateTo(coin10.gameObject, coinPosInVC_Rotation.transform.eulerAngles, objectMoveSpeed);
                coinDiameterDimension.SetActive(false);
                coinThicknessDimension.SetActive(true);
                objectObjective.GetComponent<Text>().text = "Measure the INR 10 Coin Thickness";

                if (InstructionMeasuringTools.instance.isInstructionClick)
                {
                    InstructionMeasuringTools.instance.coinRotationI.SetActive(false);
                    coin10.GetComponent<MeshCollider>().enabled = true;
                    setB.GetComponentInParent<Button>().interactable = true;
                    InstructionMeasuringTools.instance.setVernierCliaperI.SetActive(true);
                }
            }

            if (BoxSelection.instance.isBoxSelected)
            {
                BoxSelection.instance.boxCol.GetComponent<BoxCollider>().enabled = true;
                //iTween.MoveTo(box.gameObject, boxPosInVC_Rotation.transform.localPosition, objectMoveSpeed);
                iTween.MoveTo(box.gameObject, iTween.Hash("position", boxPosInVC_Rotation.transform.localPosition, "time", 1f, "oncompletetarget", gameObject, "oncomplete", "EnableBoxCollider"));
                iTween.RotateTo(box.gameObject, boxPosInVC_Rotation.transform.localEulerAngles, objectMoveSpeed);
                boxWidthDimension.SetActive(true);
                boxLengthDimension.SetActive(false);
                objectObjective.GetComponent<Text>().text = "Measure the Matchbox Width";
            }

        }

        public void objectOriginalRotation()
        {
            isObjectRotated = false;
            VernierCaliper.instance.cmAndMmButtonParent.SetActive(true);
            ObjectOriginalRotationB.SetActive(false);
            objectRotationB.SetActive(true);
            inputField.SetActive(true);
            coinDimensionPanel.SetActive(false);
            boxDimensionPanel.SetActive(false);
            VernierCaliper.instance.ResetVernierScale();
            VernierCaliper.instance.isFreezVC = true;
            VernierCaliper.instance.FreezVernierC();
            if (Coin10Selection.instance.iscoin10Selected)
            {
                iTween.MoveTo(coin10.gameObject, coin10PosInVC.transform.localPosition, objectMoveSpeed);
                iTween.RotateTo(coin10.gameObject, coin10PosInVC.transform.localEulerAngles, objectMoveSpeed);
                coinDiameterDimension.SetActive(true);
                coinThicknessDimension.SetActive(false);
                objectObjective.GetComponent<Text>().text = "Measure the INR 10 Coin Diameter";
            }

            if (BoxSelection.instance.isBoxSelected)
            {
                BoxSelection.instance.boxCol.GetComponent<BoxCollider>().enabled = true;
                iTween.MoveTo(box.gameObject, iTween.Hash("position", boxPosInVC.transform.localPosition, "time", 1f, "oncompletetarget", gameObject, "oncomplete", "EnableBoxCollider"));
                // iTween.MoveTo(box.gameObject, boxPosInVC.transform.localPosition, objectMoveSpeed);
                iTween.RotateTo(box.gameObject, boxPosInVC.transform.localEulerAngles, objectMoveSpeed);
                boxWidthDimension.SetActive(false);
                boxLengthDimension.SetActive(true);
                objectObjective.GetComponent<Text>().text = "Measure the Matchbox Length";
            }
        }



        public void ObjectRotationMicrometer()
        {
            isObjectRotated = true;
            objectRotationBMicrometer.SetActive(false);
            ObjectOriginalRotationBMicrometer.SetActive(true);
            inputField.SetActive(true);
            coinDimensionPanel.SetActive(false);
            if (Coin10Selection.instance.iscoin10Selected)
            {
                iTween.MoveTo(coin10.gameObject, coinPosInVC_RotationMicrometer.transform.localPosition, objectMoveSpeed);
                iTween.RotateTo(coin10.gameObject, coinPosInVC_RotationMicrometer.transform.eulerAngles, objectMoveSpeed);
                coinDiameterDimension.SetActive(false);
                coinThicknessDimension.SetActive(true);
                UIManager.instance.objectObjective.GetComponent<Text>().text = "Measure the INR 10 Coin Thickness";
                warningMessgForTape.SetActive(false);
            }

        }

        public void objectOriginalRotationMicrometer()
        {
            isObjectRotated = false;
            ObjectOriginalRotationBMicrometer.SetActive(false);
            objectRotationBMicrometer.SetActive(true);
            inputField.SetActive(true);
            coinDimensionPanel.SetActive(false);
            if (Coin10Selection.instance.iscoin10Selected)
            {
                iTween.MoveTo(coin10.gameObject, coin10PosInMicrometer.transform.localPosition, objectMoveSpeed);
                iTween.RotateTo(coin10.gameObject, coin10PosInMicrometer.transform.localEulerAngles, objectMoveSpeed);
                coinDiameterDimension.SetActive(true);
                coinThicknessDimension.SetActive(false);
                UIManager.instance.objectObjective.GetComponent<Text>().text = "Measure the INR 10 Coin Diameter";
                warningMessgForTape.SetActive(true);
            }
        }

        // Duct Tape And Glass Dimension
        public void UpperJawsPosition()
        {
            VernierCaliper.instance.SetVernierScale();
            objectDimensionText.SetActive(false);
            VernierCaliper.instance.cmAndMmButtonParent.SetActive(true);
            isObjectUpperJaw = true;
            isobjectLowerJaw = false;
            isObjctDepthRod = false;
            inputField.SetActive(true);
            isSetResetToggle = true;
            ductTapeDimensionPanel.SetActive(false);
            glassDimensionPanel.SetActive(false);
            upperJawB.SetActive(false);
            lowerJawB.SetActive(true);
            depthB.SetActive(true);
            VernierCaliper.instance.isFreezVC = true;
            VernierCaliper.instance.FreezVernierC();
            VernierCaliper.instance.verUpperCol.GetComponent<BoxCollider>().enabled = true;
            if (DuctTapeSelection.instance.isDuctTapeSelected)
            {
                DuctTapeSelection.instance.ductCol.GetComponent<MeshCollider>().enabled = false;
                DuctTapeSelection.instance.ductBoxUpperJawCol.GetComponent<BoxCollider>().enabled = false;
                DuctTapeSelection.instance.ductDepthRodCol.GetComponent<BoxCollider>().enabled = false;
                iTween.RotateTo(ductTape.gameObject, ductTapePosInVCUpperJaws.transform.localEulerAngles, objectMoveSpeed);
                iTween.MoveTo(ductTape.gameObject, iTween.Hash("position", ductTapePosInVCUpperJaws.transform.localPosition, "time", 1f, "oncompletetarget", gameObject, "oncomplete", "EnableColliderTapeUpperJaw"));
                objectObjective.GetComponent<Text>().text = "Measure the DuctTape Inner Diameter";
                ductTapeDimensionInner.SetActive(true);
                ductTapeDimensionDepth.SetActive(false);
                ductTapeDimensionOuter.SetActive(false);
                //Invoke("SetObljectPosInUpperJaws", 1f);

            }
            if (GlassSelection.instance.isGlassSelected)
            {
                GlassSelection.instance.glassCol.GetComponent<MeshCollider>().enabled = false;
                GlassSelection.instance.glassBCol.GetComponent<BoxCollider>().enabled = false;
                //iTween.MoveTo(glass.gameObject, iTween.Hash("position", glassPosInVCUpperJaws.transform.localPosition, "time", 1f, "oncompletetarget", gameObject, "oncomplete", "EnableColliderGlass"));
                iTween.MoveTo(glass.gameObject, glassPosInVCUpperJaws.transform.localPosition, objectMoveSpeed);
                //iTween.RotateTo(glass.gameObject, iTween.Hash("rotation", glassPosInVCUpperJaws.transform.localEulerAngles, "time", 5f, "oncompletetarget", gameObject, "oncomplete", " EnableColliderGlass"));
                iTween.RotateTo(glass.gameObject, glassPosInUpperJaws.transform.localEulerAngles, objectMoveSpeed);
                objectObjective.GetComponent<Text>().text = "Measure the Glass Inner Diameter";
                glassDimensionInner.SetActive(true);
                glassDimensionOuter.SetActive(false);
                glasseDimensionDepth.SetActive(false);

            }
        }



        public void LowerJawsPostion()
        {
            VernierCaliper.instance.ResetVernierScale();
            objectDimensionText.SetActive(false);
            VernierCaliper.instance.cmAndMmButtonParent.SetActive(true);
            isobjectLowerJaw = true;
            isObjctDepthRod = false;
            isObjectUpperJaw = false;
            inputField.SetActive(true);
            isSetResetToggle =false;
            VernierCaliper.instance.isLeftDrag = true;
            VernierCaliper.instance.isRightDrag = false;
            ductTapeDimensionPanel.SetActive(false);
            glassDimensionPanel.SetActive(false);
            upperJawB.SetActive(true);
            lowerJawB.SetActive(false);
            depthB.SetActive(true);
            VernierCaliper.instance.isFreezVC = true;
            VernierCaliper.instance.FreezVernierC();
            VernierCaliper.instance.verUpperCol.GetComponent<BoxCollider>().enabled = false;
            if (DuctTapeSelection.instance.isDuctTapeSelected)
            {
                DuctTapeSelection.instance.ductCol.GetComponent<MeshCollider>().enabled = false;
                DuctTapeSelection.instance.ductBoxUpperJawCol.GetComponent<BoxCollider>().enabled = false;
                DuctTapeSelection.instance.ductDepthRodCol.GetComponent<BoxCollider>().enabled = false;
                iTween.RotateTo(ductTape.gameObject, ductTapePosInVCLowerJaws.transform.localEulerAngles, objectMoveSpeed);
                iTween.MoveTo(ductTape.gameObject, iTween.Hash("position", ductTapePosInVCLowerJaws.transform.localPosition, "time", 1f, "oncompletetarget", gameObject, "oncomplete", "EnableColliderTape"));
                objectObjective.GetComponent<Text>().text = "Measure the DuctTape Outer diameter";
                ductTapeDimensionInner.SetActive(false);
                ductTapeDimensionDepth.SetActive(false);
                ductTapeDimensionOuter.SetActive(true);
            }
            if (GlassSelection.instance.isGlassSelected)
            {
                GlassSelection.instance.glassCol.GetComponent<MeshCollider>().enabled = false;
                GlassSelection.instance.glassBCol.GetComponent<BoxCollider>().enabled = false;
                //iTween.MoveTo(glass.gameObject, glassPosInVCLowerJaws.transform.localPosition, objectMoveSpeed);
                iTween.MoveTo(glass.gameObject, iTween.Hash("position", glassPosInVCLowerJaws.transform.localPosition, "time", 1f, "oncompletetarget", gameObject, "oncomplete", "EnableColliderGlass"));
                //iTween.RotateTo(glass.gameObject, iTween.Hash("rotation", glassPosInVCLowerJaws.transform.localEulerAngles, "time", 5f, "oncompletetarget", gameObject, "oncomplete", " EnableColliderGlass"));

                iTween.RotateTo(glass.gameObject, glassPosInVCLowerJaws.transform.localEulerAngles, objectMoveSpeed);
                objectObjective.GetComponent<Text>().text = "Measure the Glass Outer Diameter";
                glassDimensionOuter.SetActive(true);
                glassDimensionInner.SetActive(false);
                glasseDimensionDepth.SetActive(false);
            }
        }

        public void DepthRodPosition()
        {
            VernierCaliper.instance.SetVernierScale();
            objectDimensionText.SetActive(false);
            VernierCaliper.instance.cmAndMmButtonParent.SetActive(true);
            isObjctDepthRod = true;
            isObjectUpperJaw = false;
            isobjectLowerJaw = false;
            inputField.SetActive(true);
            isSetResetToggle = true;
            VernierCaliper.instance.isLeftDrag = false;
            VernierCaliper.instance.isRightDrag = true;
            ductTapeDimensionPanel.SetActive(false);
            glassDimensionPanel.SetActive(false);
            upperJawB.SetActive(true);
            lowerJawB.SetActive(true);
            depthB.SetActive(false);
            VernierCaliper.instance.isFreezVC = true;
            VernierCaliper.instance.FreezVernierC();
            VernierCaliper.instance.verUpperCol.GetComponent<BoxCollider>().enabled = false;
            if (DuctTapeSelection.instance.isDuctTapeSelected)
            {
                DuctTapeSelection.instance.ductCol.GetComponent<MeshCollider>().enabled = false;
                DuctTapeSelection.instance.ductBoxUpperJawCol.GetComponent<BoxCollider>().enabled = false;
                DuctTapeSelection.instance.ductDepthRodCol.GetComponent<BoxCollider>().enabled = false;
                iTween.MoveTo(ductTape.gameObject, iTween.Hash("position", ductTapePosInVCDepthRod.transform.localPosition, "time", 1f, "oncompletetarget", gameObject, "oncomplete", "EnableColliderTapeDepthRod"));
                iTween.RotateTo(ductTape.gameObject, iTween.Hash("rotation", ductTapePosInVCDepthRod.transform.localEulerAngles, "time", 1f, "oncompletetarget", gameObject, "oncomplete", "EnableColliderTapeDepthRod"));
                UIManager.instance.objectObjective.GetComponent<Text>().text = "Measure the DuctTape Depth";
                ductTapeDimensionInner.SetActive(false);
                ductTapeDimensionDepth.SetActive(true);
                ductTapeDimensionOuter.SetActive(false);
            }

            if (GlassSelection.instance.isGlassSelected)
            {
                GlassSelection.instance.glassCol.GetComponent<MeshCollider>().enabled = false;
                GlassSelection.instance.glassBCol.GetComponent<BoxCollider>().enabled = false;
                // iTween.MoveTo(glass.gameObject, glassPosInVCDepthRod.transform.localPosition, objectMoveSpeed);
                iTween.MoveTo(glass.gameObject, iTween.Hash("position", glassPosInVCDepthRod.transform.localPosition, "time", 1f, "oncompletetarget", gameObject, "oncomplete", "EnableColliderGlassDepth"));
                //iTween.RotateTo(glass.gameObject, iTween.Hash("rotation", glassPosInVCDepthRod.transform.localEulerAngles, "time", 1f, "oncompletetarget", gameObject, "oncomplete", "EnableColliderGlass"));

                iTween.RotateTo(glass.gameObject, glassPosInVCDepthRod.transform.localEulerAngles, objectMoveSpeed);
                objectObjective.GetComponent<Text>().text = "Measure the Glass Depth";
                glasseDimensionDepth.SetActive(true);
                glassDimensionInner.SetActive(false);
                glassDimensionOuter.SetActive(false);


            }
        }

        public void EnableColliderTape()
        {
            if (!InstructionMeasuringTools.instance.isInstructionClick)
            {
                DuctTapeSelection.instance.ductCol.GetComponent<MeshCollider>().enabled = true;
            }
            else
            {
                DuctTapeSelection.instance.ductCol.GetComponent<MeshCollider>().enabled = false;
            }

        }
        public void EnableColliderTapeUpperJaw()
        {
            if (!InstructionMeasuringTools.instance.isInstructionClick)
            {
                DuctTapeSelection.instance.ductCol.GetComponent<MeshCollider>().enabled = false;
                DuctTapeSelection.instance.ductBoxUpperJawCol.GetComponent<BoxCollider>().enabled = true;
                DuctTapeSelection.instance.ductDepthRodCol.GetComponent<BoxCollider>().enabled = false;
                VernierCaliper.instance.verUpperCol.GetComponent<BoxCollider>().enabled = true;
            }
            else
            {
                DuctTapeSelection.instance.ductCol.GetComponent<MeshCollider>().enabled = false;
                DuctTapeSelection.instance.ductBoxUpperJawCol.GetComponent<BoxCollider>().enabled =false;
                DuctTapeSelection.instance.ductDepthRodCol.GetComponent<BoxCollider>().enabled = false;
                VernierCaliper.instance.verUpperCol.GetComponent<BoxCollider>().enabled =false;
            }
           
        }

        public void EnableColliderTapeDepthRod()
        {
            if (!InstructionMeasuringTools.instance.isInstructionClick)
            {
                DuctTapeSelection.instance.ductCol.GetComponent<MeshCollider>().enabled = false;
                DuctTapeSelection.instance.ductBoxUpperJawCol.GetComponent<BoxCollider>().enabled = false;
                DuctTapeSelection.instance.ductDepthRodCol.GetComponent<BoxCollider>().enabled = true;
            }
            else
            {
                DuctTapeSelection.instance.ductCol.GetComponent<MeshCollider>().enabled = false;
                DuctTapeSelection.instance.ductBoxUpperJawCol.GetComponent<BoxCollider>().enabled = false;
                DuctTapeSelection.instance.ductDepthRodCol.GetComponent<BoxCollider>().enabled =false;
            }
            
        }

        public void EnableColliderGlass()
        {
            if (!InstructionMeasuringTools.instance.isInstructionClick)
            {
                GlassSelection.instance.glassCol.GetComponent<MeshCollider>().enabled = true;
                GlassSelection.instance.glassBCol.GetComponent<BoxCollider>().enabled = true;
            }
            else
            {
                GlassSelection.instance.glassCol.GetComponent<MeshCollider>().enabled = false;
                GlassSelection.instance.glassBCol.GetComponent<BoxCollider>().enabled = false;
            }
           
           
        }
        public void EnableColliderGlassDepth()
        {
            if (!InstructionMeasuringTools.instance.isInstructionClick)
            {
                GlassSelection.instance.glassCol.GetComponent<MeshCollider>().enabled = false;
                GlassSelection.instance.glassBCol.GetComponent<BoxCollider>().enabled = true;
            }
            else
            {
                GlassSelection.instance.glassCol.GetComponent<MeshCollider>().enabled = false;
                GlassSelection.instance.glassBCol.GetComponent<BoxCollider>().enabled = false;
            }
            
            //VernierCaliper.instance.verUpperCol.GetComponent<BoxCollider>().enabled =true;
        }
        public void EnableBoxCollider()
        {
            if (!InstructionMeasuringTools.instance.isInstructionClick)
            {
                BoxSelection.instance.boxCol.GetComponent<BoxCollider>().enabled = true;
            }
            else
            {
                BoxSelection.instance.boxCol.GetComponent<BoxCollider>().enabled = false;
            }
           
        }

        public void ShowLabels()
        {
            showLabelB.SetActive(false);
            hideLabelB.SetActive(true);
            if (ToolSelection.instance.isVernierCaliper)
            {
                vcObjectsLabelCanvas.SetActive(true);
                mObjectsLabelCanvas.SetActive(false);
               
            }
            if(ToolSelection.instance.isMicrometer)
            {
                mObjectsLabelCanvas.SetActive(true);
                vcObjectsLabelCanvas.SetActive(false);

                
            }
            if (InstructionMeasuringTools.instance.isInstructionClick)
            {
                InstructionMeasuringTools.instance.showLablesI.SetActive(false);
                InstructionMeasuringTools.instance.hideLablesI.SetActive(true);
                showLabelB.GetComponent<Button>().interactable = false;
                hideLabelB.GetComponent<Button>().interactable = true;
            }


        }

        public void HideLabels()
        {
           
            vcObjectsLabelCanvas.SetActive(false);
            mObjectsLabelCanvas.SetActive(false);
            showLabelB.SetActive(true);
            hideLabelB.SetActive(false);
           
            if(InstructionMeasuringTools.instance.isInstructionClick &&  MouseMovement.instance.isOrbit)
            {
                if (ToolSelection.instance.isVernierCaliper)
                {
                    InstructionMeasuringTools.instance.hideLablesI.SetActive(false);
                    hideLabelB.GetComponent<Button>().interactable = false;
                    CentimeterScale.instance.cmButtonObject.GetComponent<BoxCollider>().enabled = true;
                    InstructionMeasuringTools.instance.clickCmAndMmI.SetActive(true);
                }
                if(ToolSelection.instance.isMicrometer)
                {
                    InstructionMeasuringTools.instance.hideLablesI.SetActive(false);
                    hideLabelB.GetComponent<Button>().interactable = false;
                    InstructionMeasuringTools.instance.bearingClickI.SetActive(true);
                }
              

            }
        }
    }

  


}