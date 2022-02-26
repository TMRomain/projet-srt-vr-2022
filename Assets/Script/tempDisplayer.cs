using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class tempDisplayer : MonoBehaviour
{
    [SerializeField] private  ScoreManager scoreManager;


    [SerializeField] private TMP_Text text;

    [SerializeField] private const string prefix = "temp : ";
    

    private void Update()
    {
        DateTime dateTime = scoreManager.getTempEcouler();
        text.SetText(prefix + 
                     dateTime.Minute + ":" + 
                     dateTime.Second + ":" +
                     dateTime.Millisecond);
    }
}
