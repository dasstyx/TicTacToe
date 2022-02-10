using UnityEngine;
using UnityEngine.UI;
using Zenject;

[RequireComponent(typeof(CanvasGroup))]
public class GameOverResultsView : MonoBehaviour
{
    [Inject] private IGameOverNotificator _notificator;
    [Inject] private ResolvePlayerFromResult _resolvePlayer;

    [SerializeField] private GameObject _winnerTextGroup;
    [SerializeField] private GameObject _drawTextGroup;
    [SerializeField] private Text _playerLabel;

    private void Start()
    {
        _notificator.SubscribeToGameOver(result => GameOver(result));
    }
    
    private void GameOver(TurnResult result)
    {
        TurnCanvasOn();
        if (result == TurnResult.Draw)
        {
            _drawTextGroup.SetActive(true);
        }
        else
        {
            _winnerTextGroup.SetActive(true);
            Player player = _resolvePlayer.ResultToPlayer(result);
            _playerLabel.text = player.Name;
        }
    }

    private void TurnCanvasOn()
    {
        var panelCanvas = GetComponent<CanvasGroup>();
        panelCanvas.alpha = 1;
        panelCanvas.interactable = true;
        panelCanvas.blocksRaycasts = true;
    }
}