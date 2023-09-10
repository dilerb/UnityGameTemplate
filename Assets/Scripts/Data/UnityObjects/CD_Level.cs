using System.Collections.Generic;
using Data.ValueObjects;
using UnityEngine;

namespace Data.UnityObjects
{
    [UnityEngine.CreateAssetMenu(fileName = "CD_level", menuName = "Scriptable Objects", order = 0)]
    public class CD_Level : ScriptableObject
    {
        public List<LevelData> LevelDatas;
    }
}