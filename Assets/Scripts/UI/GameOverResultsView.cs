using tictac.GameRules.GameTurnCheck;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace tictac.UI
{
    [RequireComponent(typeof(CanvasGroup))]
    public class GameOverResultsView : MonoBehaviour
    {
        [SerializeField] private GameObject _winnerTextGroup;
        [SerializeField] private GameObject _drawTextGroup;
        [SerializeField] private Text _playerLabel;
        [Inject] private IGameOverNotificator _notificator;
        [Inject] private ResolvePlayerFromResult _resolvePlayer;

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
                var player = _resolvePlayer.ResultToPlayer(result);
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
}