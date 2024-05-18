using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using System;

public class GameOverHandler : NetworkBehaviour
{
    private List<PlayerName> _playerNames = new List<PlayerName>();
    public static event Action<string> ClientOnGameOver;

    public override void OnStartServer()
    {
        PlayerSnake.ServerOnPlayerSpawned += ServerHandlePlayerSpawned;
        PlayerSnake.ServerOnPlayerDespawned += ServerHandlePlayerDespawned;
        Debug.Log(2);
    }

    public override void OnStopServer()
    {
        PlayerSnake.ServerOnPlayerSpawned -= ServerHandlePlayerSpawned;
        PlayerSnake.ServerOnPlayerDespawned -= ServerHandlePlayerDespawned;
    }

    public void ServerHandlePlayerSpawned(PlayerName player)
    {
        _playerNames.Add(player);
    }

    public void ServerHandlePlayerDespawned(PlayerName player)
    {
        Debug.Log("despawn");
        _playerNames.Remove(player);
        if(_playerNames.Count != 1)
        {
            return;
        }
        else
        {
            RPCGameOver(_playerNames[0].name);
        }
    }

    [ClientRpc]
    private void RPCGameOver(string winner)
    {
        ClientOnGameOver.Invoke(_playerNames[0].name);
    }
}
