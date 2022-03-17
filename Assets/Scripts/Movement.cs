using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float speed = 5;
    CharacterController characterController;
    Vector3 direction;


    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        direction.z = speed;
    }

    private void FixedUpdate()
    {
        if(characterController.isGrounded == false)
        {
            direction += Physics.gravity;
        }
        characterController.Move(direction * Time.fixedDeltaTime);
    }

}
