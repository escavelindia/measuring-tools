using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MeasuringTools
{
    public class BallSelection : MonoBehaviour
    {

        public static BallSelection instance;

        public bool isBallSelected;

        public void Start()
        {
            instance = this;
       
        }

        public void OnMouseDown()
        {

            BallSelected();
        }

        public void BallSelected()
        {
            isBallSelected = true;
            UIManager.instance.tabletStartPanel.SetActive(false);
            UIManager.instance.tabletStartPanel.SetActive(false);
            UIManager.instance.objectiveTitle.SetActive(true);
            UIManager.instance.objectObjective.GetComponent<Text>().text = "Measure the Marble Diameter";
            RemainingObjectDeselect();
            VernierCaliper.instance.ResetVernierScale();
            UIManager.instance.VernierCaliperSelected();

        }

        public void DeselectBall()
        {
            isBallSelected = false;

        }


        public void RemainingObjectDeselect()
        {
            Coin10Selection.instance.DeselecteCoin10();
            GlassSelection.instance.DeselcetGalss();
            BoxSelection.instance.DeselectBox();
            DuctTapeSelection.instance.DeselectDuctTape();
            UIManager.instance.DeselectDimensionPanels();
        }
    }
}