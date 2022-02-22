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
    float valeurRotationHaut = 90;

    [SerializeField]
    float margeDetection = 10;


    [SerializeField]
    float vitesseAccendente = 0.5f;

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
        Debug.Log(estAuSol());
        //Ajouter && estDansMarge(mainGauche.eulerAngles.x,valeurRotationHaut,margeDetection) quand relier au casque
        if(estDansMarge(mainDroite.eulerAngles.x,valeurRotationHaut,margeDetection) ){
            player.GetComponent<Rigidbody>().AddForce(new Vector3(0,vitesseAccendente * Time.deltaTime,0));
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
    bool estAuSol(){
        return Physics.Raycast(player.transform.position, -Vector3.up, distSol + 0.1f);
    }
}
