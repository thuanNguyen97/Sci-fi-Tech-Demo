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
        _controller = GetComponent<CharacterController>(); //Get access to Character controller component    
    }

    // Update is called once per frame
    void Update()
    {
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

        // parsing direction variable to Move()
        _controller.Move(velocity * Time.deltaTime); // *Time.deltaTime to apply it in real time
    }
}
