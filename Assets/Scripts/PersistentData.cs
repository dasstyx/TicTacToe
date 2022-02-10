using System;
using tictac.GameRules.GameTurnCheck;
using UnityEngine;
using Zenject;

namespace tictac
{
    public class PersistentData : MonoBehaviour
    {
        [Inject] private IGameOverNotificator _notificator;
        private Action _onChange;
        public int XCount { get; private set; }
        public int OCount { get; private set; }

        private void Start()
        {
            LoadData();
            _notificator.SubscribeToGameOver(result => HandleResult(result));
        }

        public void SubscribeOnScoreChange(Action onChange)
        {
            _onChange += onChange;
        }

        private void HandleResult(TurnResult result)
        {
            if (result == TurnResult.Draw)
            {
                return;
            }

            if (result == TurnResult.Cross)
            {
                XCount++;
                PlayerPrefs.SetInt("X", XCount);
            }
            else if (result == TurnResult.Zero)
            {
                OCount++;
                PlayerPrefs.SetInt("O", OCount);
            }

            _onChange?.Invoke();
        }

        private void LoadData()
        {
            XCount = PlayerPrefs.GetInt("X", 0);
            OCount = PlayerPrefs.GetInt("O", 0);
            _onChange?.Invoke();
        }
    }
}