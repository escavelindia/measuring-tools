using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace MeasuringTools
{
    public class MouseCursor : MonoBehaviour
    {

        public Texture2D normalCursor;
        public Texture2D scrollCursor;
        public Texture2D penCursoer;
        public Texture2D selectableCursor;
        public Texture2D selected;
        public Texture2D notSelectable;

        Vector2 hotspot = Vector2.zero;
        CursorMode curMode = CursorMode.Auto;

        public static bool obstacle;

        void Start()
        {

            //Cursor.SetCursor(normalCursor, hotspot, curMode);
        }

        void Update()
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Input.GetMouseButtonDown(0))
            {
                if (Physics.Raycast(ray, out hit, 10000) || IsPointerOverUIObject())
                {
                    obstacle = true;
                }
                else obstacle &= (IsPointerOverUIObject() || Physics.Raycast(ray, out hit, 10000));
            }

            if (Physics.Raycast(ray, out hit, 10000))
            {
                //Debug.Log(hit.collider.name);
                Cursor.SetCursor(selectableCursor, hotspot, curMode);
            }
            else
            {
                Cursor.SetCursor(normalCursor, hotspot, curMode);
            }


        }


        bool IsPointerOverUIObject()
        {
            PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current)
            {
                position = new Vector2(Input.mousePosition.x, Input.mousePosition.y)
            };
            List<RaycastResult> results = new List<RaycastResult>();
            EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
            return results.Count > 0;
        }

    }
}