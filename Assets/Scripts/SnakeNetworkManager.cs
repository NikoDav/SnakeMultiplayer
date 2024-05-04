using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class SnakeNetworkManager : NetworkManager
{
    [SerializeField] private GameObject _foodSpawner;
    public override void OnServerAddPlayer(NetworkConnectionToClient conn)
    {

        base.OnServerAddPlayer(conn);
        if(numPlayers < 2)
        {
            return;
        }
        GameObject foodSpawner = Instantiate(_foodSpawner);
        NetworkServer.Spawn(foodSpawner);

    }
}
