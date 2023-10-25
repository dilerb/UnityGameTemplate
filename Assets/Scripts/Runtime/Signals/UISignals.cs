using Runtime.Extensions;
using UnityEngine.Events;

namespace Runtime.Signals
{
    public class UISignals: SingletonMono<UISignals>
    {
        public UnityAction onPlay = delegate { };
        public UnityAction onReset = delegate {  };
    }
}