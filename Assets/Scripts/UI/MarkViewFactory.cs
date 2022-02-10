using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

namespace tictac.UI
{
    public class MarkViewFactory : MonoBehaviour, IMarkViewFactory
    {
        [SerializeField] private GameObject _crossPrefab;
        [SerializeField] private GameObject _zeroPrefab;
        private Dictionary<MarkType, GameObject> _typeToPrefab;

        private void Start()
        {
            _typeToPrefab = new Dictionary<MarkType, GameObject>
            {
                {MarkType.Cross, _crossPrefab},
                {MarkType.Zero, _zeroPrefab}
            };
        }

        public GameObject Create(MarkType type, Vector2 position)
        {
            var prefab = _typeToPrefab[type];
            return Instantiate(prefab, position, quaternion.identity);
        }
    }
}