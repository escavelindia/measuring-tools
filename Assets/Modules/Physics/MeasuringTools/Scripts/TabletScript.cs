using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MeasuringTools
{
    public class TabletScript : MonoBehaviour
    {
        public bool isTabletCloseView;

        public void OnMouseDown()
        {
            isTabletCloseView = !isTabletCloseView;
            if (isTabletCloseView)
            {
                CameraSwitchVernierCaliper.instance.FrontCameraView();
                if (InstructionMeasuringTools.instance.isInstructionClick)
                {
                    if (ToolSelection.instance.isVernierCaliper)
                    {
                        InstructionMeasuringTools.instance.tabletCol.GetComponent<BoxCollider>().enabled = false;
                        InstructionMeasuringTools.instance.tabletClickI.SetActive(false);
                        InstructionMeasuringTools.instance.ductTapeSelectedI.SetActive(true);
                        UIManager.instance.ductTape.GetComponentInChildren<BoxCollider>().enabled = true;
                        UIManager.instance.ductTape.GetComponentInChildren<MeshCollider>().enabled = true;
                        VernierCaliper.instance.zoomOutB_Vernier.GetComponent<Button>().interactable = false;
                        
                    }
                    if(ToolSelection.instance.isMicrometer)
                    {
                        InstructionMeasuringTools.instance.tabletClickI.SetActive(false);
                        InstructionMeasuringTools.instance.instructionDoneMI.SetActive(true);
                    }
                  
                }
            }
            else
            {
                CameraSwitchVernierCaliper.instance.TabletCloseView();
            }
        }
    }
}