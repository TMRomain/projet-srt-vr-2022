using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField]
    Transform mainDroite;


    [SerializeField]
    Transform mainGauche;


    [SerializeField]
    Transform cameraPosition;

    float valeurRotationHaut = 90;

    [SerializeField]
    float margeDetection = 10;


    [SerializeField]
    float vitesseAccendente = 50;

    [SerializeField]

    float resistanceAir = 10;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Ajouter && estDansMarge(mainGauche.eulerAngles.x,valeurRotationHaut,margeDetection) quand relier au case
        if(estDansMarge(mainDroite.eulerAngles.x,valeurRotationHaut,margeDetection) ){
            Debug.Log("Vol");
        }
        // Debug.Log(mainDroite.eulerAngles.x);
    }
    

    bool estDansMarge(float valeur,float valeurSouhaiter,float marge){
        if( valeur <= valeurSouhaiter+marge ){
            if(valeurSouhaiter-marge >= valeur ){
                return false;
            }
        }
        return true;
    }
}
