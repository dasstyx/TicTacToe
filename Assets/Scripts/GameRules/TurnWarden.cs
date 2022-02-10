using System;
using Zenject;

public class TurnWarden
{
    private IGameOverNotificator _notificator;
    private Player[] _players;
    private int _activePlayerIndex;
    public Player ActivePlayer => _players[_activePlayerIndex];
    private ITicTacTurnChecker _checker;
    // TODO: Move to the class, don't handle GameOver subscription
    private bool _stillPlaying;
    
    public class Factory : PlaceholderFactory<Player[], int, TurnWarden>
    {
    }

    public TurnWarden(Player[] players, int activePlayer, ITicTacTurnChecker checker, IGameOverNotificator notificator)
    {
        _stillPlaying = true;
        _players = players;
        _activePlayerIndex = activePlayer;
        _checker = checker;

        _notificator = notificator;
        _notificator.SubscribeToGameOver(_ => GameOver());
    }

    public bool MakeTurn(ITile tile)
    {
        return MakeTurn(ActivePlayer, tile);
    }

    public bool MakeTurn(Player player, ITile tile)
    {
        if (!_stillPlaying || player != ActivePlayer)
        {
            return false;
        }

        var mark = player.MarkTypeHolding;
        var x = tile.X;
        var y = tile.Y;
        _checker.DoMove(mark, x, y);

        SwapPlayers();
        return true;
    }

    public MarkType GetCurrentMark()
    {
        return ActivePlayer.MarkTypeHolding;
    }

    private void SwapPlayers()
    {
        _activePlayerIndex = _activePlayerIndex == 0 ? 1 : 0;
    }

    private void GameOver()
    {
        _stillPlaying = false;
    }
}