using Runtime.Enums;
using Runtime.Extensions;
using UnityEngine.Events;

namespace Runtime.Signals
{
    public class CoreUISignals: SingletonMono<CoreUISignals>
    {
        public UnityAction<UIPanelType, int> onOpenPanel = delegate {  }; // int: Panel Layer index
        public UnityAction<int> onClosePanel = delegate {  };
        public UnityAction onCloseAllPanels = delegate {  };
    }
}