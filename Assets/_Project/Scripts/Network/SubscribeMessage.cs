using Mirror;

namespace _Project.Scripts.Network
{
    public struct SubscribeMessage : NetworkMessage
    {
        public NetworkMessageType SubscriptionType;
    }
}