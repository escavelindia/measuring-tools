using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MeasuringTools
{
    public class ThinWireSelection : MonoBehaviour
    {

        public static ThinWireSelection instance;

        public bool isThinWireSelected;

        private void Start()
        {
            instance = this;
        }

        public void OnMouseDown()
        {
            ThinWireSelected();
        }
  

        public void ThinWireSelected()
        {
            isThinWireSelected = true;
            UIManager.instance.tabletStartPanel.SetActive(false);
            UIManager.instance.toolSelection.SetActive(true);
            UIManager.instance.objectObjective.GetComponent<Text>().text = "Measure the Thin Wire Diameter";
            RemainingObjectDeselect();
            UIManager.instance.MicrometerSelected();
        }

        public void DeselecThinWire()
        {
           isThinWireSelected = false;
       
        }


        public void RemainingObjectDeselect()
        {
           // CoinMSelection.instance.DeselectCoinM();
            PaperSelection.instance.DeselectPaper();
            BallMSelection.instance.DeselectBall();
            ThickWireSelection.instance.DeselecThickWire();
            UIManager.instance.DeselectDimensionPanels();

        }
    }
}


