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
    float playerMaxGlideSpeed = 90f;
    [SerializeField]
    float playerMinGlideSpeed = 10f;
    float playerGlideSpeed = 20f;
    float playerActualGlideSpeed = 20f;
    [SerializeField]
    float playerMaxGravity= 5f;
    [SerializeField]
    float playerMinGravity= -2f;
 
    float playerActualGravity= 0f;


    float playerMinFov = 50f;
    float playerMaxFov = 90f;
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

        float percentage = playerActualGlideSpeed / playerMaxGlideSpeed;

        if(estDansMarge(cam.transform.forward.y,1f,0.5f)){
            // Debug.Log("Joueur va vers le haut");
            float glideSpeed = playerActualGlideSpeed-(cam.transform.forward.y*percentage*15f)*Time.deltaTime;
            playerActualGlideSpeed = Mathf.Clamp(glideSpeed,playerMinGlideSpeed,playerMaxGlideSpeed);
            if(!estDansMarge(playerActualGlideSpeed,playerMinGlideSpeed,10f)){
                // Debug.Log("Monte");
                float playerGravity = playerActualGravity + (0.01f * percentage*100f)*Time.deltaTime;
                playerActualGravity = Mathf.Clamp(playerGravity,playerMinGravity,playerMaxGravity);
            }else{
                float playerGravity = playerActualGravity - (1 * percentage)*Time.deltaTime;
                playerActualGravity = Mathf.Clamp(playerGravity,playerMinGravity,playerMaxGravity);
            }
           

        }else  if(estDansMarge(cam.transform.forward.y,-1f,0.5f)){
            // Debug.Log("Joueur va vers le bas");
            float glideSpeed = playerActualGlideSpeed+Mathf.Abs(cam.transform.forward.y*15f)*Time.deltaTime;
            playerActualGlideSpeed = Mathf.Clamp(glideSpeed,playerMinGlideSpeed,playerMaxGlideSpeed);
            
            float playerGravity = playerActualGravity - (1 * percentage*2)*Time.deltaTime;
            playerActualGravity = Mathf.Clamp(playerGravity,playerMinGravity,playerMaxGravity);

        }else{
            // Debug.Log("Joueur va vers le millieu");
          
            
            if(!estDansMarge(playerActualGlideSpeed,playerMinGlideSpeed,10f) && cam.transform.forward.y >0f ){
                Debug.Log("Monte");
                float glideSpeed = playerActualGlideSpeed-(cam.transform.forward.y*percentage*2.5f)*Time.deltaTime;
                playerActualGlideSpeed = Mathf.Clamp(glideSpeed,playerMinGlideSpeed,playerMaxGlideSpeed);
                float playerGravity = playerActualGravity + (0.5f * percentage*cam.transform.forward.y*2f)*Time.deltaTime;
            playerActualGravity = Mathf.Clamp(playerGravity,playerMinGravity,playerMaxGravity);
            }else{
                Debug.Log("Decent");
                float glideSpeed = playerActualGlideSpeed+Mathf.Abs(cam.transform.forward.y*percentage*8f)*Time.deltaTime;
                playerActualGlideSpeed = Mathf.Clamp(glideSpeed,playerMinGlideSpeed,playerMaxGlideSpeed);
                float playerGravity = playerActualGravity - Mathf.Abs((0.5f * percentage*cam.transform.forward.y*8f)*Time.deltaTime);
                playerActualGravity = Mathf.Clamp(playerGravity,-0.5f,playerMaxGravity);
            }

        }
        Camera.main.fieldOfView = Mathf.Lerp(playerMinFov, playerMaxFov, percentage);
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