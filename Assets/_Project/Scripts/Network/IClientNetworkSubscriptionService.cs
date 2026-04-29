namespace _Project.Scripts.Network
{
    public interface IClientNetworkSubscriptionService
    {
        void Subscribe(NetworkMessageType type);
        void Unsubscribe(NetworkMessageType type);
        void Disconnect();
    }
}