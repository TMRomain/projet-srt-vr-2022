using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudManager : MonoBehaviour
{

    [SerializeField]
    private ScoreManager scoreManager;

    [SerializeField] private Text textScore;
    [SerializeField] private Text textChrono;

    private void Awake()
    {
        scoreManager.scoreEvents += ScoreManagerOnscoreEvents;
    }

    private void ScoreManagerOnscoreEvents(long score)
    {
        textScore.text = score + "";
        Debug.Log("salut" + score);
    }

    private void Update()
    {
        DateTime dateTime = scoreManager.getTempEcouler();
        textChrono.text =  dateTime.Minute + ":" + 
                     dateTime.Second + ":" +
                     dateTime.Millisecond;
    }
}
