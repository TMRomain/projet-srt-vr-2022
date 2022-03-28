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
    float playerMaxGlideSpeed = 50f;
    [SerializeField]
    float playerMinGlideSpeed = 10f;
    float playerGlideSpeed = 20f;
    float playerActualGlideSpeed = 20f;
    [SerializeField]
    float playerMaxGravity= 5f;
    [SerializeField]
    float playerMinGravity= -2f;
 
    float playerActualGravity= 0f;
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
            Debug.Log("Joueur va vers le haut");
            float glideSpeed = playerActualGlideSpeed-cam.transform.forward.y*Time.deltaTime;
            playerActualGlideSpeed = Mathf.Clamp(glideSpeed,playerMinGlideSpeed,playerMaxGlideSpeed);

        }else  if(estDansMarge(cam.transform.forward.y,-1f,0.5f)){
            Debug.Log("Joueur va vers le bas");
            float glideSpeed = playerActualGlideSpeed+cam.transform.forward.y*Time.deltaTime;
            playerActualGlideSpeed = Mathf.Clamp(glideSpeed,playerMinGlideSpeed,playerMaxGlideSpeed);
        }else{
            Debug.Log("Joueur va vers le millieu");
            
        }
        dir.y = playerActualGravity;
        GetComponent<Rigidbody>().velocity = playerActualGlideSpeed * dir;
      
        
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