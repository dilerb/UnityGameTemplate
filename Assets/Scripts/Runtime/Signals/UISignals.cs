using UnityEngine;
using UnityEngine.Events;

namespace Runtime.Signals
{
    public class UISignals: MonoBehaviour
    {
        public UnityAction onPlay = delegate { };
        public UnityAction onReset = delegate {  };

        public static UISignals Instance;

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