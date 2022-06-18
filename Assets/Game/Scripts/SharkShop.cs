using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkShop : MonoBehaviour
{
    //check for collision
    //check if player 
    //check for the e key
    //check if player has coin
    //remove coin from player
    //update inventory display
    //play the sound
    //if not, debug get out of here

    private void OnTriggerStay(Collider other) 
    {
        if (other.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Player player = other.GetComponent<Player>();
                if (player != null)
                {
                    if (player.hasCoin == true)
                    {
                        player.hasCoin = false;

                        UIManager uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();

                        if (uiManager != null)
                        {
                            uiManager.RemoveCoin();
                        }

                        AudioSource audio = GetComponent<AudioSource>();

                        audio.Play();

                        player.EnableWeapon();
                    }
                    else
                    {
                        Debug.Log("Get out of here!");
                    }
                }
            }

        }    
    }
}
