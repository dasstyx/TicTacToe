using UnityEngine;

namespace tictac.UI
{
    public class TileViewOnScene : TileView
    {
        [SerializeField] private int _assignX;
        [SerializeField] private int _assignY;

        private void Start()
        {
            Initialize(_assignX, _assignY);
        }
    }
}