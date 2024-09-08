using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontaInput;
    public float speed = 10.0f;
    void Start()
    {
        
    }

   
    void Update()
    {
        if (transform.position.x < -10)
        {
            horizontaInput = Input.GetAxis("Horizontal");
            transform.Translate(Vector3.right * horizontaInput * Time.deltaTime * speed);
        }
    }
}
