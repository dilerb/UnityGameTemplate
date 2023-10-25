using Runtime.Extensions;
using Runtime.Keys;
using UnityEngine.Events;

namespace Runtime.Signals
{
    public class InputSignals: SingletonMono<InputSignals>
    {
        // Necessary input signals
        public UnityAction onFirstTimeTouchTaken = delegate { };
        public UnityAction<InputInfo> onInputInfoChange = delegate {  };
        public UnityAction onInputEnable = delegate { };
        public UnityAction onInputDisable = delegate { };
        public UnityAction onInputTaken = delegate {  };
        public UnityAction<HorizontalInputParams> onInputDragged = delegate {  };
        public UnityAction onInputReleased = delegate {  };
    }
}