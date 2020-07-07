using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MeasuringTools
{
    public class BoxSelection : MonoBehaviour
    {

        public static BoxSelection instance;

      
        public bool isBoxSelected;
        public BoxCollider boxCol;

        private void Start()
        {
            instance = this;
        }
        public void OnMouseDown()
        {
            BoxSelected();
        }

        public void BoxSelected()
        {
            isBoxSelected = true;
            UIManager.instance.tabletStartPanel.SetActive(false);
            UIManager.instance.objectiveTitle.SetActive(true);
            UIManager.instance.objectObjective.GetComponent<Text>().text = "Measure the Matchbox Length and Width";
            RemainingObjectDeselect();
            VernierCaliper.instance.ResetVernierScale();
            UIManager.instance.VernierCaliperSelected();
        }

        public void DeselectBox()
        {
            isBoxSelected = false;

        }


        public void RemainingObjectDeselect()
        {
            Coin10Selection.instance.DeselecteCoin10();
            GlassSelection.instance.DeselcetGalss();
            DuctTapeSelection.instance.DeselectDuctTape();
            BallSelection.instance.DeselectBall();
            UIManager.instance.DeselectDimensionPanels();

        }
    }
}