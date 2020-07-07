using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MeasuringTools
{
    public class LeftArrow : MonoBehaviour
    {

        public float sliderMoveSpeed = 1f;
        public Rigidbody rb;

        public void OnMouseDown()
        {

            DragObject.instance.isLeftDrag = true;
            DragObject.instance.isRightDrag = false;


        }
    }
}