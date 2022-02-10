using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace tictac.UI
{
    public class PersistentDataView : MonoBehaviour
    {
        [SerializeField] private Text _xCountText;
        [SerializeField] private Text _oCountText;
        [Inject] private PersistentData _persistentData;

        private void Start()
        {
            _persistentData.SubscribeOnScoreChange(UpdateScore);
            UpdateScore();
        }

        private void UpdateScore()
        {
            _xCountText.text = _persistentData.XCount.ToString();
            _oCountText.text = _persistentData.OCount.ToString();
        }
    }
}