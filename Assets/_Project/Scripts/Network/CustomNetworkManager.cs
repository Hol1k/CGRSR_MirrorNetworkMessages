using Mirror;
using Zenject;

namespace _Project.Scripts.Network
{
    public class CustomNetworkManager : NetworkManager
    {
        [Inject] private NetworkSubscriptionService _service;

        public override void OnStartServer()
        {
            _service.RegisterHost();
        }

        public override void OnStartClient()
        {
            _service.RegisterClient();
        }
    }
}