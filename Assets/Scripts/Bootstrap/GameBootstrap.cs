using tictac.GameRules;
using tictac.GameRules.GameTurnCheck;
using UnityEngine;
using Zenject;
using Random = System.Random;

namespace tictac.Bootstrap
{
    public class GameBootstrap : MonoBehaviour
    {
        [Inject] private IGameOverNotificator _notificator;
        private TurnWarden _warden;
        [Inject] private TurnWarden.Factory _wardenFactory;

        public TurnWarden WardenSetup()
        {
            Player[] players =
            {
                new Player(MarkType.Cross, "player 1"),
                new Player(MarkType.Zero, "player 2")
            };

            var rand = new Random();
            var firstPlayer = rand.Next(0, 1);

            _warden = _wardenFactory.Create(players, firstPlayer);
            return _warden;
        }
    }
}