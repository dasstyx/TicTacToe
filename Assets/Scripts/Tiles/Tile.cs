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
        var turnDone = MakeTurn();
        if (!_isEmpty || !turnDone)
        {
            return false;
        }
        _isEmpty = false;
        return true;
    }

    private bool MakeTurn()
    {
        return _turnWarden.MakeTurn(this);
    }
}