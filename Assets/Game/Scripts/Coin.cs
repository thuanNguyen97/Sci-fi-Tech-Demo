using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField]
    private AudioClip _coinPickupSound;

    //check for collision (onTrigger)
    private void OnTriggerStay(Collider other) 
    {
        if (other.tag == "Player")
        {
            //check if player collide with the coin and e key pressed
            if (Input.GetKeyDown(KeyCode.E))
            {
                //get player component
                Player player = other.GetComponent<Player>();

                if (player != null) 
                {
                    //give the player the coin
                    player.hasCoin = true;

                     //play the coin sound
                    AudioSource.PlayClipAtPoint(_coinPickupSound, transform.position, 1f);

                    //destroy the coin object
                    Destroy(this.gameObject);
                }
            }
        }           
    }
}
