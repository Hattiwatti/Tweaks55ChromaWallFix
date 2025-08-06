using Zenject;

namespace Tweaks55ChromaWallFix
{
    internal class PlayerInstaller : Installer
    {
        public override void InstallBindings()
        {
            this.Container.BindInterfacesTo<HarmonyPatches>().AsSingle();
        }
    }
}
