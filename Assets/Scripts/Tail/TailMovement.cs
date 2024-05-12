using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TailMovement : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private TailNetwork _tail;

    private void Update()
    {
        _agent.SetDestination(_tail.Target.transform.position);
    }
}
