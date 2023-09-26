using System;
using UnityEngine;
using UnityEngine.Events;

namespace Runtime.Signals
{
    public class CoreGameSignals : MonoBehaviour
    {
        public UnityAction<byte> onLevelLoad = delegate {  }; // UnityAction: Supports only parameters
        public UnityAction onLevelDestroy = delegate {  };
        public UnityAction onNextLevel = delegate {  };
        public UnityAction onRestartLevel = delegate {  };
        public UnityAction onReset = delegate {  };
        
        public Func<byte> onGetLevelValue = delegate { return 0; }; // Func: Supports parameters and return values.

        public static CoreGameSignals Instance;
        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
        }
    }
}