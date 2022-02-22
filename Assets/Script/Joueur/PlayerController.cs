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

    [SerializeField]
    GameObject player;


    float valeurRotationHaut = 270f;
    float valeurRotationAvant = 0f;
    float margeDetectionGaucheDroite = 0.3f;

    [SerializeField]
    float margeDetection = 10f;


    [SerializeField]
    float vitesseAccendente = 150f;

    [SerializeField]

    float resistanceAir = 10;

    float distSol;
    
    // Start is called before the first frame update
    void Start()
    {
        distSol = player.GetComponent<CapsuleCollider>().bounds.extents.y;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(estAuSol());
        //Ajouter && estDansMarge(mainGauche.eulerAngles.x,valeurRotationHaut,margeDetection) quand relier au casque
        //Debug.Log(mainDroite.eulerAngles.x);
        //Detection main vers le haut
        if (estDansMarge(mainDroite.eulerAngles.x,valeurRotationHaut,margeDetection) ){
            player.GetComponent<Rigidbody>().AddForce(new Vector3(0,vitesseAccendente * Time.deltaTime,0));
            //Debug.Log("Vol");
        }

        //Detetection plus au sol main vers l'avant avancer
        if(!estAuSol() && estDansMarge(mainDroite.eulerAngles.x,valeurRotationAvant,margeDetection)){
            player.GetComponent<Rigidbody>().AddForce(new Vector3(0,0,-vitesseAccendente * Time.deltaTime));



        }

        //Detection main vers l'avant + difference de hauteur
        float hauteurMainDroite = mainDroite.position.y;
        float hauteurMainGauche = mainGauche.position.y;
        //Debug.Log(hauteurMainDroite - hauteurMainGauche);

        if (hauteurMainDroite - hauteurMainGauche >= margeDetectionGaucheDroite)
        {
            player.GetComponent<Rigidbody>().AddForce(new Vector3(vitesseAccendente * Time.deltaTime, 0, 0));
        }
        else if (hauteurMainDroite - hauteurMainGauche <= -margeDetectionGaucheDroite)
        {
            player.GetComponent<Rigidbody>().AddForce(new Vector3(-vitesseAccendente * Time.deltaTime, 0, 0));
        }
        //if(estDansMarge(mainDroite.eulerAngles.x, valeurRotationAvant, margeDetection) )
        //{

        //}
        // Debug.Log(estDansMarge(mainDroite.eulerAngles.x,valeurRotationHaut,margeDetection));
        // Debug.Log(mainDroite.eulerAngles.x);
    }
    

    bool estDansMarge(float valeur,float valeurSouhaiter,float marge){
        // Debug.Log(valeur);
        // Debug.Log(valeurSouhaiter+marge );
        // Debug.Log(valeurSouhaiter-marge);
        if( valeur <= valeurSouhaiter+marge ){
            if(valeurSouhaiter-marge <= valeur ){
                return true;
            }
        }
        return false;
    }
    bool estAuSol(){
        return Physics.Raycast(player.transform.position, -Vector3.up, distSol + 0.1f);
    }
}
