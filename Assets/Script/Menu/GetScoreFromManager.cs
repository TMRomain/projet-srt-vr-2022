using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GetScoreFromManager : MonoBehaviour
{
    
    [SerializeField] private GameObject scoreManager;
    [SerializeField] private GameObject scoreText;
    [SerializeField] private GameObject tempsText;
    
    public void UpdateText()
    {
        scoreText.GetComponent<TextMeshProUGUI>().text = scoreManager.GetComponent<ScoreManager>().getScore().ToString();
        tempsText.GetComponent<TextMeshProUGUI>().text = scoreManager.GetComponent<ScoreManager>().getTempEcouler().ToString();
    }
}
