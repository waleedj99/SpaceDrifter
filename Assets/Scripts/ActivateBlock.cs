using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateBlock : MonoBehaviour
{
    public bool enableView;
    SceneController Sc;
    public SimpleHealthBar fuelBar;

    ShipRes shipRes;
    // Start is called before the first frame update
    void Start()
    {
        fuelBar = GameObject.Find("FuelBar").transform.Find("Status Fill 01").GetComponent<SimpleHealthBar>();
        shipRes = GameObject.Find("Ship").GetComponent<ShipRes>();
        transform.Find("TrailRender").GetComponent<TrailRenderer>().enabled = false;
        Sc = GameObject.Find("SceneManager").GetComponent<SceneController>();
        GetComponent<BoxCollider2D>().isTrigger = true;
    }
void OnTriggerEnter2D(Collider2D other)
{
        if (other.gameObject.CompareTag("Pilot") && !Sc.GrabberOn)
        {
            Sc.playerOnTrigger = true;
        }
}
    private void OnTriggerStay2D(Collider2D other) {
        if(other.gameObject.CompareTag("Pilot") && !Sc.GrabberOn){
           
            if(gameObject.transform.childCount==0){
                if(Input.GetMouseButton(1)){
                    enableView = true;   
                }
                else if (Input.GetMouseButtonUp(1))
                {
                    enableView = false;
                    Debug.Log("This is happening");
                }
            }else{
                if (Input.GetMouseButtonDown(1))
                {
                    Debug.Log("Feed");
                }
                
            }
            //Move Ship
            
            if(Input.GetMouseButton(0) && !Sc.GrabberOn ){
                //GetComponent<AudioSource>().Play();
                GameObject.Find("Ship").GetComponent<ShipRes>().movement = false;
                shipRes.fuel -= Time.deltaTime * 1.5f;
                //Debug.Log("1.5");
                SceneController.fuelMultiplier = 1.5f;
                fuelBar.UpdateBar(shipRes.fuel, shipRes.initialFuel);
                switch (gameObject.name)
                {
                    case "LeftTrigger":
                        transform.Find("TrailRender").GetComponent<TrailRenderer>().enabled = true;
                        GameObject.Find("Ship").GetComponent<Transform>().Translate(0.1f, 0, 0);
                        GameObject.Find("GameWinTrigger").GetComponent<Transform>().Translate(0.1f, 0, 0);
                        
                        break;
                    case "RightTrigger":
                        transform.Find("TrailRender").GetComponent<TrailRenderer>().enabled = true;
                        GameObject.Find("Ship").GetComponent<Transform>().Translate(-0.1f, 0, 0);
                        GameObject.Find("GameWinTrigger").GetComponent<Transform>().Translate(-0.1f, 0, 0);
                        break; 
                        
                    case "UpTrigger":
                        transform.Find("TrailRender").GetComponent<TrailRenderer>().enabled = true;
                        GameObject.Find("Ship").GetComponent<Transform>().Translate(0, -0.1f, 0);
                        
                        break;
                    case "DownTrigger":
                        transform.Find("TrailRender").GetComponent<TrailRenderer>().enabled = true;
                        GameObject.Find("Ship").GetComponent<Transform>().Translate(0, 0.1f, 0);
                        break;
                    
                    default:break;
                }
            }else{
                
                transform.Find("TrailRender").GetComponent<TrailRenderer>().enabled = false;
                GameObject.Find("Ship").GetComponent<ShipRes>().movement = true;
            }
        }
    }
    /// <summary>
    /// Sent when another object leaves a trigger collider attached to
    /// this object (2D physics only).
    /// </summary>
    /// <param name="other">The other Collider2D involved in this collision.</param>
    void OnTriggerExit2D(Collider2D other)
    {
        transform.Find("TrailRender").GetComponent<TrailRenderer>().enabled = false;
        GameObject.Find("Ship").GetComponent<ShipRes>().movement = true;
        if(other.CompareTag("Pilot"))
        {
            Sc.playerOnTrigger = false;
            if(gameObject.transform.childCount == 0) 
                enableView = false;
            
        }
    }
    // Update is called once per frame
    void Update()
    {
        
        
        if(enableView){
            transform.GetComponentInParent<SpriteRenderer>().enabled = false;
            
        }else
        {
            transform.GetComponentInParent<SpriteRenderer>().enabled = true;
        }
    }
}
