using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerSnake : NetworkBehaviour
{
    public static event Action<PlayerName> ServerOnPlayerSpawned;
    public static event Action<PlayerName> ServerOnPlayerDespawned;
    [SerializeField] private TailSpawner _tailSpawner;
    [SerializeField] private PlayerName _playerName;

    public override void OnStartServer()
    {
        ServerOnPlayerSpawned?.Invoke(_playerName);
        Debug.Log(1);
    }

    public void DestroySelf()
    {
        ServerOnPlayerDespawned?.Invoke(_playerName);
        foreach (var tail in _tailSpawner.Tails)
            NetworkServer.Destroy(tail);
        NetworkServer.Destroy(gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Border border))
        {
            DestroySelf();
        }
    }
}
