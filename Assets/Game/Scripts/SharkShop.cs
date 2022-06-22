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
            Player player = other.GetComponent<Player>();
            UIManager uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();

            if (player.hasCoin == true)
            {
                uiManager.buyTextEnable();
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                if (player != null)
                {
                    if (player.hasCoin == true)
                    {
                        player.hasCoin = false;
                        
                        if (uiManager != null)
                        {
                            uiManager.RemoveCoin();
                            uiManager.buyTextDisable();
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
