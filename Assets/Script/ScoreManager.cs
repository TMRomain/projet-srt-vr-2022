using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{

    [SerializeField] private long score;

    public delegate void ScoreEventHandler(long score);

    public event ScoreEventHandler scoreEvents;
    
    public void addScore()
    {
        score++;
        scoreEvents?.Invoke(score);
    }

    public long getScore()
    {
        return score;
    }

}
