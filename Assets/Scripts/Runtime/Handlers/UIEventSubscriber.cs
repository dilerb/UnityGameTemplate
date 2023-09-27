using Runtime.Enums;
using Runtime.Managers;
using UnityEngine;
using UnityEngine.UI;

namespace Runtime.Handlers
{
    public class UIEventSubscriber : MonoBehaviour
    {
        [SerializeField] private UIEventSubscriptionType buttonType;
        [SerializeField] private Button button;

        private UIManager _uiManager;
        private void OnEnable() => SubscribeEvents();
        private void OnDisable() => UnSubscribeEvents();

        private void Awake()
        {
            _uiManager = FindObjectOfType<UIManager>();
        }
        private void SubscribeEvents()
        {
            switch (buttonType)
            {
                case UIEventSubscriptionType.Play:
                    button.onClick.AddListener(_uiManager.Play);
                    break;
                case UIEventSubscriptionType.NextLevel:
                    button.onClick.AddListener(_uiManager.NextLevel);
                    break;
                case UIEventSubscriptionType.RestartLevel:
                    button.onClick.AddListener(_uiManager.RestartLevel);
                    break;
            }
        }
        
        private void UnSubscribeEvents()
        {
            switch (buttonType)
            {
                case UIEventSubscriptionType.Play:
                    button.onClick.RemoveListener(_uiManager.Play);
                    break;
                case UIEventSubscriptionType.NextLevel:
                    button.onClick.RemoveListener(_uiManager.NextLevel);
                    break;
                case UIEventSubscriptionType.RestartLevel:
                    button.onClick.RemoveListener(_uiManager.RestartLevel);
                    break;
            }
        }
    }
}