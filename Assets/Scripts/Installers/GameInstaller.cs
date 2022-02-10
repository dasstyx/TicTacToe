using tictac.Bootstrap;
using tictac.GameRules;
using tictac.GameRules.GameTurnCheck;
using tictac.UI;
using Zenject;

namespace tictac.Installers
{
    public class GameInstaller : MonoInstaller
    {
        private readonly int _boardSize = 3;

        public override void InstallBindings()
        {
            Container.BindInstance(_boardSize).WhenInjectedInto(typeof(TicTacTurnChecker));
            Container.BindInterfacesTo<TicTacTurnChecker>().AsSingle();
            Container.Bind<IMarkViewFactory>().To<MarkViewFactory>().FromComponentInHierarchy().AsSingle();

            Container.BindFactory<Player[], int, TurnWarden, TurnWarden.Factory>();
            WardenSetup();

            Container.Bind<ResolvePlayerFromResult>().AsSingle();
            Container.Bind<PersistentData>().FromComponentInHierarchy().AsSingle();
        }

        private void WardenSetup()
        {
            var bootstrap = FindObjectOfType<GameBootstrap>();
            Container.Bind<TurnWarden>().FromMethod(bootstrap.WardenSetup).AsSingle();
        }
    }
}