using _Project.Scripts.Network;
using Mirror;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.UI
{
    public class MainMenuController : MonoBehaviour
    {
        [Inject] private NetworkManager _networkManager;
        
        [Inject(Id = "MainMenuCanvas")] private GameObject _mainMenuCanvas;
        [Inject(Id = "ServerCanvas")] private GameObject _serverCanvas;
        [Inject(Id = "ClientCanvas")] private GameObject _clientCanvas;
        
        public void OnStartHost()
        {
            _networkManager.StartHost();
            _mainMenuCanvas.SetActive(false);
            _serverCanvas.SetActive(true);
        }

        public void OnStartClient()
        {
            _networkManager.StartClient();
            _mainMenuCanvas.SetActive(false);
            _clientCanvas.SetActive(true);
        }
    }
}