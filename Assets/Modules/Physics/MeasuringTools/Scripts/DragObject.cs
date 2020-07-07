using UnityEngine;
using System.Collections;


namespace MeasuringTools
{

    [RequireComponent(typeof(MeshCollider))]
    public class DragObject : MonoBehaviour
    {

        public static DragObject instance;

        public Rigidbody rb;

        private Vector3 screenPoint;
        private Vector3 offset;
        public float moveSpeed;

        public bool isLeftDrag;
        public bool isRightDrag;

        private void Start()
        {
            instance = this;
        }

        void OnMouseDown()
        {
            screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);

            offset = gameObject.transform.position - Camera.main.ScreenToViewportPoint(new Vector3(Input.mousePosition.x, screenPoint.y, screenPoint.z));
            Debug.Log("hh");
            Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, screenPoint.y, screenPoint.z);

            Vector3 curPosition = Camera.main.ScreenToViewportPoint(curScreenPoint) + offset;
            //transform.position = curPosition;

            if (isLeftDrag)
            {
                rb.velocity = Vector3.left;//*(-curPosition);
            }

            if (isRightDrag)
            {
                rb.velocity = Vector3.right;
            }
        }

        public void LeftClick()
        {
            isLeftDrag = true;
            isRightDrag = false;

            OnMouseDown();
        }

        public void RightClick()
        {
            isRightDrag = true;
            isLeftDrag = false;

            OnMouseDown();
        }
    }
}