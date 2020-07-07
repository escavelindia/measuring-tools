using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MeasuringTools
{
    public class BallMSelection : MonoBehaviour
    {

        public static BallMSelection instance;

        // public Material outlineShader;

        //public float outLineWidth;
        public bool isBallMSelected;

        private void Start()
        {
            instance = this;
        }
        public void OnMouseDown()
        {
            BallMSelected();
        }

        public void BallMSelected()
        {
            isBallMSelected = true;
            UIManager.instance.tabletStartPanel.SetActive(false);
            UIManager.instance.objectiveTitle.SetActive(true);
            UIManager.instance.objectObjective.GetComponent<Text>().text = "Measure the Bearing Diameter";
            RemainingObjectDeselect();
            UIManager.instance.MicrometerSelected();

            if (InstructionMeasuringTools.instance.isInstructionClick)
            {
                InstructionMeasuringTools.instance.bearingClickI.SetActive(false);
                InstructionMeasuringTools.instance.michrometerCloseViewI.SetActive(true);
            }
        }

        public void DeselectBall()
        {
            isBallMSelected = false;

        }


        public void RemainingObjectDeselect()
        {
            PaperSelection.instance.DeselectPaper();
            ThinWireSelection.instance.DeselecThinWire();
            ThickWireSelection.instance.DeselecThickWire();
            //CoinMSelection.instance.DeselectCoinM();
            UIManager.instance.DeselectDimensionPanels();
            
        }
    }
}