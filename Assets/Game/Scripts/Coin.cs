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
            //get access to UIManager
            UIManager uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();

            //get player component
            Player player = other.GetComponent<Player>();

            if (player.hasCoin == false)
            {
                uiManager.pickUpTextEnable();
            }
            
            //check if player collide with the coin and e key pressed
            if (Input.GetKeyDown(KeyCode.E))
            {
                

                if (player != null) 
                {
                    //give the player the coin
                    player.hasCoin = true;

                     //play the coin sound
                    AudioSource.PlayClipAtPoint(_coinPickupSound, transform.position, 1f);

                    if (uiManager != null) //check if we found the component
                    {
                        uiManager.CollectedCoin();
                        uiManager.pickupTextDisable();
                    }

                    //destroy the coin object
                    Destroy(this.gameObject);
                }
            }
        }           
    }
}
