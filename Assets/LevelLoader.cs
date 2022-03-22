using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{

    [SerializeField] private int indexSceneToLoad = 1;
    [SerializeField] private String playerTag = "Player";

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);
        if (other.tag.CompareTo(playerTag) == 0)
        {
            SceneManager.LoadScene(indexSceneToLoad);
        } 
    }
}
