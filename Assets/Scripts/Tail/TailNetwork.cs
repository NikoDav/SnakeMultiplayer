using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class TailNetwork : NetworkBehaviour
{
    [SyncVar] private Snake _owner;
    [SyncVar] private GameObject _target;

    public  Snake Owner => _owner;
    public GameObject Target => _target;


    public override void OnStartServer()
    {
        _owner = connectionToClient.identity.GetComponent<Snake>();
        List<GameObject> tails = _owner.GetComponent<TailSpawner>().Tails;
        _target = tails.Count == 0 ? Owner.gameObject : tails[tails.Count - 1];
        tails.Add(gameObject);
    }
}
