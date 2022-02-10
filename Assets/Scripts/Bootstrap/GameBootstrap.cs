using System;
using UnityEngine;
using Zenject;

public class GameBootstrap : MonoBehaviour
{
    [Inject] private TurnWarden.Factory _wardenFactory;
    [Inject] private IGameOverNotificator _notificator;
    private TurnWarden _warden;

    public TurnWarden WardenSetup()
    {
        Player[] players = new[]
        {
            new Player(MarkType.Cross, "1"),
            new Player(MarkType.Zero, "2")
        };

        var rand = new System.Random();
        int firstPlayer = rand.Next(0, 1);
        
        _warden = _wardenFactory.Create(players, firstPlayer);
        return _warden;
    }
}