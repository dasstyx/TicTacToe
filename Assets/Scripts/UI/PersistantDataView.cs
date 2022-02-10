using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class PersistantDataView : MonoBehaviour
{
    [Inject] private PersistantData _persistantData;
    [SerializeField] private Text _xCountText;
    [SerializeField] private Text _oCountText;

    private void Start()
    {
        _persistantData.SubscribeOnScoreChange(UpdateScore);
        UpdateScore();
    }

    private void UpdateScore()
    {
        _xCountText.text = _persistantData.XCount.ToString();
        _oCountText.text = _persistantData.OCount.ToString();
    }
}