using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class scoreDisplayer : MonoBehaviour
{
    [SerializeField] private  ScoreManager scoreManager;


    [SerializeField] private TMP_Text text;

    [SerializeField] private const string prefix = "score : ";
    
    private void Start()
    {
        scoreManager.scoreEvents += ScoreManagerOnscoreEvents;
    }

    private void ScoreManagerOnscoreEvents(long score)
    {
        text.SetText(prefix + score);
    }


}
