using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using System;

public class Food : NetworkBehaviour
{
    [SerializeField] GameObject particlePrefab;
    public static event Action<GameObject> ServerOnFoodEaten;
    private float elapsedTime;
    private GameObject currentParticle;

    private void Update()
    {
        if(currentParticle == null)
        {
            return;
        }

        elapsedTime += Time.deltaTime;
        if(elapsedTime >= 3)
        {
            NetworkServer.Destroy(currentParticle);
            Destroy(currentParticle);
            elapsedTime = 0;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        ServerParticles();
        FindObjectOfType<FoodSpawner>().SpawnFood(gameObject);
        ServerOnFoodEaten?.Invoke(other.gameObject);
        NetworkServer.Destroy(gameObject);
        Destroy(gameObject);
        //StartCoroutine(DelayDestroyBoom());
    }

    [Server]
    public void ServerParticles()
    {
        currentParticle = Instantiate
            (particlePrefab, transform.position, particlePrefab.transform.rotation);
        NetworkServer.Spawn(currentParticle);
    }

   /* private IEnumerator DelayDestroyBoom()
    {
        yield return new WaitForSeconds(3);
        NetworkServer.Destroy(currentParticle);
    }*/
}
