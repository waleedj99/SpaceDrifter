using UnityEngine;
using System.Collections;

public class CamShakeSimple : MonoBehaviour 
{

    

    public float shakeAmt;
    float quakeAmt;
    public Camera mainCamera;
    Transform shipTrans;

/// <summary>
/// Start is called on the frame when a script is enabled just before
/// any of the Update methods is called the first time.
/// </summary>
void Start()
{
    shipTrans =GameObject.Find("Ship").GetComponent<Transform>();
	mainCamera = Camera.main;
}
    void OnCollisionEnter2D(Collision2D coll) 
    {
        if(coll.gameObject.CompareTag("Debri"))
         {   
            Invoke("CameraShakeR",0);
            Invoke("StopShakingR", 0.05f);
            Invoke("CameraShakeL", 0.1f);
            Invoke("StopShakingL",0.15f);
            if(gameObject.name == "Ship")
                GetComponent<ShipRes>().fuel -= coll.gameObject.GetComponent<Rigidbody2D>().mass*10;
            // coll.gameObject.GetComponentInChildren<ParticleSystem>().Play();
            // Destroy(coll.gameObject);

        } 
    }
    

    void CameraShakeR()
    {
        if(shakeAmt>0) 
        {
            quakeAmt = Random.value*shakeAmt - shakeAmt;
            Vector3 pp = mainCamera.transform.position;
            pp.y+= quakeAmt; // can also add to x and/or z
        
            pp.x+= quakeAmt;
            mainCamera.transform.position = pp;
              
            
        }
    }
    void CameraShakeL()
    {
        if (shakeAmt > 0)
        {
            
            Vector3 pp = mainCamera.transform.position;
            pp.y -= quakeAmt; // can also add to x and/or z
            
            pp.x -= quakeAmt;
            mainCamera.transform.position = pp;


        }
    }

    void StopShakingR()
    {
        CancelInvoke("CameraShake");
        
        Vector3 pp = mainCamera.transform.position;
        pp.y -= quakeAmt; // can also add to x and/or z
        
        pp.x -= quakeAmt;
        
        mainCamera.transform.position = pp;
    }
    void StopShakingL()
    {
        CancelInvoke("CameraShake");

        Vector3 pp = mainCamera.transform.position;
        pp.y += quakeAmt; // can also add to x and/or z

        pp.x += quakeAmt;

        mainCamera.transform.position = pp;
    }

}