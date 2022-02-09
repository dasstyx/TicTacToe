using System;
using Zenject;

[Serializable]
public class Tile : ITile
{
    private TurnWarden _turnWarden;
    private bool _isEmpty = true;
    private int _x;
    private int _y;

    public int X => _x;

    public int Y => _y;

    public Tile(TurnWarden turnWarden, int x, int y)
    {
        _turnWarden = turnWarden;
        _x = x;
        _y = y;
    }

    public bool ApplyTile()
    {
        if (!_isEmpty)
        {
            return false;
        }

        _isEmpty = false;
        MakeTurn();
        return true;
    }

    private void MakeTurn()
    {
        _turnWarden.MakeTurn(this);
    }
}