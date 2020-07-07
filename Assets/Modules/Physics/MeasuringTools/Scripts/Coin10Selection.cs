using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MeasuringTools
{
    public class Coin10Selection : MonoBehaviour
    {

        public static Coin10Selection instance;

        public bool iscoin10Selected;

        private void Start()
        {
            instance = this;
        }

        public void OnMouseDown()
        {
            Coin10Selected();
        }

        public void Coin10Selected()
        {
            iscoin10Selected = true;
            UIManager.instance.tabletStartPanel.SetActive(false);
            UIManager.instance.objectiveTitle.SetActive(true);
            UIManager.instance.objectObjective.GetComponent<Text>().text = "Measure the INR 10 Coin Diameter";
            RemainingObjectDeselect();
            UIManager.instance.objectRotationB.SetActive(true);
            VernierCaliper.instance.ResetVernierScale();
            UIManager.instance.VernierCaliperSelected();

            if (InstructionMeasuringTools.instance.isInstructionClick)
            {
                InstructionMeasuringTools.instance.coinSelectedI.SetActive(false);
                UIManager.instance.coin10.GetComponent<MeshCollider>().enabled = false;
                InstructionMeasuringTools.instance.clickCmAndMmI.SetActive(false);
                VernierCaliper.instance.zoomInB_Vernier.GetComponent<Button>().interactable = true;
                InstructionMeasuringTools.instance.vernierCaliperZoomInI.SetActive(true);
               
            }
        }

        public void DeselecteCoin10()
        {
            iscoin10Selected = false;
          

        }


        public void RemainingObjectDeselect()
        {
            DuctTapeSelection.instance.DeselectDuctTape();
            GlassSelection.instance.DeselcetGalss();
            BoxSelection.instance.DeselectBox();
            BallSelection.instance.DeselectBall();
            UIManager.instance.DeselectDimensionPanels();
        }
    }
}