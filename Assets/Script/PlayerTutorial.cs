using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTutorial : MonoBehaviour
{
    [SerializeField]
    GameObject[] objectForGame;
    [SerializeField]
    GameObject[] tutorialObject;

    public void Start(){
        EnableTutorial();
    }
     public void Update(){
        if(Input.GetButtonDown("Fire1")){
            DisableTutorial();
        }
    }
    private void DisableTutorial()
    {
        foreach(GameObject obj in tutorialObject)
        {
            obj.SetActive(false);
        }
        foreach (GameObject obj in objectForGame)
        {
            obj.SetActive(true);
        }
    }
    private void EnableTutorial()
    {
        foreach (GameObject obj in tutorialObject)
        {
            obj.SetActive(true);
        }
        foreach (GameObject obj in objectForGame)
        {
            obj.SetActive(false);
        }
    }
}
