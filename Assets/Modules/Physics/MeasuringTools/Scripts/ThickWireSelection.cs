using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MeasuringTools
{
    public class ThickWireSelection : MonoBehaviour
    {


        public static ThickWireSelection instance;

        public bool isThickWireSelected;

        private void Start()
        {
            instance = this;
        }

        public void OnMouseDown()
        {
            ThickWireSelected();
        }


        public void ThickWireSelected()
        {
            isThickWireSelected = true;
            UIManager.instance.tabletStartPanel.SetActive(false);
            UIManager.instance.toolSelection.SetActive(true);
            UIManager.instance.objectObjective.GetComponent<Text>().text = "Measure the Thick Wire Diameter";
            RemainingObjectDeselect();
            UIManager.instance.MicrometerSelected();
        }

        public void DeselecThickWire()
        {
            isThickWireSelected = false;
         
        }


        public void RemainingObjectDeselect()
        {
           // CoinMSelection.instance.DeselectCoinM();
            PaperSelection.instance.DeselectPaper();
            BallMSelection.instance.DeselectBall();
            ThinWireSelection.instance.DeselecThinWire();
            UIManager.instance.DeselectDimensionPanels();

        }

    }


}
