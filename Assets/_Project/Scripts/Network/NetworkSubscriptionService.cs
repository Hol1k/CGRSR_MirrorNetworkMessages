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
        }

        private void OnSubscribe(NetworkConnectionToClient conn, SubscribeMessage msg)
        {
            if (!_connectionsSubscriptions.ContainsKey(conn))
                _connectionsSubscriptions.Add(conn, new HashSet<NetworkMessageType>());

            _connectionsSubscriptions[conn].Add(msg.SubscriptionType);
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
    }
}