using System;

public interface IGameOverNotificator
{
    void SubscribeToGameOver(Action<TurnResult> gameOver);
}