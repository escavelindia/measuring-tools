using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MeasuringTools
{
    public class CentimeterScale : MonoBehaviour
    {
        public static CentimeterScale instance;
        public GameObject cmButtonObject;

        public bool isCMSelected;

        private void Awake()
        {
            instance = this;
        }

        void OnMouseDown()
        {
            if(UIManager.instance.isSubmitPressed==false)
            {
                VernierCaliper.instance.CentimeterScaleSelected();
            }
           
        }
    }
}

