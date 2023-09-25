using UnityEngine;

namespace Commands.Inputs
{
    public class Finger
    {
        public bool IsTouchBegan(int i = 0)
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(i);
                return touch.phase == TouchPhase.Began;
            }

            return false;
        }

        public bool IsTouchEnded(int i = 0)
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(i);
                return touch.phase == TouchPhase.Ended;
            }

            return false;
        }
        
        public bool IsTouchMoved(int i = 0)
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(i);
                return touch.phase == TouchPhase.Moved;
            }

            return false;
        }

        public Vector2? GetTouchDeltaPosition(int i=0)
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(i);
                return touch.deltaPosition;
            }

            return null;
        }
        public Vector2? GetTouchPosition(int i=0)
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(i);
                return touch.position;
            }

            return null;
        }
    }
}