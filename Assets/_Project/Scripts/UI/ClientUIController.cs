using System;
using _Project.Scripts.Network;
using TMPro;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.UI
{
    public class ClientUIController : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI messageUIPrefab;
        [SerializeField] private RectTransform messagesContainer;
        
        [Inject] IClientNetworkSubscriptionService _networkSubscriptionService;

        public void AddMessageToUI(string msg)
        {
            var messageLabel = Instantiate(messageUIPrefab, messagesContainer);
            messageLabel.text = $"{DateTime.Now.ToLongTimeString()}: {msg}";
            messageLabel.rectTransform.localPosition = new Vector3(10, (messagesContainer.childCount - 1) * -50 - 10, 0);
            messagesContainer.sizeDelta = new Vector2(0, messagesContainer.childCount * 50 + 20);
        }
        
        public void OnSubscribeButton()
        {
            _networkSubscriptionService.Subscribe(NetworkMessageType.HelloMessage);
        }

        public void OnUnsubscribeButton()
        {
            _networkSubscriptionService.Unsubscribe(NetworkMessageType.HelloMessage);
        }

        private void OnApplicationQuit()
        {
           _networkSubscriptionService.Disconnect();
        }
    }
}