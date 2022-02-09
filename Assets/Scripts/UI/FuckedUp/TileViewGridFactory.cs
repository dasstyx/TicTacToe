using UnityEngine;

public class TileViewGridFactory : ITileViewGridFactory
{
    private readonly TileView _prefab;
    private readonly float _distance = 0.2f;

    public TileViewGridFactory(TileView prefab, float distance)
    {
        _prefab = prefab;
        _distance = distance;
    }

    public void Create(Transform root, int rows, int columns)
    {
        Vector3 centralPos = root.position;
        var startPos = new Vector3(
            _distance * columns,
            _distance * rows,
            0);
        startPos = centralPos - startPos / 2;

        var pos = startPos;
        var tileNumber = 0;
        for (var y = 0; y < rows; y++)
        {
            for (var x = 0; x < columns; x++)
            {
                var go = MonoBehaviour.Instantiate(_prefab, pos, Quaternion.identity);
                go.transform.SetParent(root, true);
                TileSetup(go, x, y);

                pos.x += _distance;
                tileNumber++;
            }

            pos.y +=_distance;
            pos.x = startPos.x;
        }
    }

    protected virtual void TileSetup(TileView tile, int x, int y)
    {
        tile.Initialize(x, y);
    }
}