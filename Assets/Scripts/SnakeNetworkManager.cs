using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class SnakeNetworkManager : NetworkManager
{
    [SerializeField] private GameObject _foodSpawner;
    [SerializeField] private GameObject _gameOverHandler;

    public override void OnStartServer()
    {
        GameObject gameover = Instantiate(_gameOverHandler);
        NetworkServer.Spawn(gameover);
    }

    public override void OnServerAddPlayer(NetworkConnectionToClient conn)
    {
        base.OnServerAddPlayer(conn);

        if (numPlayers < 2)
        {
            return;
        }

        GameObject foodSpawner = Instantiate(_foodSpawner);
        NetworkServer.Spawn(foodSpawner);

    }
}
