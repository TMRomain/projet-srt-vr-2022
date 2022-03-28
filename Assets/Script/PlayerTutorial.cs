using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTutorial : MonoBehaviour
{
    [SerializeField]
    GameObject player;
    [SerializeField]
    GameObject playerHUD;
    [SerializeField]
    GameObject tutorialHUD;

    public void Start(){
        tutorialHUD.SetActive(true);
        playerHUD.SetActive(false);
        player.SetActive(false);
    }
     public void Update(){
        if(Input.GetButtonDown("Fire1")){
            tutorialHUD.SetActive(false);
            playerHUD.SetActive(true);
            player.SetActive(true);
        }
    }
}
