using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    [SerializeField] 
    private float speed = 5; // Character speed, set in the inspector

    CharacterController characterController;
    Vector3 direction;
    public Button jump;

    [SerializeField]
    private float jumpHeight = 2f;
    
    private float timer = 10.0f; // to increase the value of the speed variable


    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        jump = GameObject.FindGameObjectWithTag("Jump").GetComponent<Button>();
        jump.onClick.AddListener(Jump);
    }

    private void Update()
    {
        direction.z = speed;
        direction.y += -9.81f * Time.deltaTime;

        if (Time.realtimeSinceStartup >= timer)
        {
            IncreaseSpeed();
            timer = Time.realtimeSinceStartup + 5.0f; // Update the speed variable every 10 seconds
        }
    }

    private void FixedUpdate()
    {
        characterController.Move(direction * Time.fixedDeltaTime); // will move in z at "speed" and y if pressed down

        if(characterController.transform.position.y <= -15f)
        {
            OnGameOver();
        }
    }

    public void Jump()
    {
        direction.y = jumpHeight;
    }

    private void IncreaseSpeed()
    {
        speed++;
    }

    public void OnGameOver()
    {
        GameOver.isGameOver = true;
    }

}
