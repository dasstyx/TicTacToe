using tictac.GameRules;
using tictac.Tiles;
using UnityEngine;
using Zenject;

namespace tictac.UI
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class TileView : MonoBehaviour, ITile
    {
        [Inject] private IMarkViewFactory _markFactory;
        private Tile _tile;
        [Inject] private TurnWarden _turnWarden;

        private void OnMouseDown()
        {
            Debug.Log($"{X} {Y}");
            ApplyTile();
        }

        public int X => _tile.X;
        public int Y => _tile.Y;

        public bool ApplyTile()
        {
            var type = _turnWarden.GetCurrentMark();
            var result = _tile.ApplyTile();
            if (result)
            {
                var go = _markFactory.Create(type, transform.position);
                go.transform.SetParent(transform);
            }

            return result;
        }

        public void Initialize(int x, int y)
        {
            _tile = new Tile(_turnWarden, x, y);
        }
    }
}