using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MeasuringTools
{
    public class CheckAnswereInputField : MonoBehaviour
    {
        public static CheckAnswereInputField instance;

        public InputField inputAnswer;

        public GameObject wrongAnswer;
        public GameObject rightAnswer;

        public float ballDiameter = 14.52f;
        public float coinDiameter = 27f;
        public float coinThickeness = 1.77f;
        public float matchBoxLenght = 48.5f;
        public float matchBoxThickness = 13f;

        public void Start()
        {
            instance = this;
        }

        public void CheckAnswer()
        {
        
            if (ToolSelection.instance.isVernierCaliper)
            {
                //you selected ball object
                if (BallSelection.instance.isBallSelected)
                {
                    if (CentimeterScale.instance.isCMSelected)
                    {
                        if (inputAnswer.text == "1.44")
                        {
                            wrongAnswer.SetActive(false);
                            rightAnswer.SetActive(true);

                        }
                        else
                        {
                            wrongAnswer.SetActive(true);
                            rightAnswer.SetActive(false);
                        }
                    }
                    if (MiliMeterSelection.instance.isMMSelected)
                    {
                        if (inputAnswer.text == "14.4")
                        {
                            wrongAnswer.SetActive(false);
                            rightAnswer.SetActive(true);

                        }
                        else
                        {
                            wrongAnswer.SetActive(true);
                            rightAnswer.SetActive(false);
                        }
                    }
                  
                }
                //you selected coin object
                if (Coin10Selection.instance.iscoin10Selected)
                {
                    //coin diameter 
                    if (UIManager.instance.isObjectRotated == false)
                    {
                        if (CentimeterScale.instance.isCMSelected)
                        {
                            if (inputAnswer.text == "2.70" || inputAnswer.text == "2.7")
                            {
                                wrongAnswer.SetActive(false);
                                rightAnswer.SetActive(true);
                            }
                            else
                            {
                                wrongAnswer.SetActive(true);
                                rightAnswer.SetActive(false);
                            }
                        }
                        if (MiliMeterSelection.instance.isMMSelected)
                        {
                            if (inputAnswer.text == "27.0" || inputAnswer.text == "27")
                            {
                                wrongAnswer.SetActive(false);
                                rightAnswer.SetActive(true);
                            }
                            else
                            {
                                wrongAnswer.SetActive(true);
                                rightAnswer.SetActive(false);
                            }
                        }
                        
                    }
                    //coin thikness 
                    else
                    {
                        if(CentimeterScale.instance.isCMSelected)
                        {
                            if (inputAnswer.text == "0.17")
                            {
                                wrongAnswer.SetActive(false);
                                rightAnswer.SetActive(true);
                            }
                            else
                            {
                                wrongAnswer.SetActive(true);
                                rightAnswer.SetActive(false);
                            }

                        }
                        if(MiliMeterSelection.instance.isMMSelected)
                        {
                            if (inputAnswer.text == "1.7")
                            {
                                wrongAnswer.SetActive(false);
                                rightAnswer.SetActive(true);
                            }
                            else
                            {
                                wrongAnswer.SetActive(true);
                                rightAnswer.SetActive(false);
                            }
                        }
                        
                    }
                }

                //you selected matchBox
                if (BoxSelection.instance.isBoxSelected)
                {
                    if (UIManager.instance.isObjectRotated == false)
                    {
                        if (CentimeterScale.instance.isCMSelected)
                        {
                            if (inputAnswer.text == "4.60" || inputAnswer.text == "4.6")
                            {
                                wrongAnswer.SetActive(false);
                                rightAnswer.SetActive(true);
                            }
                            else
                            {
                                wrongAnswer.SetActive(true);
                                rightAnswer.SetActive(false);
                            }
                        }
                        if (MiliMeterSelection.instance.isMMSelected)
                        {
                            if (inputAnswer.text == "46.0" || inputAnswer.text == "46")
                            {
                                wrongAnswer.SetActive(false);
                                rightAnswer.SetActive(true);
                            }
                            else
                            {
                                wrongAnswer.SetActive(true);
                                rightAnswer.SetActive(false);
                            }
                        }
                      
                    }
                    else
                    {
                        if (inputAnswer.text == "14.0" || inputAnswer.text == "14")
                        {
                            wrongAnswer.SetActive(false);
                            rightAnswer.SetActive(true);
                        }
                        else
                        {
                            wrongAnswer.SetActive(true);
                            rightAnswer.SetActive(false);
                        }
                    }
                }

                if (GlassSelection.instance.isGlassSelected)
                {
                    if (UIManager.instance.isobjectLowerJaw)
                    {
                        if(CentimeterScale.instance.isCMSelected)
                        {
                            if (inputAnswer.text == "4.22")
                            {
                                wrongAnswer.SetActive(false);
                                rightAnswer.SetActive(true);
                            }
                            else
                            {
                                wrongAnswer.SetActive(true);
                                rightAnswer.SetActive(false);
                            }
                        }
                        if(MiliMeterSelection.instance.isMMSelected)
                        {
                            if (inputAnswer.text == "42.2")
                            {
                                wrongAnswer.SetActive(false);
                                rightAnswer.SetActive(true);
                            }
                            else
                            {
                                wrongAnswer.SetActive(true);
                                rightAnswer.SetActive(false);
                            }
                        }
                        
                    }
                    if (UIManager.instance.isObjectUpperJaw)
                    {
                        if (CentimeterScale.instance.isCMSelected)
                        {
                            if (inputAnswer.text == "3.84")
                            {
                                wrongAnswer.SetActive(false);
                                rightAnswer.SetActive(true);
                            }
                            else
                            {
                                wrongAnswer.SetActive(true);
                                rightAnswer.SetActive(false);
                            }
                        }
                        if(MiliMeterSelection.instance.isMMSelected)
                        {
                            if (inputAnswer.text == "38.4")
                            {
                                wrongAnswer.SetActive(false);
                                rightAnswer.SetActive(true);
                            }
                            else
                            {
                                wrongAnswer.SetActive(true);
                                rightAnswer.SetActive(false);
                            }
                        }
                       
                    }

                    if (UIManager.instance.isObjctDepthRod)
                    {
                        if (CentimeterScale.instance.isCMSelected)
                        {
                            if (inputAnswer.text == "4.56")
                            {
                                wrongAnswer.SetActive(false);
                                rightAnswer.SetActive(true);
                            }
                            else
                            {
                                wrongAnswer.SetActive(true);
                                rightAnswer.SetActive(false);
                            }

                        }
                        if(MiliMeterSelection.instance.isMMSelected)
                        {
                            if (inputAnswer.text == "45.6")
                            {
                                wrongAnswer.SetActive(false);
                                rightAnswer.SetActive(true);
                            }
                            else
                            {
                                wrongAnswer.SetActive(true);
                                rightAnswer.SetActive(false);
                            }
                        }
                       
                    }
                }

                if (DuctTapeSelection.instance.isDuctTapeSelected)
                {
                    if (UIManager.instance.isobjectLowerJaw)
                    {
                        if(CentimeterScale.instance.isCMSelected)
                        {
                            if (inputAnswer.text == "5.72")
                            {
                                wrongAnswer.SetActive(false);
                                rightAnswer.SetActive(true);
                            }
                            else
                            {
                                wrongAnswer.SetActive(true);
                                rightAnswer.SetActive(false);
                            }
                        }
                        if(MiliMeterSelection.instance.isMMSelected)
                        {
                            if (inputAnswer.text == "57.2")
                            {
                                wrongAnswer.SetActive(false);
                                rightAnswer.SetActive(true);
                            }
                            else
                            {
                                wrongAnswer.SetActive(true);
                                rightAnswer.SetActive(false);
                            }
                        }
                        
                    }
                    if (UIManager.instance.isObjectUpperJaw)
                    {
                        if (CentimeterScale.instance.isCMSelected)
                        {
                            if (inputAnswer.text == "4.31")
                            {
                                wrongAnswer.SetActive(false);
                                rightAnswer.SetActive(true);
                            }
                            else
                            {
                                wrongAnswer.SetActive(true);
                                rightAnswer.SetActive(false);
                            }
                        }
                        if(MiliMeterSelection.instance.isMMSelected)
                        {
                            if (inputAnswer.text == "43.1")
                            {
                                wrongAnswer.SetActive(false);
                                rightAnswer.SetActive(true);
                            }
                            else
                            {
                                wrongAnswer.SetActive(true);
                                rightAnswer.SetActive(false);
                            }
                        }
                       
                    }

                    if (UIManager.instance.isObjctDepthRod)
                    {
                        if (CentimeterScale.instance.isCMSelected)
                        {
                            if (inputAnswer.text == "1.76")
                            {
                                wrongAnswer.SetActive(false);
                                rightAnswer.SetActive(true);
                            }
                            else
                            {
                                wrongAnswer.SetActive(true);
                                rightAnswer.SetActive(false);
                            }
                        }
                        if (MiliMeterSelection.instance.isMMSelected)
                        {
                            if (inputAnswer.text == "17.6")
                            {
                                wrongAnswer.SetActive(false);
                                rightAnswer.SetActive(true);
                            }
                            else
                            {
                                wrongAnswer.SetActive(true);
                                rightAnswer.SetActive(false);
                            }
                        }
                        
                    }
                }
            }

            if (ToolSelection.instance.isMicrometer)
            {
                if (BallMSelection.instance.isBallMSelected)
                {
                    if (inputAnswer.text == "6.08")
                    {
                        wrongAnswer.SetActive(false);
                        rightAnswer.SetActive(true);
                    }
                    else
                    {
                        wrongAnswer.SetActive(true);
                        rightAnswer.SetActive(false);
                    }
                }
                if (PaperSelection.instance.isPaperSelected)
                {
                    if (inputAnswer.text == "1.50" || inputAnswer.text == "1.5")
                    {
                        wrongAnswer.SetActive(false);
                        rightAnswer.SetActive(true);
                    }
                    else
                    {
                        wrongAnswer.SetActive(true);
                        rightAnswer.SetActive(false);
                    }
                }
               
                if (ThinWireSelection.instance.isThinWireSelected)
                {
                    if (inputAnswer.text == "2.74")
                    {
                        wrongAnswer.SetActive(false);
                        rightAnswer.SetActive(true);
                    }
                    else
                    {
                        wrongAnswer.SetActive(true);
                        rightAnswer.SetActive(false);
                    }
                }
                if (ThickWireSelection.instance.isThickWireSelected)
                {
                    if (inputAnswer.text == "6.14")
                    {
                        wrongAnswer.SetActive(false);
                        rightAnswer.SetActive(true);
                    }
                    else
                    {
                        wrongAnswer.SetActive(true);
                        rightAnswer.SetActive(false);
                    }
                }
            }

            if(InstructionMeasuringTools.instance.isInstructionClick)
            {
                InstructionMeasuringTools.instance.checkAnswareI.SetActive(false);
                InstructionMeasuringTools.instance.tabletCol.GetComponent<BoxCollider>().enabled = true;
                InstructionMeasuringTools.instance.tabletClickI.SetActive(true);
            }

        }
    }
}