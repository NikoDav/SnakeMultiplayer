using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using System;

public class Food : NetworkBehaviour
{
    [SerializeField] GameObject particlePrefab;
    public static event Action ServerOnFoodEaten;
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
            elapsedTime = 0;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        FindObjectOfType<Snake>().AddTail();
        currentParticle = Instantiate
            (particlePrefab, transform.position, particlePrefab.transform.rotation);
        NetworkServer.Spawn(currentParticle);
        //StartCoroutine(DelayDestroyBoom());
        Destroy(gameObject);
        FindObjectOfType<FoodSpawner>().SpawnFood();
        ServerOnFoodEaten?.Invoke();
        NetworkServer.Destroy(gameObject);
    }

   /* private IEnumerator DelayDestroyBoom()
    {
        yield return new WaitForSeconds(3);
        NetworkServer.Destroy(currentParticle);
    }*/
}
