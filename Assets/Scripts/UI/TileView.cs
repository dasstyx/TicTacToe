using System;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(BoxCollider2D))]
public class TileView : MonoBehaviour, ITile
{
    [Inject] private TurnWarden _turnWarden;
    [Inject] private IMarkViewFactory _markFactory;
    private Tile _tile;
    public int X => _tile.X;
    public int Y => _tile.Y;

    public void Initialize(int x, int y)
    {
        _tile = new Tile(_turnWarden, x, y);
    }

    private void OnMouseDown()
    {
        Debug.Log($"{X} {Y}");
        ApplyTile();
    }

    public bool ApplyTile()
    {
        var result = _tile.ApplyTile();
        if (result)
        {
            var type = _turnWarden.GetCurrentMark();
            var go = _markFactory.Create(type, transform.position);
            go.transform.SetParent(transform);
        }

        return result;
    }
}