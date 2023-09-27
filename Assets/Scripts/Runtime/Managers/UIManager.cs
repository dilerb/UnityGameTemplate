using Runtime.Enums;
using Runtime.Signals;
using UnityEngine;

namespace Runtime.Managers
{
    public class UIManager: MonoBehaviour
    {
        private void OnEnable() => SubscribeEvents();
        
        private void OnDisable() => UnSubscribeEvents();
        
        private void SubscribeEvents()
        {
            CoreGameSignals.Instance.onLevelLoad += OnLevelLoad;
            CoreGameSignals.Instance.onLevelWin += OnLevelWin;
            CoreGameSignals.Instance.onLevelLose += OnLevelLose;
            CoreGameSignals.Instance.onReset += OnReset;
        }

        private void UnSubscribeEvents()
        {
            CoreGameSignals.Instance.onLevelLoad -= OnLevelLoad;
            CoreGameSignals.Instance.onLevelWin -= OnLevelWin;
            CoreGameSignals.Instance.onLevelLose -= OnLevelLose;
            CoreGameSignals.Instance.onReset -= OnReset;
        }

        private void OnLevelLose()
        {
            CoreUISignals.Instance.onOpenPanel?.Invoke(UIPanelType.Lose, 2);
        }

        private void OnLevelWin()
        {
            CoreUISignals.Instance.onOpenPanel?.Invoke(UIPanelType.Win, 2);
        }

        private void OnLevelLoad(byte arg0)
        {
            // when level initialized do smt like;
            //                                      level number,
            //                                      level stages,
            //                                      level panel
        }

        private void OnReset()
        {
            CoreUISignals.Instance.onCloseAllPanels?.Invoke();
            CoreUISignals.Instance.onOpenPanel?.Invoke(UIPanelType.Start, 1);
        }
        
        public void Play()
        {
            UISignals.Instance.onPlay?.Invoke();
            CoreUISignals.Instance.onClosePanel?.Invoke(1);
            InputSignals.Instance.onInputEnable?.Invoke();
        }

        public void NextLevel()
        {
            CoreGameSignals.Instance.onNextLevel?.Invoke();
        }

        public void RestartLevel()
        {
            CoreGameSignals.Instance.onRestartLevel?.Invoke();   
        }
    }
}