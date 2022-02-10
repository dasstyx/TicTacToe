using System;
using UnityEngine;
using Zenject;

public class PersistentData : MonoBehaviour
{
    private Action _onChange;
    [Inject] private IGameOverNotificator _notificator;
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
        else if(result == TurnResult.Zero)
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