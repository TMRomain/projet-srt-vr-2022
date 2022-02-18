using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SocialPlatforms.Impl;
using Object = UnityEngine.Object;

public class anneaux : MonoBehaviour
{
    [SerializeField] private Object explosion;
    [SerializeField] private String tag = "Player";

    [SerializeField] public UnityEvent anneauxCompleteEvent;
    
    [SerializeField] private Transform positionDeLexplosion;


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);
        if (other.CompareTag(tag))
        {
            Instantiate(explosion, positionDeLexplosion.position, Quaternion.Euler(Vector3.zero));
            anneauxCompleteEvent.Invoke();
            Invoke("hide", 0.5f); 
        }
    }

    private void hide()
    {
        Destroy(gameObject);
    }
}
