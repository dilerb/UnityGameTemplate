using UnityEngine;

namespace Commands.Inputs
{
    public class Mouse
    {
        public bool GetMouseButtonDown(int i = 0) => Input.GetMouseButtonDown(i);
        public bool GetMouseButtonUp(int i = 0) => Input.GetMouseButtonUp(i);
        public bool GetMouseButtonMoved(int i = 0) => Input.GetMouseButton(i);
        public Vector2 GetMousePosition() => (Vector2)Input.mousePosition;
    }
}