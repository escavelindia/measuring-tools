using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace MeasuringTools
{
    public class DuctTapeSelection : MonoBehaviour
    {

        public static DuctTapeSelection instance;


      
        public bool isDuctTapeSelected;

        public MeshCollider ductCol;
        public BoxCollider ductBoxUpperJawCol;
        public BoxCollider ductDepthRodCol;


        private void Start()
        {
            instance = this;
        }

        public void OnMouseDown()
        {
            DuctTapeSelcted();
        }

        public void DuctTapeSelcted()
        {
            isDuctTapeSelected = true;
            UIManager.instance.isobjectLowerJaw = true;
            UIManager.instance.tabletStartPanel.SetActive(false);
            UIManager.instance.objectiveTitle.SetActive(true);
            UIManager.instance.objectObjective.GetComponent<Text>().text = "Measure the DuctTape Inner, Outer Diameter and Depth ";
            RemainingObjectDeselect();
            VernierCaliper.instance.ResetVernierScale();
            UIManager.instance.VernierCaliperSelected();

            if(InstructionMeasuringTools.instance.isInstructionClick)
            {
                InstructionMeasuringTools.instance.ductTapeSelectedI.SetActive(false);
                InstructionMeasuringTools.instance.clickCmAndMmI.SetActive(false);
                UIManager.instance.ductTape.GetComponentInChildren<BoxCollider>().enabled = false;
                UIManager.instance.ductTape.GetComponentInChildren<MeshCollider>().enabled = false;
                InstructionMeasuringTools.instance.ductTapePositionI.SetActive(true);
            }
        }

        public void DeselectDuctTape()
        {
            isDuctTapeSelected = false;

        }


        public void RemainingObjectDeselect()
        {
            Coin10Selection.instance.DeselecteCoin10();
            GlassSelection.instance.DeselcetGalss();
            BoxSelection.instance.DeselectBox();
            BallSelection.instance.DeselectBall();
            UIManager.instance.DeselectDimensionPanels();
        }



    }
}