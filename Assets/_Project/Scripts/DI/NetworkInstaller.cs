using _Project.Scripts.Network;
using Mirror;
using Zenject;

namespace _Project.Scripts.DI
{
    public class NetworkInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<NetworkManager>().FromComponentInHierarchy().AsSingle();
            Container.BindInterfacesAndSelfTo<NetworkSubscriptionService>().AsSingle();
        }
    }
}