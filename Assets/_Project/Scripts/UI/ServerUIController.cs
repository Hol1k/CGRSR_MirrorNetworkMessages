using _Project.Scripts.Network;
using TMPro;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.UI
{
    public class ServerUIController : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI sentMessagesCountLabel;
        [SerializeField] private TMP_InputField message;

        [Inject] IServerNetworkSubscriptionService _networkSubscriptionService;

        public void OnSendMessageButton()
        {
            _networkSubscriptionService.SendAllHelloMessage(new HelloMessage {Message = message.text}, out int sentMessagesCount);
            sentMessagesCountLabel.text = $"Sent messages for {sentMessagesCount} subscribers";
        }
    }
}