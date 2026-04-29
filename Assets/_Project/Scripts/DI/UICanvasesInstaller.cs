using UnityEngine;
using Zenject;

namespace _Project.Scripts.DI
{
    public class UICanvasesInstaller : MonoInstaller
    {
        [SerializeField] private GameObject mainMenuCanvas;
        [SerializeField] private GameObject serverCanvas;
        [SerializeField] private GameObject clientCanvas;
        
        public override void InstallBindings()
        {
            Container.Bind<GameObject>().WithId("MainMenuCanvas").FromInstance(mainMenuCanvas);
            Container.Bind<GameObject>().WithId("ServerCanvas").FromInstance(serverCanvas);
            Container.Bind<GameObject>().WithId("ClientCanvas").FromInstance(clientCanvas);
        }
    }
}