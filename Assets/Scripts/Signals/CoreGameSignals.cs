using System;
using UnityEngine;
using UnityEngine.Events;

namespace Signals
{
    public class CoreGameSignals : MonoBehaviour
    {
        public UnityAction<byte> onLevelLoad = delegate(byte arg0) {  };
        public UnityAction onLevelDestroy = delegate {  };
        public UnityAction onNextLevel = delegate {  };
        public UnityAction onRestartLevel = delegate {  };
        public UnityAction onReset = delegate {  };
        
        public Func<byte> onGetLevelValue = delegate { return 0; }; // Func: Supports parameter and return values.

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