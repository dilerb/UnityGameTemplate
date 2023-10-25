using System;
using Runtime.Extensions;
using UnityEngine.Events;

namespace Runtime.Signals
{
    public class CoreGameSignals : SingletonMono<CoreGameSignals>
    {
        public UnityAction<byte> onLevelLoad = delegate {  }; // UnityAction: Supports only parameters
        public UnityAction onLevelWin = delegate {  };
        public UnityAction onLevelLose = delegate {  };
        public UnityAction onLevelDestroy = delegate {  };
        public UnityAction onNextLevel = delegate {  };
        public UnityAction onRestartLevel = delegate {  };
        public UnityAction onReset = delegate {  };
        
        public Func<byte> onGetLevelValue = delegate { return 0; }; // Func: Supports parameters and return values.
    }
}