using System.Collections.Generic;
using Mirror;
using UnityEngine;

namespace _Project.Scripts.Network
{
    public class NetworkSubscriptionService : IServerNetworkSubscriptionService, IClientNetworkSubscriptionService
    {
        private Dictionary<NetworkConnectionToClient, HashSet<NetworkMessageType>> _connectionsSubscriptions;
        
        public void RegisterHost()
        {
            _connectionsSubscriptions = new Dictionary<NetworkConnectionToClient, HashSet<NetworkMessageType>>();
            NetworkServer.RegisterHandler<SubscribeMessage>(OnSubscribe);
            NetworkServer.RegisterHandler<UnsubscribeMessage>(OnUnsubscribe);
            NetworkServer.RegisterHandler<DisconnectMessage>(OnDisconnect);
        }

        private void OnSubscribe(NetworkConnectionToClient conn, SubscribeMessage msg)
        {
            if (!_connectionsSubscriptions.ContainsKey(conn))
                _connectionsSubscriptions.Add(conn, new HashSet<NetworkMessageType>());

            _connectionsSubscriptions[conn].Add(msg.SubscriptionType);
        }

        private void OnUnsubscribe(NetworkConnectionToClient conn, UnsubscribeMessage msg)
        {
            if (!_connectionsSubscriptions.ContainsKey(conn))
                return;

            _connectionsSubscriptions[conn].Remove(msg.SubscriptionType);
        }
        
        private void OnDisconnect(NetworkConnectionToClient conn, DisconnectMessage msg)
        {
            _connectionsSubscriptions.Remove(conn);
        }

        public void SendAllHelloMessage(HelloMessage message, out int sentMessagesCount)
        {
            sentMessagesCount = 0;
            foreach (var (conn, subs) in _connectionsSubscriptions)
            {
                if (subs.Contains(NetworkMessageType.HelloMessage))
                {
                    conn.Send(message);
                    sentMessagesCount++;
                }
            }
        }

        public void RegisterClient()
        {
            NetworkClient.RegisterHandler<HelloMessage>(OnHello);
        }

        private void OnHello(HelloMessage msg)
        {
            Debug.Log($"Server received HelloMessage: {msg}");
        }

        public void Subscribe(NetworkMessageType type)
        {
            NetworkClient.Send(new SubscribeMessage { SubscriptionType = type });
        }

        public void Unsubscribe(NetworkMessageType type)
        {
            NetworkClient.Send(new UnsubscribeMessage { SubscriptionType = type });
        }
        public void Disconnect()
        {
            NetworkClient.Send(new DisconnectMessage());
        }
    }
}