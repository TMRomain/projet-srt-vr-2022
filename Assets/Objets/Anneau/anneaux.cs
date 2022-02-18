using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using Object = UnityEngine.Object;

public class anneaux : MonoBehaviour
{
    [SerializeField] private Object explosion;
    [SerializeField] private String tag = "Player";

    
    [SerializeField] private ScoreManager scoreManager;

    [SerializeField] private Transform positionDeLexplosion;

    private void Start()
    {
        if (scoreManager == null)
        {
            Debug.LogError("LE SCORE MANAGER NEST PAS SET DANS LES ANNEAUX !!!");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);
        if (other.CompareTag(tag))
        {
            Instantiate(explosion, positionDeLexplosion.position, Quaternion.Euler(Vector3.zero));
            scoreManager.addScore();
            Invoke("hide", 0.5f); 
        }
    }

    private void hide()
    {
        Destroy(gameObject);
    }
}
