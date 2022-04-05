using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    [SerializeField] 
    private float speed = 5; // Character speed, set in the inspector

    CharacterController characterController;
    Vector3 direction; // used to alter the individual components for either forward movement or jump

    public Button jump;
    public Button crouch;

    [SerializeField]
    private float jumpHeight = 2f;

    private float gravityValue = -9.81f;
    
    private float timer = 10.0f; // to increase the value of the speed variable

    [HideInInspector]
    public static int coinCount;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();

        coinCount = 0; // initialize the coin count at 0 at the start of the game

        jump = GameObject.FindGameObjectWithTag("Jump").GetComponent<Button>();
        jump.onClick.AddListener(Jump);

        crouch = GameObject.FindGameObjectWithTag("Crouch").GetComponent<Button>();
        crouch.onClick.AddListener(Crouch);
    }

    private void Update()
    {
        direction.z = speed;
        direction.y += gravityValue * Time.deltaTime;

        if (Time.realtimeSinceStartup >= timer)
        {
            IncreaseSpeed();
            timer = Time.realtimeSinceStartup + 5.0f; // Update the speed variable every 10 seconds
        }

        if (characterController.transform.position.y <= -15f)
        {
            OnGameOver();
        }
    }
    
    private void FixedUpdate()
    {
        characterController.Move(direction * Time.fixedDeltaTime); // will move in z at "speed" and y if pressed down
        /*
        if (characterController.transform.position.y <= -15f)
        {
            OnGameOver();
        }*/
    }

    public void Jump()
    {
        if(characterController.isGrounded == true)
            direction.y = Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
    } 
    
    public void Crouch()
    {
        if (characterController.isGrounded == false)
            direction.y = jumpHeight * -1.0f;
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
