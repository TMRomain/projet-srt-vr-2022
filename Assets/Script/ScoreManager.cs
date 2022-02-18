using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{

    [SerializeField] private long score;

    public delegate void ScoreEventHandler(long score);

    public event ScoreEventHandler scoreEvents;

    private DateTime dateTimeLancement;

    [SerializeField]
    private bool estNiveauEnCours = false;
    
    [Header("multiplicateur de point de temps (s)")]
    [SerializeField] private int timeScoreFactor;
    [Header("différence entre le meilleur temps et le pire temps (s) ")]
    [SerializeField] private float timeScoreLimit;
    [Header("Temp attendu (s)")]
    [SerializeField] private long tempAttendu;
    
    
    public void lancerNiveau()
    {
        score = 0;
        scoreEvents?.Invoke(score);
        dateTimeLancement = DateTime.Now;
        estNiveauEnCours = true;
    }


    public DateTime getTempEcouler()
    {
        return estNiveauEnCours ? new DateTime(DateTime.Now.Subtract(dateTimeLancement).Ticks) : DateTime.MinValue;
    }
    
    public void addScore()
    {
        score++;
        scoreEvents?.Invoke(score);
    }

    public long getScore()
    {
        return score;
    }

    public void stopNiveau()
    {
        float tempsEcoulerEnSeconde = ((float) getTempEcouler().Ticks) / 10000000;
        Debug.Log("temps ecouler  : " + tempsEcoulerEnSeconde); 
        Debug.Log("temps attendu  : " + tempAttendu);
        float diffTemp =  Math.Abs(tempsEcoulerEnSeconde - tempAttendu);
        Debug.Log("diff temp : " +  diffTemp);
        float pointEnPlus = timeScoreLimit / diffTemp * timeScoreFactor;
        Debug.Log("point temps : " +     pointEnPlus);
        score += (int) pointEnPlus;
        scoreEvents?.Invoke(score);
        estNiveauEnCours = false;
    }
}
