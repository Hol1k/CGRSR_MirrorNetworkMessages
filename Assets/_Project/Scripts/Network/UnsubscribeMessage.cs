using Mirror;

namespace _Project.Scripts.Network
{
    public struct UnsubscribeMessage : NetworkMessage
    {
        public NetworkMessageType SubscriptionType;
    }
}