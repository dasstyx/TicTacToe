using System;
using tictac.GameRules;

namespace tictac.Tiles
{
    [Serializable]
    public class Tile : ITile
    {
        private bool _isEmpty = true;
        private TurnWarden _turnWarden;

        public Tile(TurnWarden turnWarden, int x, int y)
        {
            _turnWarden = turnWarden;
            X = x;
            Y = y;
        }

        public int X { get; }

        public int Y { get; }

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
}