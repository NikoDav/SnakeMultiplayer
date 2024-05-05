using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class TailSpawner : NetworkBehaviour
{
    [SerializeField] GameObject tailPrefab;
    [SerializeField] float speed = 3f, rotationSpeed = 180f, speedChange = 0.5f;
    public List<GameObject> Tails { get; } = new List<GameObject>();
    public float Speed { get { return speed; } }
    public override void OnStartServer()
    {
        Food.ServerOnFoodEaten += AddTail;
    }

    public override void OnStopServer()
    {
        Food.ServerOnFoodEaten -= AddTail;
    }

    public void AddTail(GameObject playerWhoAte)
    {
        if (playerWhoAte != gameObject) return;
        var tail = Instantiate(tailPrefab, Tails.Count == 0 ? transform.position : Tails[Tails.Count - 1].transform.position, Quaternion.identity);
        speed += speedChange;
        NetworkServer.Spawn(tail, connectionToClient);
    }
}
