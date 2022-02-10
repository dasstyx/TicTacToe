using System;

namespace tictac.GameRules.GameTurnCheck
{
    public interface IGameOverNotificator
    {
        void SubscribeToGameOver(Action<TurnResult> gameOver);
    }
}