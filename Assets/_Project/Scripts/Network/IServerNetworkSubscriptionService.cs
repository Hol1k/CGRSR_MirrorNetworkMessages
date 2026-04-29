namespace _Project.Scripts.Network
{
    public interface IServerNetworkSubscriptionService
    {
        void SendAllHelloMessage(HelloMessage message, out int sentMessagesCount);
    }
}