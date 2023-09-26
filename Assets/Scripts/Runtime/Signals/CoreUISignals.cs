using Runtime.Enums;
using UnityEngine;
using UnityEngine.Events;

namespace Runtime.Signals
{
    public class CoreUISignals: MonoBehaviour
    {
        public UnityAction<UIPanelType, int> onOpenPanel = delegate {  }; // int: Panel Layer index
        public UnityAction<int> onClosePanel = delegate {  };
        public UnityAction onCloseAllPanels = delegate {  };
        
        public static CoreUISignals Instance;
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