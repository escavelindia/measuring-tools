using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MeasuringTools
{
    public class PaperSelection : MonoBehaviour
    {

        public static PaperSelection instance;
        public bool isPaperSelected;
        public BoxCollider boxCol;

        private void Start()
        {
            instance = this;
        }
        public void OnMouseDown()
        {
            PaperSelected();
        }

        public void PaperSelected()
        {
            isPaperSelected = true;
            UIManager.instance.tabletStartPanel.SetActive(false);
            UIManager.instance.toolSelection.SetActive(true);
            UIManager.instance.objectObjective.GetComponent<Text>().text = "Measure Metal Sheet Thickness";
            RemainingObjectDeselect();
            UIManager.instance.MicrometerSelected();
        }

        public void DeselectPaper()
        {
            isPaperSelected = false;

        }


        public void RemainingObjectDeselect()
        {
            //CoinMSelection.instance.DeselectCoinM();
            ThinWireSelection.instance.DeselecThinWire();
            ThickWireSelection.instance.DeselecThickWire();
            BallMSelection.instance.DeselectBall();
            UIManager.instance.DeselectDimensionPanels();

        }
    }
}