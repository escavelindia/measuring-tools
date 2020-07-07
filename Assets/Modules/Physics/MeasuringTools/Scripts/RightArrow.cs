using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MeasuringTools
{
    public class RightArrow : MonoBehaviour
    {
        public Rigidbody rb;
        public float sliderMoveSpeed = 1f;

        public void OnMouseDown()
        {
            // Debug.Log("dd");
            DragObject.instance.isLeftDrag = false;
            DragObject.instance.isRightDrag = true;
        }
    }
}