using System;

namespace Runtime.Data.ValueObjects
{
    [Serializable]
    
    public struct InputData
    {
        //Some Input datas like; vertical or horizontal input speed according to all screen sizes.
        public float HorizontalInputSpeed { get; set; }
        public float ClampSpeed { get; set; }
    }
}