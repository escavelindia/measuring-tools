using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MeasuringTools
{
    public class MiliMeterSelection : MonoBehaviour
    {
        public static MiliMeterSelection instance;


        public GameObject miliMeterButton;

        public bool isMMSelected;

        private void Awake()
        {
            instance = this;
        }

        private void OnMouseDown()
        {
            if (UIManager.instance.isSubmitPressed==false)
            {
                VernierCaliper.instance.MiliMeterScaleslected();
            }
           
        }
    }

}
