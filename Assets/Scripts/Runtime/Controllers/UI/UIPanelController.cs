using System.Collections.Generic;
using Runtime.Enums;
using Runtime.Signals;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Runtime.Controllers.UI
{
    public class UIPanelController: MonoBehaviour
    {
        [SerializeField] private List<Transform> layers = new List<Transform>();
        
        private void OnEnable() => SubscribeEvents();
        private void OnDisable() => UnSubscribeEvents();

        private void SubscribeEvents()
        {
            CoreUISignals.Instance.onClosePanel += OnClosePanel;
            CoreUISignals.Instance.onOpenPanel += OnOpenPanel;
            CoreUISignals.Instance.onCloseAllPanels += OnCloseAllPanels;
        }

        private void UnSubscribeEvents()
        {
            CoreUISignals.Instance.onClosePanel -= OnClosePanel;
            CoreUISignals.Instance.onOpenPanel -= OnOpenPanel;
            CoreUISignals.Instance.onCloseAllPanels -= OnCloseAllPanels;
        }
[Button]
        private void OnOpenPanel(UIPanelType panelType, int layerIndex)
        {
            OnClosePanel(layerIndex);
            Instantiate(Resources.Load<GameObject>($"Screens/{panelType}Panel"), layers[layerIndex]);
        }

        private void OnClosePanel(int layerIndex)
        {
            if (layers[layerIndex].childCount <= 0) return;
            
#if UNITY_EDITOR
                DestroyImmediate(layers[layerIndex].GetChild(0).gameObject); //Destroy in Editor
#else
                Destroy(layers[layerIndex].GetChild(0).gameObject); //Destroy in Runtime
#endif
        }

        private void OnCloseAllPanels()
        {
            foreach (var layer in layers)
            {
                if (layer.childCount > 0)
                {
#if UNITY_EDITOR
                    DestroyImmediate(layer.GetChild(0).gameObject);
#else
                    Destroy(layer.GetChild(0).gameObject);
#endif   
                }
            }
        }
    }
}