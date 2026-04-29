using _Project.Scripts.Network;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.UI
{
    public class ClientUIController : MonoBehaviour
    {
        [Inject] IClientNetworkSubscriptionService _networkSubscriptionService;

        public void OnSubscribeButton()
        {
            _networkSubscriptionService.Subscribe(NetworkMessageType.HelloMessage);
        }
    }
}