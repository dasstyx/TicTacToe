using System;
using UnityEngine;

public class TicTacTurnChecker : IGameOverNotificator, ITicTacTurnChecker
{
    private readonly TileState[,] _gameBoard;

    private readonly int _gridSize;
    private int _moveCount;

    private Action<TurnResult> _onGameOver;
    private ITicTacTurnChecker _ticTacTurnCheckerImplementation;


    public TicTacTurnChecker(int gridSize)
    {
        _gridSize = gridSize;
        _gameBoard = new TileState[_gridSize, _gridSize];
    }

    public void SubscribeToGameOver(Action<TurnResult> gameOver)
    {
        _onGameOver += gameOver;
    }

    public void DoMove(MarkType mark, int x, int y)
    {
        var state = mark == MarkType.Cross ? TileState.Cross : TileState.Zero;

        _gameBoard[x, y] = state;
        var result = CheckWin(state, x, y);

        if (result != TurnResult.None)
        {
            _onGameOver?.Invoke(result);
        }
    }

    private TurnResult CheckWin(TileState mark, int x, int y)
    {
        Func<TileState, TurnResult> markToGameResult =
            state => state == TileState.Cross ? TurnResult.Cross : TurnResult.Zero;

        for (var i = 0; i < _gridSize; i++)
        {
            if (_gameBoard[x, i] != mark)
            {
                break;
            }

            if (i == _gridSize - 1)
            {
                return markToGameResult(mark);
            }
        }

        for (var i = 0; i < _gridSize; i++)
        {
            if (_gameBoard[i, y] != mark)
            {
                break;
            }

            if (i == _gridSize - 1)
            {
                return markToGameResult(mark);
            }
        }

        if (x == y)
        {
            for (var i = 0; i < _gridSize; i++)
            {
                if (_gameBoard[i, i] != mark)
                {
                    break;
                }

                if (i == _gridSize - 1)
                {
                    return markToGameResult(mark);
                }
            }
        }

        if (x + y == _gridSize - 1)
        {
            for (var i = 0; i < _gridSize; i++)
            {
                if (_gameBoard[i, _gridSize - 1 - i] != mark)
                {
                    break;
                }

                if (i == _gridSize - 1)
                {
                    return markToGameResult(mark);
                }
            }
        }

        if (_moveCount == Mathf.Pow(_gridSize, 2) - 1)
        {
            return TurnResult.Draw;
        }

        return TurnResult.None;
    }
}