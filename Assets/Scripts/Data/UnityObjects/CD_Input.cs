using Data.ValueObjects;
using UnityEngine;

namespace Data.UnityObjects
{
    [UnityEngine.CreateAssetMenu(fileName = "CD_Input", menuName = "Scriptable Objects", order = 0)]
    public class CD_Input : ScriptableObject
    {
        public InputData Data;
    }
}