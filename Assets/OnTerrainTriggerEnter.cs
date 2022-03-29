using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnTerrainTriggerEnter : MonoBehaviour
{


    [SerializeField] private String playerTag = "Player";
    private void Awake()
    {
        TerrainCollider terrain = gameObject.GetComponent<TerrainCollider>();
        terrain.isTrigger = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name.ToString());
        if (other.CompareTag(playerTag))
        {
            Invoke("Hide", 2);
        }
    }

    private void Hide()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
