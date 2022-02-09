using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    private readonly int _boardSize = 3;
    
    public override void InstallBindings()
    {
        Container.BindInstance(_boardSize).WhenInjectedInto(typeof(TicTacTurnChecker), typeof(GameBootstrapUI));
        Container.BindInterfacesTo<TicTacTurnChecker>().AsSingle();
        Container.Bind<IMarkViewFactory>().To<MarkViewFactory>().FromComponentInHierarchy().AsSingle();
        //TileGridMakeSetup();

        Container.BindFactory<Player[], int, TurnWarden, TurnWarden.Factory>();
        WardenSetup();
    }

    private void TileGridMakeSetup()
    {
        var uiBootstrap = GameObject.FindObjectOfType<GameBootstrapUI>();
        Container.Bind<ITileViewGridFactory>()
            .To<TileViewGridFactory>()
            .FromMethod(uiBootstrap.GetTileViewGridMake)
            .AsSingle();
    }

    private void WardenSetup()
    {
        Container.Bind<TurnWarden>().AsSingle().Lazy();
        // var bootstrap = GameObject.FindObjectOfType<GameBootstrap>();
        // Container.Bind<TurnWarden>().FromMethod(bootstrap.WardenSetup);  
    }
}