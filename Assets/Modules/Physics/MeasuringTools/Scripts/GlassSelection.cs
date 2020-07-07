using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MeasuringTools
{
    public class GlassSelection : MonoBehaviour
    {

        public static GlassSelection instance;

        public bool isGlassSelected;

        public MeshCollider glassCol;
        public BoxCollider glassBCol;

        public void Start()
        {
            instance = this;
        }

        public void OnMouseDown()
        {
            GlassSelected();

        }

        public void GlassSelected()
        {
            isGlassSelected = true;
            UIManager.instance.isobjectLowerJaw = true;
            UIManager.instance.tabletStartPanel.SetActive(false);
            UIManager.instance.toolSelection.SetActive(true);
            UIManager.instance.objectiveTitle.SetActive(true);
            UIManager.instance.objectObjective.GetComponent<Text>().text = "Measure the Glass Inner, Outer Diameter And Depth";
            RemainingObjectDeselect();
            VernierCaliper.instance.ResetVernierScale();
            UIManager.instance.VernierCaliperSelected();
        }

        public void DeselcetGalss()
        {
            isGlassSelected = false;

        }


        public void RemainingObjectDeselect()
        {
            Coin10Selection.instance.DeselecteCoin10();
            DuctTapeSelection.instance.DeselectDuctTape();
            BoxSelection.instance.DeselectBox();
            BallSelection.instance.DeselectBall();
            UIManager.instance.DeselectDimensionPanels();
        }





    }
}