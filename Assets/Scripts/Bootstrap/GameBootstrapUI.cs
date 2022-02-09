using UnityEngine;
using Zenject;

/// <summary>
/// Don't use
/// </summary>
public class GameBootstrapUI : MonoBehaviour
{
    [Inject] private int _gameSize;
    [Inject] private ITileViewGridFactory _tileViewGridFactory;
    [SerializeField] private Transform _gridRoot;
    [SerializeField] private float _marksDistance;
    [SerializeField] private TileView _tilePrefab;

    private void Start()
    {
        _tileViewGridFactory.Create(_gridRoot, _gameSize, _gameSize);
    }
    
    public TileViewGridFactory GetTileViewGridMake()
    {
        return new TileViewGridFactory(_tilePrefab, _marksDistance);
    }
}