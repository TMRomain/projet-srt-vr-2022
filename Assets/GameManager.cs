using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    public static GameManager Instance { get { return _instance; } }

    [SerializeField] private ScoreManager scoreManager;

    private bool estNiveauxActif = false;
    
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Debug.Log("erreur ! un gameManager existe déjà");
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }
    }

    public void lancerNiveau()
    {
        if(estNiveauxActif) stopNiveau();
        scoreManager.lancerNiveau();
        estNiveauxActif = true;
    }

    public void stopNiveau()
    {
        scoreManager.stopNiveau();
        estNiveauxActif = false;
    }
}
