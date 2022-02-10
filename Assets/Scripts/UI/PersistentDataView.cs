using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class PersistentDataView : MonoBehaviour
{
    [Inject] private PersistentData _persistentData;
    [SerializeField] private Text _xCountText;
    [SerializeField] private Text _oCountText;

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