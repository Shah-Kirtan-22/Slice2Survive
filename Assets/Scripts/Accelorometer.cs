using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Accelorometer : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField]
    private float speed = 5.0f;

    private void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    
    private void Update()
    {
        rb.AddForce(Input.acceleration);
    }

    private void FixedUpdate()
    {
        Vector3 direction = new Vector3(Input.acceleration.x, 0.0f, 0.0f);
        rb.velocity += direction * speed;
    }
}
