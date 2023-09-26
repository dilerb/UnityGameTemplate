using Runtime.Keys;
using UnityEngine;
using UnityEngine.Events;

namespace Runtime.Signals
{
    public class InputSignals: MonoBehaviour
    {
        // Necessary input signals
        public UnityAction onFirstTimeTouchTaken = delegate { };
        public UnityAction<InputInfo> onInputInfoChange = delegate {  };
        public UnityAction onInputEnable = delegate { };
        public UnityAction onInputDisable = delegate { };
        public UnityAction onInputTaken = delegate {  };
        public UnityAction<HorizontalInputParams> onInputDragged = delegate {  };
        public UnityAction onInputReleased = delegate {  };
        
        public static InputSignals Instance;
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