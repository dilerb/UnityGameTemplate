using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Runtime.Utilities
{
    public static class InputUtils
    {
        public static bool IsPointerOverUIElement(Vector2 inputPointerPosition)
        {
            var eventData = new PointerEventData(EventSystem.current)
            {
                position = inputPointerPosition
            };

            var results = new List<RaycastResult>();
            EventSystem.current.RaycastAll(eventData, results);
            return results.Count > 0;
        }
    }
}