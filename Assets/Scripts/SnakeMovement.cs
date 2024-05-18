using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Mirror;

public class SnakeMovement : NetworkBehaviour
{
    [SerializeField] float speed = 3f, rotationSpeed = 180f, speedChange = 0.5f;

    public float Speed { get { return speed; } }

    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime * Input.GetAxis("Horizontal"));
    }



    
}
