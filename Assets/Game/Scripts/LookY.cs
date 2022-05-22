using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookY : MonoBehaviour
{
    [SerializeField]
    public float speed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // get mouse X position every frame
        float _mouseX = Input.GetAxis("Mouse Y");

        //use temp variable to make the code more readable
        Vector3 newRotation = transform.localEulerAngles;
        newRotation.x -= _mouseX * speed; // -= make it unreversed
        transform.localEulerAngles = newRotation;

        // use transform.localEulerAngles to modify the y value in the rotation
        // we cannot forget the x and the z value
        // transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y + _mouseX, transform.localEulerAngles.z);


    }
}
