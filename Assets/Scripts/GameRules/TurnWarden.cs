using System;
using Zenject;

public class TurnWarden
{
    private Player[] _players;
    private int _activePlayerIndex;
    private Player _activePlayer => _players[_activePlayerIndex];
    private ITicTacTurnChecker _checker;
    
    public class Factory : PlaceholderFactory<Player[], int, TurnWarden>
    {
    }

    public TurnWarden(Player[] players, int activePlayer, ITicTacTurnChecker checker)
    {
        _players = players;
        _activePlayerIndex = activePlayer;
        _checker = checker;
    }

    public bool MakeTurn(ITile tile)
    {
        return MakeTurn(_activePlayer, tile);
    }

    public bool MakeTurn(Player player, ITile tile)
    {
        if (player != _activePlayer)
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
        return _activePlayer.MarkTypeHolding;
    }

    private void SwapPlayers()
    {
        _activePlayerIndex = _activePlayerIndex == 0 ? 1 : 0;
    }
}