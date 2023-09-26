using System.Collections.Generic;
using Runtime.Data.ValueObjects;
using UnityEngine;

namespace Runtime.Data.UnityObjects
{
    [UnityEngine.CreateAssetMenu(fileName = "CD_level", menuName = "Scriptable Objects", order = 0)]
    public class CD_Level : ScriptableObject
    {
        public List<LevelData> LevelDatas;
    }
}