using UnityEngine;
 
public class PlayerGlideController : MonoBehaviour
{

    // horizontal rotation speed
    [HideInInspector]
    public float horizontalSpeed = 1f;
    // vertical rotation speed
    [HideInInspector]
    public float verticalSpeed = 1f;
    private float xRotation = 0.0f;
    private float yRotation = 0.0f;
    private Camera cam;
    [SerializeField]
    bool doCameraMouvement = true;
    [SerializeField]
    float playerGlideSpeed = 20f;
    [SerializeField]
    float playerGravity= 0f;
    void Awake()
    {
        cam = Camera.main;
        Cursor.visible = false;
    }
 
    void Update()
    {
        if(doCameraMouvement){
            cam.transform.position = this.transform.position;
            float mouseX = Input.GetAxis("Mouse X") * horizontalSpeed;
            float mouseY = Input.GetAxis("Mouse Y") * verticalSpeed;
    
            yRotation += mouseX;
            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90, 90);
    
            cam.transform.eulerAngles = new Vector3(xRotation, yRotation, 0.0f);
        }
        Vector3 dir =  cam.transform.forward;
        if(estDansMarge(cam.transform.forward.y,1f,0.5f)){
            Debug.Log("Joueur va vers le Hauts");
        }else  if(estDansMarge(cam.transform.forward.y,-1f,0.5f)){
            Debug.Log("Joueur va vers le bas");
        }else{
            Debug.Log("Joueur Milieus");
        }
        dir.y = playerGravity;
        GetComponent<Rigidbody>().velocity = playerGlideSpeed * dir;
      
        
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
}