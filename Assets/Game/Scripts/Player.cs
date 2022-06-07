using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController _controller;

    [SerializeField]
    private float _speed = 3.5f;

    [SerializeReference]
    private float _gravity = 9.8f;


    // Start is called before the first frame update
    void Start()
    {
        //hide mouse cursor
        //and lock it in the center
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        _controller = GetComponent<CharacterController>(); //Get access to Character controller component    
    }

    // Update is called once per frame
    void Update()
    {
        //if left mouse clicked
        //cast a ray at the center of the main camera
        if (Input.GetMouseButtonDown(0)) // get mouse left click
        {
            Ray rayOrigin = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2f, Screen.height / 2f, 0)); // cast a ray from the center of the screen

            //check if we ray cast hit something
            if (Physics.Raycast(rayOrigin, Mathf.Infinity))
            {
                Debug.Log("Raycast hit something!!");
            }
        }

        //if escape key pressed
        //unhide mouse cursor
        //unlock it
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }

        CalculateMovement();
    }

    void CalculateMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Specify direction of the character's movement

        // y = 0 because it is related to gravity
        Vector3 direction = new Vector3(horizontalInput, 0,verticalInput); 

        // create player velocity
        Vector3 velocity = direction * _speed;

        // apply gravity in every frame
        velocity.y -= _gravity;

        velocity = transform.transform.TransformDirection(velocity); // convert local space to world space

        // parsing direction variable to Move()
        _controller.Move(velocity * Time.deltaTime); // *Time.deltaTime to apply it in real time
    }
}
